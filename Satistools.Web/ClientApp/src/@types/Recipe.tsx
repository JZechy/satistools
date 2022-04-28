import {Item} from "./Item";

export type Recipe = {
    id: string;
    displayName: string;
    manufactoringDuration: string;
    isAlternate: boolean;
    ingredients: RecipePart[];
    products: RecipePart[];
}

export type RecipePart = {
    amount: number;
    amountPerMin: number;
    item: Item;
}