import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import {Slideshow} from './home-slideshow';

import { Slide } from 'react-slideshow-image';

import { Navbar, Nav, NavItem, MenuItem, NavDropdown, FormGroup, FormControl, Button } from 'react-bootstrap';

const slideImages = [
  'images/img1.jpg',
  'images/img2.jpg',
  'images/img3.jpg'
];
 
const properties = {
  duration: 5000,
  transitionDuration: 500,
  infinite: true,
  indicators: true,
  arrows: true
}

class App extends Component {
  render() {
    return (
      <div className="App">
        <Navbar>
          <Navbar.Header>
            <Navbar.Brand>
              <a href="#">Auction Portal</a>
            </Navbar.Brand>
          </Navbar.Header>
          <Nav className="navBar">
            <NavItem eventKey={1} href="#">Home</NavItem>
            <NavItem eventKey={2} href="#">Products</NavItem>
            <NavItem eventKey={3} href="#">Categories</NavItem>
            <NavItem eventKey={4} href="#">Contact</NavItem>
            <Navbar.Form pullLeft>
              <FormGroup>
                <FormControl type="text" placeholder="Search" />
              </FormGroup>{' '}
              <Button type="submit">Submit</Button>
            </Navbar.Form>
          </Nav>
        </Navbar>
        <header className="App-header">

          <Slide {...properties}>
            <div className="each-slide">
              <div style={{'backgroundImage': `url(${slideImages[0]})`}}>
                <span>Slide 1</span>
              </div>
            </div>
            <div className="each-slide">
              <div style={{'backgroundImage': `url(${slideImages[1]})`}}>
                <span>Slide 2</span>
              </div>
            </div>
            <div className="each-slide">
              <div style={{'backgroundImage': `url(${slideImages[2]})`}}>
                <span>Slide 3</span>
              </div>
            </div>
          </Slide>

        </header>
      </div>
    );
  }
}

export default App;
