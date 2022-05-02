import {Item} from "../../../@types/Item";
import {Component} from "react";
import {LoadingState} from "../../../@types/LoadingState";
import {EmptyProps} from "../../../@types/EmptyProps";
import {ItemCard} from "./ItemCard";

type ItemsState = LoadingState & {
    items: Item[];
}

export class Items extends Component<EmptyProps, ItemsState> {
    constructor(props: EmptyProps) {
        super(props);
        this.state = {
            items: [],
            loading: true
        }
    }
    
    async componentDidMount(): Promise<void> {
        await this.fetchItemsData();
    }
    
    private async fetchItemsData(): Promise<void> {
        let response: Response = await fetch("api/database/items");
        let data: Item[] = await response.json();
        this.setState({items: data, loading: false})
    }
    
    private renderItems(items: Item[]): JSX.Element {
        let cards: JSX.Element[] = new Array(items.length);
        items.forEach((item: Item) => {
            cards.push(<ItemCard item={item} key={item.id}/>);
        });
        
        return (
            <div className="row row-cols-4 g-4 my-3">
                {cards}
            </div>
        );
    }
    
    render(): JSX.Element {
        let content: JSX.Element = this.state.loading
            ? <p>Loading...</p>
            : this.renderItems(this.state.items);
            
        return (
            <>
                <h1>Items database</h1>
                {content}
            </>
        )
    }
}