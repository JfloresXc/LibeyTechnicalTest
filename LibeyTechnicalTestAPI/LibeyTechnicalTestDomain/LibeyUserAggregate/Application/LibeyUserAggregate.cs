using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class LibeyUserAggregate : ILibeyUserAggregate
    {
        private readonly ILibeyUserRepository _repository;
        public LibeyUserAggregate(ILibeyUserRepository repository)
        {
            _repository = repository;
        }
        public void Create(UserUpdateorCreateCommand newUser)
        {
            LibeyUser user = new LibeyUser(
                newUser.DocumentNumber,
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

            _repository.Create(user);
        }
        public LibeyUserResponse FindResponse(string documentNumber)
        {
            var row = _repository.FindResponse(documentNumber);
            return row;
        }
        public List<LibeyUserResponse> ListAll()
        {
            List<LibeyUserResponse> users = _repository.ListAll();
            return users;
        }
        public void Update(UserUpdateorCreateCommand newUser)
        {
            LibeyUser user = new LibeyUser(
                newUser.DocumentNumber,
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

            _repository.Update(user);
        }

        public void Delete(string documentNumber)
        {
            _repository.Delete(documentNumber);
        }

        public void ToggleActive(string documentNumber, bool isActive)
        {
            _repository.ToggleActive(documentNumber, isActive);
        }
    }
}