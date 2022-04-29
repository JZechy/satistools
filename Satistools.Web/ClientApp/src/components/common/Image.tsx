import {Component} from "react";

type ImageProps = {
    name: string;
    size: number;
    alt: string;
}

export class Image extends Component<ImageProps> {
    render(): JSX.Element {
        let src = "img/"+this.props.name+".png";
        
        return <img src={src} width={this.props.size} alt={this.props.alt}/>;
    }
}