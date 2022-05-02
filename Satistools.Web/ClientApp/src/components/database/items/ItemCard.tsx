import {Item} from "../../../@types/Item";
import {Component} from "react";
import {Card, CardBody, CardImg, CardTitle} from "reactstrap";
import {Link} from "react-router-dom";

type ItemCardProps = {
    item: Item;
}

export class ItemCard extends Component<ItemCardProps> {
    private item: Item;

    constructor(props: ItemCardProps) {
        super(props);

        this.item = props.item;
    }

    render(): JSX.Element {
        let link: string = "/database/items/" + this.item.id;
        let imgSrc: string = "./img/" + this.item.bigIcon + ".png";

        return (
            <div className="col">
                <Card className="h-100 p-3">
                    <Link to={link}>
                        <CardImg src={imgSrc} className="w-50 mx-auto d-block" top/>
                        <CardBody>
                            <CardTitle tag="h5" className="text-center">
                                {this.item.displayName}
                            </CardTitle>
                        </CardBody>
                    </Link>
                </Card>
            </div>
        );
    }
}