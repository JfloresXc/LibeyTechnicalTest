using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using System.Linq;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly Context _context;
        public ProvinceRepository(Context context)
        {
            _context = context;
        }

        public List<ProvinceResponse> ListAll()
        {
            List<ProvinceResponse> Provinces = (from Province in _context.Provinces
                    select new ProvinceResponse()
                    {
                        ProvinceCode = Province.ProvinceCode,
                        RegionCode = Province.RegionCode,
                        ProvinceDescription = Province.ProvinceDescription
                    }).ToList();

            if (Provinces.Any()) return Provinces;
            else return new List<ProvinceResponse>();
        }
    }
}