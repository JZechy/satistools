import {Item} from "../../@types/Item";
import {Component} from "react";
import {Card, CardBody, CardText, CardTitle} from "reactstrap";
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
        let link: string = "/database/items/"+this.item.id;
        
        return (
            <div className="col">
                <Card className="h-100">
                    <CardBody>
                        <CardTitle tag="h5">
                            <Link to={link}>{this.item.displayName}</Link>
                        </CardTitle>
                        <CardText>{this.item.description}</CardText>
                    </CardBody>
                </Card>
            </div>  
        );
    }
}