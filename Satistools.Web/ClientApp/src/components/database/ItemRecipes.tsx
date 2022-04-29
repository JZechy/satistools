import {LoadingState} from "../../@types/LoadingState";
import {Recipe, RecipePart} from "../../@types/Recipe";
import {Component} from "react";
import {Badge, Card, CardHeader, Table} from "reactstrap";
import {Image} from "../common/Image";
import {ItemLink} from "../common/ItemLink";

type ItemRecipesProps = {
    itemId: string;
}

type ItemRecipesState = LoadingState & {
    recipes: Recipe[];
}

export abstract class ItemRecipes extends Component<ItemRecipesProps, ItemRecipesState> {
    protected constructor(props: ItemRecipesProps) {
        super(props);

        this.state = {
            loading: true,
            recipes: []
        }
    }

    async componentDidMount(): Promise<void> {
        await this.fetchRecipes();
    }

    private async fetchRecipes(): Promise<void> {
        let response: Response = await fetch(this.getEndPoint() + this.props.itemId);
        let data: Recipe[] = await response.json();
        this.setState({recipes: data, loading: false});
    }

    abstract getEndPoint(): string;

    private renderRecipes(): JSX.Element[] {
        let rendered: JSX.Element[] = new Array(this.state.recipes.length);

        this.state.recipes.forEach((recipe: Recipe) => {
            rendered.push(
                <Card className="my-3" key={recipe.id}>
                    <CardHeader className="d-flex justify-content-between align-items-center">
                        <h5 className="mb-0">
                            {recipe.displayName} {recipe.isAlternate ? <Badge className="bg-danger rounded-pill">ALTERNATE</Badge> : <></>}
                        </h5>
                        <div className="d-flex align-items-center badge rounded-pill bg-secondary">
                            <Image name={recipe.producedIn.bigIcon} size={24} alt={recipe.producedIn.displayName}/>
                            <span className="mx-2">{recipe.producedIn.displayName}</span>
                        </div>
                    </CardHeader>
                    <Table bordered className="mb-0">
                        <thead>
                        <tr>
                            <td className="text-center" width="50%"><strong>Ingredients</strong></td>
                            <td className="text-center"><strong>Products</strong></td>
                        </tr>
                        </thead>
                        <tbody>
                        <tr>
                            {this.renderItems(recipe.ingredients)}
                            {this.renderItems(recipe.products)}
                        </tr>
                        </tbody>
                    </Table>
                </Card>
            );
        });

        return rendered;
    }

    private renderItems(parts: RecipePart[]): JSX.Element {
        let rendered: JSX.Element[] = new Array(parts.length);
        parts.forEach((part: RecipePart) => {
            rendered.push(
                <div key={part.item.id} className="d-flex w-100 my-2 align-items-middle">
                    <Image name={part.item.bigIcon} size={24} alt={part.item.displayName}/>
                    <div className="mx-2">
                        <ItemLink item={part.item}/>
                    </div>
                    <small>
                        <span className="badge bg-secondary mx-2">{part.amount}x</span>
                        <span className="badge bg-primary badge-">{part.amountPerMin} / min</span>
                    </small>
                </div>
            );
        });

        return <td>{rendered}</td>;
    }

    render(): JSX.Element {
        return this.state.loading ? <></> : <>{this.renderRecipes()}</>;
    }
}