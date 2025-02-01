namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
public class DocumentType
{
    public int DocumentTypeId { get; private set; }
    public string DocumentTypeDescription { get; private set; }
    public DocumentType(
        int documentTypeId,
        string documentTypeDescription
    ) {
        DocumentTypeId = documentTypeId;
        DocumentTypeDescription = documentTypeDescription;
    }
}