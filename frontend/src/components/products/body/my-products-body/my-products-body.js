import React from 'react';
import './products-body.scss';
import MyProductsCard from '../../card/my-products-card/my-products-card';

import { Button, Col, Thumbnail, Grid, Row } from 'react-bootstrap';

export class Body extends React.Component {
	render() {
		return (
			<Grid>
          <Row>
            <MyProductsCard />
            <MyProductsCard />
            <MyProductsCard />           
          </Row>
          <Row>
            <MyProductsCard />
            <MyProductsCard />
            <MyProductsCard />  
          </Row>
          <Row>
            <MyProductsCard />
            <MyProductsCard />
            <MyProductsCard />  
          </Row>
        </Grid>
		)
	}
}