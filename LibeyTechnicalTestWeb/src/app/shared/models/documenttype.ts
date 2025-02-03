export interface DocumentType {
    documentTypeId: string;
    documentTypeDescription: string;
}

export interface DocumentTypeResponse {
    data: DocumentTypeResponseItem[];
    success: boolean;
    message: string;
}

export interface DocumentTypeResponseItem {
    documentTypeId: string;
    documentTypeDescription: string;
}
