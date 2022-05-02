import {Component} from "react";
import {LoadingState} from "../../../@types/LoadingState";
import {Item, ItemCategory, ItemForm} from "../../../@types/Item";
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
        let response: Response = await fetch("api/database/items/"+this.props.id);
        let data: Item = await response.json();
        this.setState({item: data, loading: false});
    }
    
    private changeTab(menuItem: Menu): void {
        this.setState({menu: menuItem, loading: false, item: this.state.item});
    }
    
    private itemAssemblyBadge(): JSX.Element {
        if(this.state.item?.isProjectAssembly) {
            return <span className="badge bg-primary mx-2">Project Assembly</span>;
        }
        
        return <></>;
    }
    
    private itemCategoryBadge(): JSX.Element {
        let item: Item = this.state.item!;
        let category: string;
        switch(item.itemCategory) {
            case ItemCategory.Part:
                category = "Product";
                break;
            case ItemCategory.Resource:
                category = "Resource";
                break;
            case ItemCategory.Consumable:
                category = "Consumable";
                break;
            case ItemCategory.Equipment:
                category = "Equipment";
                break;
            case ItemCategory.Ammo:
                category = "Ammo";
                break;
            case ItemCategory.Biomass:
                category = "Biomass";
                break;

        }
        
        return <span className="badge bg-info mx-2">{category}</span>;
    }
    
    private itemFluidBadge(): JSX.Element {
        if(this.state.item!.form === ItemForm.Liquid) {
            return <span className="badge bg-info mx-2">Fluid</span>;
        }
        
        return <></>;
    }
    
    private renderItemCardBody(): JSX.Element {
        switch(this.state.menu) {
            case Menu.Description:
                return <p>{this.state.item!.description}</p>;
            case Menu.UsedBy:
                return <ItemUsesRecipes itemId={this.state.item!.id}/>;
            case Menu.ProducedBy:
                return <ItemProducesRecipes itemId={this.state.item!.id}/>;
        }
    }
    
    private renderItemDetails(): JSX.Element {
        let item: Item = this.state.item!;
        let imgSrc: string = "/img/"+item.bigIcon+".png";
        
        return (
            <>
                <div  className="mb-5">
                    <h1>{this.state.item?.displayName}</h1>
                    <h5>
                        {this.itemAssemblyBadge()}
                        {this.itemCategoryBadge()}
                        {this.itemFluidBadge()}
                    </h5>
                </div>
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
                                <td className="text-end">{item.isSeasonal?'Yes':'No'}</td>
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
                                {this.renderItemCardBody()}
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
