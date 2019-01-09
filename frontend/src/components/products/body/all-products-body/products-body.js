import React from 'react';
import './products-body.scss';
import Card from '../../card/products-card/products-card';

import { getProducts } from '../../../../api/services/product-services';
import { Grid, Row } from 'react-bootstrap';

export class Body extends React.Component {
  constructor(props) {
    super(props);

    this.state = { myObj: [] };
  }

  componentDidMount() {
    getProducts(data => {
      this.setState({ myObj: data })
    });

  }

  render() {
    console.log("myData: ", this.state.myObj);
    return (
      <Grid>
        <Row>
          {
            Object.keys(this.state.myObj).map((index) => (
            <Card dataProduct={ this.state.myObj[index] }/>
            ))
          }
        </Row>
      </Grid>
    )
  }
}