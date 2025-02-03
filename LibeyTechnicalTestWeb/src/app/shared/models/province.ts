export interface Province {
    provinceCode: string;
    regionCode: string;
    provinceDescription: string;
}

export interface ProvinceResponse {
    data: ProvinceResponseItem[];
    success: boolean;
    message: string;
}

export interface ProvinceResponseItem {
    provinceCode: string;
    regionCode: string;
    provinceDescription: string;
}
