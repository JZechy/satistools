import {Component} from 'react';

export class Home extends Component {
    static displayName: string = Home.name;

    render(): JSX.Element {
        return (
            <div>
                <h1>Welcome!</h1>
                <p>This your new personal satisfactory web application.</p>
            </div>
        );
    }
}
