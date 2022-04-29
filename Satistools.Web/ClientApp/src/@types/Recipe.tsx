import {Item} from "./Item";
import {Building} from "./Building";

export type Recipe = {
    id: string;
    displayName: string;
    manufactoringDuration: string;
    isAlternate: boolean;
    ingredients: RecipePart[];
    products: RecipePart[];
    producedIn: Building;
}

export type RecipePart = {
    amount: number;
    amountPerMin: number;
    item: Item;
}