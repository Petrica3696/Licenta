import React, { Component } from 'react';
import './Products.scss';
import { Body } from '../components/products/body/all-products-body/products-body'
import { Sidebar } from '../components/products/sidebar/products-sidebar';

class Products extends Component {
  render() {
    return (
      <div className="products">

        <div className="products-informations">
          <div className="sidebar">
            <Sidebar />
          </div>
          <div className="body">
            <Body />
          </div>

        </div>

      </div>
    );
  }
}
export default Products;