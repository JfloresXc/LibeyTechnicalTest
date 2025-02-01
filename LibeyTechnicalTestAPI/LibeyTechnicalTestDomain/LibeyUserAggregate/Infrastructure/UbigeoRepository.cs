using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using System.Linq;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class UbigeoRepository : IUbigeoRepository
    {
        private readonly Context _context;
        public UbigeoRepository(Context context)
        {
            _context = context;
        }

        public List<UbigeoResponse> ListAll()
        {
            List<UbigeoResponse> Ubigeos = (from Ubigeo in _context.Ubigeos
                    select new UbigeoResponse()
                    {
                        UbigeoCode = Ubigeo.UbigeoCode,
                        RegionCode = Ubigeo.RegionCode,
                        ProvinceCode = Ubigeo.ProvinceCode,
                        UbigeoDescription = Ubigeo.UbigeoDescription
                    }).ToList();

            if (Ubigeos.Any()) return Ubigeos;
            else return new List<UbigeoResponse>();
        }
    }
}