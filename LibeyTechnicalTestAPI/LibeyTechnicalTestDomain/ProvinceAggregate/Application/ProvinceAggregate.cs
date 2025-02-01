using LibeyTechnicalTestDomain.ProvinceAggregate.Application.DTO;
using LibeyTechnicalTestDomain.ProvinceAggregate.Application.Interfaces;

namespace LibeyTechnicalTestDomain.ProvinceAggregate.Application
{
    public class ProvinceAggregate : IProvinceAggregate
    {
        private readonly IProvinceRepository _repository;
        public ProvinceAggregate(IProvinceRepository repository)
        {
            _repository = repository;
        }
        public List<ProvinceResponse> ListAll()
        {
            List<ProvinceResponse> Provinces = _repository.ListAll();
            return Provinces;
        }
    }
}