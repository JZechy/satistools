import {ItemRecipes} from "./ItemRecipes";

export class ItemProducesRecipes extends ItemRecipes {
    getEndPoint(): string {
        return "/Database/recipes/whoProduces/";
    }
    
}