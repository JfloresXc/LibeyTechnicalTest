using LibeyTechnicalTestDomain.RegionAggregate.Application.DTO;
using LibeyTechnicalTestDomain.RegionAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.RegionAggregate.Infrastructure;

namespace LibeyTechnicalTestDomain.RegionAggregate.Application
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