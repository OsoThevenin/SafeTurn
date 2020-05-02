export interface BookDto {
    shopId: string;
    shopName: string;
    hours: HourDto[];
}

export interface HourDto {
    range: number;
    offer: string;
}
