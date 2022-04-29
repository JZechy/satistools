import {Component} from 'react';
import {Collapse, Container, DropdownItem, DropdownMenu, DropdownToggle, Nav, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink, UncontrolledDropdown} from 'reactstrap';
import {Link} from 'react-router-dom';

type NavMenuState = {
    collapsed: boolean;
}

export class NavMenu extends Component<any, NavMenuState> {
    static displayName: string = NavMenu.name;

    constructor(props: any) {
        super(props);

        this.toggleNavbar = this.toggleNavbar.bind(this);
        this.state = {
            collapsed: true
        };
    }

    toggleNavbar(): void {
        this.setState({
            collapsed: !this.state.collapsed
        });
    }

    render(): JSX.Element {
        return (
            <header>
                <Navbar className="navbar-expand-sm navbar-toggleable-sm mb-5" color="dark" dark>
                    <Container>
                        <NavbarBrand tag={Link} to="/">Satistools.Web</NavbarBrand>
                        <NavbarToggler onClick={this.toggleNavbar} className="mr-2"/>
                        <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
                            <Nav className="ms-auto" navbar>
                                <NavItem>
                                    <NavLink tag={Link} to="/">Home</NavLink>
                                </NavItem>
                                <UncontrolledDropdown inNavbar nav>
                                    <DropdownToggle nav caret>Database</DropdownToggle>
                                    <DropdownMenu>
                                        <DropdownItem tag={Link} to="/database/items">
                                            Items
                                        </DropdownItem>
                                    </DropdownMenu>
                                </UncontrolledDropdown>
                            </Nav>
                        </Collapse>
                    </Container>
                </Navbar>
            </header>
        );
    }
}
