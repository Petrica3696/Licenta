import React from 'react';
import './my-auctions.scss';
import Card from '../../card/products-card/products-card';

import { Grid, Row } from 'react-bootstrap';
import { Sidebar } from '../../sidebar/products-sidebar';

class MyAuctions extends React.Component {
  render() {
    return (
      <div className="products-informations">
        <div className="sidebar">
          <Sidebar />
        </div>

        <div className="my-auctions">
          <Grid>
            {/* <Row>
              <Card />
              <Card />
              <Card />
            </Row>
            <Row>
              <Card />
              <Card />
              <Card />
            </Row>
            <Row>
              <Card />
              <Card />
              <Card />
            </Row> */}
          </Grid>
        </div>
      </div>
    )
  }
}

export default MyAuctions;