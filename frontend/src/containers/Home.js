import React, { Component } from 'react';
import './Home.scss';
import { Slideshow } from '../components/home-slideshow/home-slideshow';
import { Preferences } from '../components/preferences/preferences';

class Home extends Component {
  render() {
    return (
      <div className="home">
        <Slideshow />
        <Preferences />
        
      </div>
    );
  }
}
export default Home;