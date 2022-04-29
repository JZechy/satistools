import {Component} from "react";
import {Item} from "../../@types/Item";

type ItemLinkProps = {
    item: Item;
}

export class ItemLink extends Component<ItemLinkProps> {
    render(): JSX.Element {
        let href: string = "/database/items/" + this.props.item.id;
        return <a href={href}>{this.props.item.displayName}</a>
    }
}