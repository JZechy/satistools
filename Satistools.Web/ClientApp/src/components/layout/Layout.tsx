import {Component} from 'react';
import {Container} from 'reactstrap';
import {NavMenu} from './NavMenu';

export class Layout extends Component<any, any> {
    static displayName: string = Layout.name;

    render(): JSX.Element {
        return (
            <div>
                <NavMenu/>
                <Container>
                    {this.props.children}
                </Container>
            </div>
        );
    }
}
