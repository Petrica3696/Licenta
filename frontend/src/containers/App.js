import React, { Component } from 'react';
import './App.scss';
import { NavbarWithSearch } from '../components/navbar/navbar-with-search';
import Routers from '../Routes';

class App extends Component {
  render() {
    return (
      <div className="App">
        <NavbarWithSearch />
        <Routers />
      </div>
    );
  }
}

export default App;
