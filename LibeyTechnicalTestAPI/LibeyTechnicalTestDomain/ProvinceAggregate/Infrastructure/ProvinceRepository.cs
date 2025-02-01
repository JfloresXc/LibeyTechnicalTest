using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.ProvinceAggregate.Application.DTO;
using LibeyTechnicalTestDomain.ProvinceAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.ProvinceAggregate.Domain;
using System.Linq;

namespace LibeyTechnicalTestDomain.ProvinceAggregate.Infrastructure
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