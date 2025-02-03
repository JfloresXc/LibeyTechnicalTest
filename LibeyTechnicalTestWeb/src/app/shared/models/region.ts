export interface Region {
    regionCode: string;
    regionDescription: string;
}

export interface RegionResponse {
    data: RegionResponseItem[];
    success: boolean;
    message: string;
}

export interface RegionResponseItem {
    regionCode: string;
    regionDescription: string;
}