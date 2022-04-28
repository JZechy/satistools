import {Component} from 'react';

type Forecast = {
    date: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}

type FetchDataState = {
    forecasts: Forecast[];
    loading: boolean;
}

export class FetchData extends Component<any, FetchDataState> {
    static displayName: string = FetchData.name;

    constructor(props: any) {
        super(props);
        this.state = {forecasts: [], loading: true};
    }

    async componentDidMount(): Promise<void> {
        await this.populateWeatherData();
    }

    static renderForecastsTable(forecasts: any): JSX.Element {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                <tr>
                    <th>Date</th>
                    <th>Temp. (C)</th>
                    <th>Temp. (F)</th>
                    <th>Summary</th>
                </tr>
                </thead>
                <tbody>
                {forecasts.map((forecast: any) =>
                    <tr key={forecast.date}>
                        <td>{forecast.date}</td>
                        <td>{forecast.temperatureC}</td>
                        <td>{forecast.temperatureF}</td>
                        <td>{forecast.summary}</td>
                    </tr>
                )}
                </tbody>
            </table>
        );
    }

    render(): JSX.Element {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchData.renderForecastsTable(this.state.forecasts);

        return (
            <div>
                <h1 id="tabelLabel">Weather forecast</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populateWeatherData(): Promise<void> {
        const response = await fetch('weatherforecast');
        const data = await response.json();
        this.setState({forecasts: data, loading: false});
    }
}
