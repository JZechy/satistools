export type Building = {
    id: string;
    displayName: string;
    description: string;
    buildingType: BuildingType;
    isOverclockable: boolean;
    smallIcon: string;
    bigIcon: string;
}

export enum BuildingType {
    NotAvailable,
    Manufacturer,
    ResourceExtractor,
    PowerGenerator
}