import {Component} from "react";
import {LoadingState} from "../../@types/LoadingState";
import {Item} from "../../@types/Item";
import {Card, CardBody, CardHeader, Nav, NavItem, NavLink, Table} from "reactstrap";
import {ItemUsesRecipes} from "./ItemUsesRecipes";
import {ItemProducesRecipes} from "./ItemProducesRecipes";

enum Menu {
    Description,
    UsedBy,
    ProducedBy
}

type ItemDetailProps = {
    id: string;
}

type ItemDetailState = LoadingState & {
    item: Item | null;
    menu: Menu;
}

export class ItemDetail extends Component<ItemDetailProps, ItemDetailState> {
    constructor(props: ItemDetailProps) {
        super(props);
        
        this.state = {
            item: null,
            loading: true,
            menu: Menu.Description
        }
        
        this.changeTab.bind(this);
    }
    
    async componentDidMount(): Promise<void> {
        await this.fetchItemData();
    }
    
    private async fetchItemData(): Promise<void> {
        let response: Response = await fetch("Database/items/"+this.props.id);
        let data: Item = await response.json();
        this.setState({item: data, loading: false});
    }
    
    private changeTab(menuItem: Menu): void {
        this.setState({menu: menuItem, loading: false, item: this.state.item});
    }
    
    private renderItemDetails(): JSX.Element {
        let item: Item = this.state.item!;
        let imgSrc: string = "/img/"+item.bigIcon+".png";
        let cardBody: JSX.Element;
        switch(this.state.menu) {
            case Menu.Description:
                cardBody = <p>{item.description}</p>;
                break;
            case Menu.UsedBy:
                cardBody = <ItemUsesRecipes itemId={item.id}/>;
                break;
            case Menu.ProducedBy:
                cardBody = <ItemProducesRecipes itemId={item.id}/>;
                break;
        }
        
        return (
            <>
                <h1 className="mb-5">{this.state.item?.displayName}</h1>
                <div className="row">
                    <div className="col-3">
                        <Table bordered>
                            <tbody>
                            <tr>
                                <td colSpan={2}>
                                    <img src={imgSrc} alt={item.displayName} className="d-block mx-auto" width="256"/>
                                </td>
                            </tr>
                            <tr>
                                <td><strong>Stack Size</strong></td>
                                <td className="text-end">{item.stackSize===0?'N/A':item.stackSize}</td>
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
                        <Card>
                            <CardHeader>
                                <Nav tabs card>
                                    <NavItem>
                                        <NavLink href="#" active={this.state.menu === Menu.Description} onClick={() => {this.changeTab(Menu.Description)}}>
                                            Description
                                        </NavLink>
                                    </NavItem>
                                    <NavItem>
                                        <NavLink href="#" active={this.state.menu === Menu.UsedBy} onClick={() => {this.changeTab(Menu.UsedBy)}}>
                                            Used By
                                        </NavLink>
                                    </NavItem>
                                    <NavItem>
                                        <NavLink href="#" active={this.state.menu === Menu.ProducedBy} onClick={() => {this.changeTab(Menu.ProducedBy)}}>
                                            Produced By
                                        </NavLink>
                                    </NavItem>
                                </Nav>
                            </CardHeader>
                            <CardBody>
                                {cardBody}
                            </CardBody>
                        </Card>
                    </div>
                </div>
            </>
        )
    }
    
    render(): JSX.Element {
        return this.state.loading ? <></> : this.renderItemDetails();
    }
}
