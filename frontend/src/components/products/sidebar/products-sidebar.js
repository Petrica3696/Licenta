import React from 'react';
import './products-sidebar.scss';
import { Nav, NavItem } from 'react-bootstrap';


export class Sidebar extends React.Component {
	render() {
		return (
			<Nav bsStyle="pills" stacked activeKey={1}>
				<NavItem eventKey={1} href="/products">
					All products
				</NavItem>
				<NavItem eventKey={2} href="/my-products-body">
					My products
				</NavItem>
				<NavItem eventKey={3} href="/my-auctions">
					My auctions
				</NavItem>
				<NavItem eventKey={4} href="/add-product">
					Add product
				</NavItem>
			</Nav>
		)
	}
}