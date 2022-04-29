import {ItemRecipes} from "./ItemRecipes";

export class ItemUsesRecipes extends ItemRecipes {
    getEndPoint(): string {
        return "/Database/recipes/whoUses/";
    }
}