import React, { Component } from 'react';
import './Products.scss';
import { NavbarWithSearch } from '../components/navbar/navbar-with-search';
import { Button, Col, Thumbnail, Grid, Row } from 'react-bootstrap';
import img from '../images/img.jpeg';
import { Body } from '../components/products/body/products-body';
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