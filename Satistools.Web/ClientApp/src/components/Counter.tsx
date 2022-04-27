import {Component} from 'react';

type CounterState = {
    currentCount: number;
}

export class Counter extends Component<any, CounterState> {
    static displayName = Counter.name;

    constructor(props: any) {
        super(props);
        this.state = {currentCount: 0};
        this.incrementCounter = this.incrementCounter.bind(this);
    }

    incrementCounter(): void {
        this.setState({
            currentCount: this.state.currentCount + 1
        });
    }

    render(): JSX.Element {
        return (
            <div>
                <h1>Counter</h1>

                <p>This is a simple example of a React component.</p>

                <p aria-live="polite">Current count: <strong>{this.state.currentCount}</strong></p>

                <button className="btn btn-primary" onClick={this.incrementCounter}>Increment</button>
            </div>
        );
    }
}
