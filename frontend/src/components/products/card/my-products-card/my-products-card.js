import React from 'react';
import './my-products-card.scss';
import img from '../../../../images/img.jpeg';
import { Button, Col, Thumbnail } from 'react-bootstrap';

class MyProductCard extends React.Component {
  render() {
    return (
      <Col xs={6} md={4}>
        <Thumbnail src={img} alt="242x200">
          <div className="product-details">
            <h3>Product name</h3>
            <div className="time-and-bid">
              <p className="time-left">Time left: 00:30 min</p>
              <p className="current-bid-card">Current bid: 1$</p>
            </div>
            <p>
              <Button bsStyle="primary" href="/card-info">Edit</Button>
              &nbsp;
              <Button bsStyle="default">Delete</Button>
            </p>
          </div>
        </Thumbnail>
      </Col>
    )
  }
}
export default MyProductCard;