import React from 'react';
import './products-body.scss';
import img from '../../../images/img.jpeg';
import Card from '../card/products-card';

import { Button, Col, Thumbnail, Grid, Row } from 'react-bootstrap';

export class Body extends React.Component {
	render() {
		return (
			<Grid>
          <Row>
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
          </Row>
        </Grid>
		)
	}
}