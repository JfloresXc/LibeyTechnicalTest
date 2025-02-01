using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using System.Linq;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class RegionRepository : IRegionRepository
    {
        private readonly Context _context;
        public RegionRepository(Context context)
        {
            _context = context;
        }

        public List<RegionResponse> ListAll()
        {
            List<RegionResponse> regions = (from Region in _context.Regions
                    select new RegionResponse()
                    {
                        RegionCode = Region.RegionCode,
                        RegionDescription = Region.RegionDescription
                    }).ToList();

            if (regions.Any()) return regions;
            else return new List<RegionResponse>();
        }
    }
}