import React from "react";
import { Route, Switch, BrowserRouter } from "react-router-dom";
import Home from './containers/Home';
import Products from './containers/Products';
import Login from './containers/Login';
import Register from './containers/Register';
import CardInformations from './components/products/card-informations/card-informations';
import MyProductsBody from './components/products/body/my-products-body/my-products-body';
import AddProduct from './components/products/body/add-product/add-product';
import MyAuctions from './components/products/body/my-auctions/my-auctions';

export default () =>
  <BrowserRouter>
    <Switch>
      <Route path="/" exact component={Home} />
      <Route path="/home" exact component={Home} />
      <Route path="/products" exact component={Products} />
      <Route path="/login" exact component={Login} />
      <Route path="/register" exact component={Register} />
      <Route path="/card-info" exact component={CardInformations} />
      <Route path='/my-products-body' exact component={MyProductsBody} />
      <Route path='/add-product' exact component={AddProduct} />
      <Route path='/my-auctions' exact component={MyAuctions} />
    </Switch>
  </BrowserRouter>