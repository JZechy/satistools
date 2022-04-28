import {Component} from "react";

export class ItemDetail extends Component<any, any> {
    constructor(props: any) {
        super(props);
    }
    
    render(): JSX.Element {
        return <h1>{this.props.id}</h1>;
    }
}
