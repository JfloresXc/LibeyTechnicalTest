using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class LibeyUserRepository : ILibeyUserRepository
    {
        private readonly Context _context;
        public LibeyUserRepository(Context context)
        {
            _context = context;
        }
        public void Create(LibeyUser libeyUser)
        {
            _context.LibeyUsers.Add(libeyUser);
            _context.SaveChanges();
        }
        public LibeyUserResponse FindResponse(string documentNumber)
        {
            try
            {
                IQueryable<LibeyUserResponse> query = from libeyUser in _context.LibeyUsers.Where(x => x.DocumentNumber.Equals(documentNumber))
                                                      select new LibeyUserResponse()
                                                      {
                                                         DocumentNumber = libeyUser.DocumentNumber,
                                                         Active = libeyUser.Active,
                                                         Address = libeyUser.Address,
                                                         DocumentTypeId = libeyUser.DocumentTypeId,
                                                         DocumentTypeDescription = (
                                                            from documentType in _context.DocumentTypes
                                                            where documentType.DocumentTypeId == libeyUser.DocumentTypeId
                                                            select documentType.DocumentTypeDescription
                                                        ).FirstOrDefault() ?? "",
                                                         Email = libeyUser.Email,
                                                         FathersLastName = libeyUser.FathersLastName,
                                                         MothersLastName = libeyUser.MothersLastName,
                                                         Name = libeyUser.Name,
                                                         Password = libeyUser.Password,
                                                         Phone = libeyUser.Phone,
                                                         UbigeoCode = libeyUser.UbigeoCode,
                                                         UbigeoDescription = (
                                                            from ubigeo in _context.Ubigeos
                                                            where ubigeo.UbigeoCode == libeyUser.UbigeoCode
                                                            select ubigeo.UbigeoDescription
                                                        ).FirstOrDefault() ?? "",
                                                         ProvinceCode = libeyUser.UbigeoCode.Substring(0, 4),
                                                         ProvinceDescription = (
                                                            from province in _context.Provinces
                                                            where province.ProvinceCode == libeyUser.UbigeoCode.Substring(0, 4)
                                                            select province.ProvinceDescription
                                                        ).FirstOrDefault() ?? "",
                                                         RegionCode = libeyUser.UbigeoCode.Substring(0, 2),
                                                         RegionDescription = (
                                                            from region in _context.Regions
                                                            where region.RegionCode == libeyUser.UbigeoCode.Substring(0, 2)
                                                            select region.RegionDescription
                                                        ).FirstOrDefault() ?? "",
                                                      };
                List<LibeyUserResponse> list = query.ToList();

                if (list.Any()) return list.First();
                else return new LibeyUserResponse();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al encontrar usuario: {ex.Message}", ex);
            }
        }

        public List<LibeyUserResponse> ListAll()
        {
            try
            {
                List<LibeyUserResponse> users = (from libeyUser in _context.LibeyUsers
                                                 select new LibeyUserResponse()
                                                 {
                                                     DocumentNumber = libeyUser.DocumentNumber,
                                                     Active = libeyUser.Active,
                                                     Address = libeyUser.Address,
                                                     DocumentTypeId = libeyUser.DocumentTypeId,
                                                     DocumentTypeDescription = (
                                                        from documentType in _context.DocumentTypes
                                                        where documentType.DocumentTypeId == libeyUser.DocumentTypeId
                                                        select documentType.DocumentTypeDescription
                                                    ).FirstOrDefault() ?? "",
                                                     Email = libeyUser.Email,
                                                     FathersLastName = libeyUser.FathersLastName,
                                                     MothersLastName = libeyUser.MothersLastName,
                                                     Name = libeyUser.Name,
                                                     Password = libeyUser.Password,
                                                     Phone = libeyUser.Phone,
                                                     UbigeoCode = libeyUser.UbigeoCode,
                                                     UbigeoDescription = (
                                                        from ubigeo in _context.Ubigeos
                                                        where ubigeo.UbigeoCode == libeyUser.UbigeoCode
                                                        select ubigeo.UbigeoDescription
                                                    ).FirstOrDefault() ?? "",
                                                     ProvinceCode = libeyUser.UbigeoCode.Substring(0, 4),
                                                     ProvinceDescription = (
                                                        from province in _context.Provinces
                                                        where province.ProvinceCode == libeyUser.UbigeoCode.Substring(0, 4)
                                                        select province.ProvinceDescription
                                                    ).FirstOrDefault() ?? "",
                                                     RegionCode = libeyUser.UbigeoCode.Substring(0, 2),
                                                     RegionDescription = (
                                                        from region in _context.Regions
                                                        where region.RegionCode == libeyUser.UbigeoCode.Substring(0, 2)
                                                        select region.RegionDescription
                                                    ).FirstOrDefault() ?? "",
                                                 }).ToList();

                if (users.Any()) return users;
                else return new List<LibeyUserResponse>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener lista: {ex.Message}", ex);
            }
        }

        public void Update(LibeyUser newUser)
        {
            try
            {
                var user = _context.LibeyUsers.FirstOrDefault(x => x.DocumentNumber.Equals(newUser.DocumentNumber));

                if (user == null)
                    throw new KeyNotFoundException("Usuario no encontrado.");

                user.set(
                    newUser.DocumentTypeId,
                    newUser.Name,
                    newUser.FathersLastName,
                    newUser.MothersLastName,
                    newUser.Address,
                    newUser.UbigeoCode,
                    newUser.Phone,
                    newUser.Email,
                    newUser.Password
                );
                
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar el usuario: {ex.Message}", ex);
            }
        }

        public void ToggleActive(string documentNumber, bool isActive)
        {
            try
            {
                var user = _context.LibeyUsers.FirstOrDefault(x => x.DocumentNumber.Equals(documentNumber));

                if (user == null)
                    throw new KeyNotFoundException("Usuario no encontrado.");

                user.toggleActive(isActive);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar el usuario: {ex.Message}", ex);
            }
        }
        public void Delete(string documentNumber)
        {
            try
            {
                var user = _context.LibeyUsers.FirstOrDefault(x => x.DocumentNumber.Equals(documentNumber));

                if (user == null)
                    throw new KeyNotFoundException("Usuario no encontrado.");

                _context.LibeyUsers.Remove(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el usuario: {ex.Message}", ex);
            }
        }
    }
}