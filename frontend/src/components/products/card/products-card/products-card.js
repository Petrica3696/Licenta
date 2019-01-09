import React from 'react';
import './products-card.scss';
import img from '../../../../images/img.jpeg';
import { Button, Col, Thumbnail } from 'react-bootstrap';
import { Link } from 'react-router-dom';

class Card extends React.Component {
  constructor(props) {
    super(props);
    
  }
  render() {
    console.log("ce primesc?", this.props.dataProduct);
    const { name, deadline, finalPrice, startPrice } = this.props.dataProduct;
    return (
      <Col xs={6} md={4}>
        <Thumbnail src={img} alt="242x200">
          <div className="product-details">
            <h3>{name}</h3>
            <div className="time-and-bid">
              <p className="time-left">Time left: {deadline}</p>
              <p className="current-bid-card">Current bid: {startPrice}$</p>
            </div>
            <p>
              <Link to={"/card-info/"+this.props.dataProduct.id}>
                <Button bsStyle="primary">See details</Button>
              </Link>
              &nbsp;
              <Button bsStyle="default">Add to watch list</Button>
            </p>
          </div>
        </Thumbnail>
      </Col>
    )
  }
}
export default Card;