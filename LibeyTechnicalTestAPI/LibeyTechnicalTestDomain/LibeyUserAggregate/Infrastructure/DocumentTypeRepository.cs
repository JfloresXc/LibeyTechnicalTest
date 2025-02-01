using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using System.Linq;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
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