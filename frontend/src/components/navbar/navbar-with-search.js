import React from 'react';

import './navbar-with-search.scss';

import { Navbar, Nav, NavItem, FormGroup, FormControl, Button } from 'react-bootstrap';

export class NavbarWithSearch extends React.Component {
	render() {
		return (
			<div className="navbar-with-search">
				<Navbar inverse collapseOnSelect className="navbar">
					<Navbar.Header>
						<Navbar.Brand> 
							<a href="/home">Auction Portal</a>
						</Navbar.Brand>
					</Navbar.Header>
					<Nav pullLeft>
						<NavItem eventKey={1} href="/home">Home</NavItem>
						<NavItem eventKey={2} href="/products">Products</NavItem>
						<NavItem eventKey={3} href="/login">Categories</NavItem>
						<NavItem eventKey={4} href="/register">Contact</NavItem>
						<NavItem eventKey={5} href="/my-profile">My Profile</NavItem>
					</Nav>
					<Navbar.Form pullRight>
						<FormGroup>
							<FormControl type="text" placeholder="Search" />
						</FormGroup>{' '}
						<Button type="submit">Submit</Button>{' . . . . .'}
							<Button bsStyle="primary" href="/login">Login</Button>{' '}
							<Button bsStyle="primary" href="/register">Register</Button>
					</Navbar.Form>
				</Navbar>

			</div>
		);
	}
}
