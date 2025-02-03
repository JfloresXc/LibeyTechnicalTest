export interface LibeyUser {
    documentNumber: string;
    documentTypeId: number;
    documentTypeDescription?: number;
    name: string;
    fathersLastName: string;
    mothersLastName: string;
    address: string;
    regionCode: string;
    regionDescription?: string;
    provinceCode: string;
    provinceDescription?: string;
    ubigeoCode: string;
    ubigeoDescription?: string;
    phone: string;
    email: string;
    password: string;
    active: boolean;
}

export interface LibeyUserResponse {
    data: LibeyUserResponseItem[];
    success: boolean;
    message: string;
}

export interface LibeyUserResponseItem {
    documentNumber: string;
    documentTypeId: number;
    documentTypeDescription: number;
    name: string;
    fathersLastName: string;
    mothersLastName: string;
    address: string;
    regionCode: string;
    regionDescription: string;
    provinceCode: string;
    provinceDescription: string;
    ubigeoCode: string;
    ubigeoDescription: string;
    phone: string;
    email: string;
    password: string;
    active: boolean;
}

export interface UserUpdateorCreateCommand {
    documentNumber: string;
    documentTypeId: number;
    name: string;
    fathersLastName: string;
    mothersLastName: string;
    address: string;
    ubigeoCode: string;
    phone: string;
    email: string;
    password: string;
    active: boolean;
}