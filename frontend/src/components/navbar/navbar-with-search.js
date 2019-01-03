import React, { Component } from 'react';

import './navbar-with-search.scss';

import { Navbar, Nav, NavItem, MenuItem, NavDropdown, FormGroup, FormControl, Button } from 'react-bootstrap';
import Routes from '../../Routes';

export class NavbarWithSearch extends React.Component {
	render() {
		return (
			<div>
			<Navbar  inverse collapseOnSelect className="navbar">
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
				</Nav>
				<Nav pullRight>
					<Navbar.Form pullRight>
						<FormGroup>
							<FormControl type="text" placeholder="Search" />
						</FormGroup>{' '}
						<Button type="submit">Submit</Button>
					</Navbar.Form>
				</Nav>
			</Navbar>

			</div>
		);
	}
}
