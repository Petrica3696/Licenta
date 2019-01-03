import React from 'react';
import './card-informations.scss';
import img from '../../../images/img.jpeg';
import { Carousel, FormControl, FormGroup, InputGroup, Button } from 'react-bootstrap';

class CardInformations extends React.Component {
  render() {
    return (
      <div className="card-informations">

        <div className="images">
          <Carousel>
            <Carousel.Item>
              <img width={900} height={500} alt="900x500" src={img} />
            </Carousel.Item>
            <Carousel.Item>
              <img width={900} height={500} alt="900x500" src={img} />
            </Carousel.Item>
            <Carousel.Item>
              <img width={900} height={500} alt="900x500" src={img} />
            </Carousel.Item>
          </Carousel>
        </div>

        <div className="info">
          <div className="name">Product name</div>
          <div className="timer">Time left: 00:30 min</div>

          <div className="bid-details">
            <div class="current-bid">Current bid: 1$</div>
            <div className="place-bid">
              <FormGroup>
                <InputGroup>
                  <InputGroup.Button>
                    <Button>Place bid</Button>
                  </InputGroup.Button>
                  <FormControl type="text" />
                </InputGroup>
              </FormGroup>
              <span className="min-text">Enter minimum 0.1$</span>
            </div>
          </div>

          <div className="description">
            <p className="description-title">Description</p>
            <span>
              Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
            </span>
          </div>

        </div>
      </div>
    )
  }
}
export default CardInformations;