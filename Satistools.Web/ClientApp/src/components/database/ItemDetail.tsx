import {Component} from "react";
import {LoadingState} from "../../@types/LoadingState";
import {Item} from "../../@types/Item";
import {Table} from "reactstrap";

type ItemDetailProps = {
    id: string;
}

type ItemDetailState = LoadingState & {
    item: Item | null;
}

export class ItemDetail extends Component<ItemDetailProps, ItemDetailState> {
    constructor(props: ItemDetailProps) {
        super(props);
        
        this.state = {
            item: null,
            loading: true
        }
    }
    
    async componentDidMount(): Promise<void> {
        await this.fetchItemData();
    }
    
    private async fetchItemData(): Promise<void> {
        let response: Response = await fetch("Database/items/"+this.props.id);
        let data: Item = await response.json();
        this.setState({item: data, loading: false});
    }
    
    private renderItemDetails(): JSX.Element {
        let item: Item = this.state.item!;
        let imgSrc: string = "/img/"+item.bigIcon+".png";
        
        return (
            <>
                <h1 className="mb-5">{this.state.item?.displayName}</h1>
                <div className="row">
                    <div className="col-3">
                        <Table bordered>
                            <tbody>
                            <tr>
                                <td colSpan={2}>
                                    <img src={imgSrc} alt={item.displayName} className="d-block mx-auto"/>
                                </td>
                            </tr>
                            <tr>
                                <td><strong>Stack Size</strong></td>
                                <td className="text-end">{item.stackSize}</td>
                            </tr>
                            <tr>
                                <td><strong>Resource Sink Points</strong></td>
                                <td className="text-end">{item.resourceSinkPoints}</td>
                            </tr>
                            <tr>
                                <td><strong>Radioactive</strong></td>
                                <td className="text-end">{item.isRadioactive?'Yes':'No'}</td>
                            </tr>
                            <tr>
                                <td><strong>Seasonal Event</strong></td>
                                <td className="text-end">{item.isEvent?'Yes':'No'}</td>
                            </tr>
                            </tbody>
                        </Table>
                    </div>
                    <div className="col-9">
                        <p>{item.description}</p>
                    </div>
                </div>
            </>
        )
    }
    
    render(): JSX.Element {
        return this.state.loading ? <></> : this.renderItemDetails();
    }
}
