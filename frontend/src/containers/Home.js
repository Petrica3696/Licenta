import React, { Component } from 'react';
import './Home.scss';
import { Slideshow } from '../components/home-slideshow/home-slideshow';
import { Preferences } from '../components/preferences/preferences';

class Home extends Component {

  render() {
    return (
      <div className="home">
      
        <div className="slideshow">
          <Slideshow />
        </div>

        <div className="preferences">
          <Preferences />
        </div>
        
      </div>
    );
  }
}
export default Home;