using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.DTO;
using LibeyTechnicalTestDomain.DocumentTypeAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.DocumentTypeAggregate.Domain;
using System.Linq;

namespace LibeyTechnicalTestDomain.DocumentTypeAggregate.Infrastructure
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private readonly Context _context;
        public DocumentTypeRepository(Context context)
        {
            _context = context;
        }

        public List<DocumentTypeResponse> ListAll()
        {
            List<DocumentTypeResponse> DocumentTypes = (from DocumentType in _context.DocumentTypes
                    select new DocumentTypeResponse()
                    {
                        DocumentTypeId = DocumentType.DocumentTypeId,
                        DocumentTypeDescription = DocumentType.DocumentTypeDescription,
                    }).ToList();

            if (DocumentTypes.Any()) return DocumentTypes;
            else return new List<DocumentTypeResponse>();
        }
    }
}