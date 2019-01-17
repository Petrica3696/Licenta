import React from 'react';
import { render } from 'react-dom';
import ReactDom from 'react-dom';
import { Provider } from 'react-redux';

import { store } from './_helpers';
import {App} from './containers/App';

import * as serviceWorker from './serviceWorker';

import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap/dist/css/bootstrap-theme.css'; 

import './index.scss';


//setup fake backend
// import { configureFakeBackend } from './_helpers/fake-backend';
// configureFakeBackend();

ReactDom.render(
    <Provider store={store}>
        <App />
    </Provider>,
    document.getElementById('root') 
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: http://bit.ly/CRA-PWA
serviceWorker.unregister();
