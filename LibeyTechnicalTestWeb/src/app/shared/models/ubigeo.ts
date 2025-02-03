export interface Ubigeo {
    ubigeoCode: string;
    provinceCode: string;
    regionCode: string;
    ubigeoDescription: string;
}

export interface UbigeoResponse {
    data: UbigeoResponseItem[];
    success: boolean;
    message: string;
}

export interface UbigeoResponseItem {
    ubigeoCode: string;
    provinceCode: string;
    regionCode: string;
    ubigeoDescription: string;
}