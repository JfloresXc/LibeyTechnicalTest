using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface ILibeyUserRepository
    {
        LibeyUserResponse FindResponse(string documentNumber);
        void Create(LibeyUser libeyUser);
        List<LibeyUserResponse> ListAll();
        void Delete(string documentNumber);
        void Update(LibeyUser libeyUser);
        void ToggleActive(string documentNumber, bool isActive);
    }
}
