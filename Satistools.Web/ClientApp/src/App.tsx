import {Component} from 'react';
import {Route} from 'react-router';
import {Layout} from './components/layout/Layout';
import {Home} from './pages/Home';
import {Items} from "./components/database/items/Items";
import {ItemDetail} from "./components/database/items/ItemDetail";

export default class App extends Component {
    static displayName: string = App.name;

    render(): JSX.Element {
        return (
            <Layout>
                <Route exact path='/' component={Home}/>
                <Route exact path='/database/items' component={Items}/>
                <Route exact path='/database/items/:itemId' render={(props: any) => <ItemDetail id={props.match.params.itemId}/>}/>
            </Layout>
        );
    }
}
