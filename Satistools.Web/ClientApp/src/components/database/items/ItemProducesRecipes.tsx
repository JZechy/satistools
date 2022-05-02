import {ItemRecipes} from "./ItemRecipes";

export class ItemProducesRecipes extends ItemRecipes {
    getEndPoint(): string {
        return "/api/database/recipes/whoProduces/";
    }
    
}