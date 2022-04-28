export type Item = {
    id: string;
    displayName: string;
    description: string;
    form: ItemForm;
    stackSize: ItemStackSize;
    isRadioactive: boolean;
    fluidColorHexa: string;
    gasColorHexa: string;
    smallIcon: string;
    bigIcon: string;
    resourceSinkPoints: number;
    isEvent: boolean;
}

export enum ItemForm {
    NotAvailable,
    Invalid,
    Solid,
    Liquid
}

export enum ItemStackSize {
    NotAvailable = -1,
    One = 1,
    Small = 50,
    Medium = 100,
    Big = 200,
    Huge = 500,
    Fluid = 0
}