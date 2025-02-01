using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class UbigeoAggregate : IUbigeoAggregate
    {
        private readonly IUbigeoRepository _repository;
        public UbigeoAggregate(IUbigeoRepository repository)
        {
            _repository = repository;
        }
        public List<UbigeoResponse> ListAll()
        {
            List<UbigeoResponse> Ubigeos = _repository.ListAll();
            return Ubigeos;
        }
    }
}