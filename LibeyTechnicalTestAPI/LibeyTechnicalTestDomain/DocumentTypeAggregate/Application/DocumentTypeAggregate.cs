using LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.DTO;
using LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.Interfaces;

namespace LibeyTechnicalTestDomain.DocumentTypeAggregate.Application
{
    public class DocumentTypeAggregate : IDocumentTypeAggregate
    {
        private readonly IDocumentTypeRepository _repository;
        public DocumentTypeAggregate(IDocumentTypeRepository repository)
        {
            _repository = repository;
        }
        public List<DocumentTypeResponse> ListAll()
        {
            List<DocumentTypeResponse> DocumentTypes = _repository.ListAll();
            return DocumentTypes;
        }
    }
}