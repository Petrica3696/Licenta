import React from 'react';
import './preferences.scss';
import img from '../../images/img.jpeg';


import { Image, Col, Grid, Row } from 'react-bootstrap';

export class Preferences extends React.Component {
	render() {
		return (
			<Grid>
				<Row class = "row">
					<Col xs={6} md={4} class="col">
						<Image src={img} circle />
						<span>Prod1</span>
					</Col>
					<Col xs={6} md={4}>
						<Image src={img} circle />
						<span>Prod2</span>
					</Col>
					<Col xs={6} md={4}>
						<Image src={img} circle />
						<span>Prod3</span>
					</Col>
				</Row>
			</Grid>
		)
	}
}