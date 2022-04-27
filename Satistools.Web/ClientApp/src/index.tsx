import 'bootstrap/dist/css/bootstrap.css';
import ReactDOM from 'react-dom';
import {BrowserRouter} from 'react-router-dom';
import App from './App';
// @ts-ignore
import * as serviceWorkerRegistration from './serviceWorkerRegistration';

// TODO: getAttribute return string | null, but basename accepts string | undefined. wtf?
let baseUrl: any = document.getElementsByTagName('base')[0].getAttribute('href');
let rootElement: HTMLElement | null = document.getElementById('root');


ReactDOM.render(
    <BrowserRouter basename={baseUrl}>
        <App/>
    </BrowserRouter>,
    rootElement);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://cra.link/PWA
serviceWorkerRegistration.unregister();