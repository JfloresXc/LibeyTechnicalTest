using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class RegionAggregate : IRegionAggregate
    {
        private readonly IRegionRepository _repository;
        public RegionAggregate(IRegionRepository repository)
        {
            _repository = repository;
        }
        public List<RegionResponse> ListAll()
        {
            List<RegionResponse> regions = _repository.ListAll();
            return regions;
        }
    }
}