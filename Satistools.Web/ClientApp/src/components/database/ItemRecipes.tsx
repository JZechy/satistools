import {LoadingState} from "../../@types/LoadingState";
import {Recipe, RecipePart} from "../../@types/Recipe";
import {Component} from "react";
import {Badge, Card, CardHeader, Table} from "reactstrap";

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
                    <CardHeader tag="h5">
                        <a href="#">{recipe.displayName}</a> {recipe.isAlternate ? <Badge className="bg-success rounded-pill">ALTERNATE</Badge> : <></>}
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
            let imgSrc: string = "img/" + part.item.bigIcon + ".png";
            let link: string = "/database/items/" + part.item.id;

            rendered.push(
                <div key={part.item.id} className="d-flex w-100 my-2 align-items-middle">
                    <img src={imgSrc} width={24} alt={part.item.displayName}/>
                    <div className="mx-2">
                        <a href={link}>{part.item.displayName}</a>
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