import React from 'react';
import './card-informations.scss';
import img from '../../../images/img.jpeg';
import { Carousel, FormControl, FormGroup, InputGroup, Button } from 'react-bootstrap';
import { getProductById } from '../../../api/services/product-services';

class CardInformations extends React.Component {
  constructor(props) {
    super(props);

    this.state = { myObj: [], id: this.props.match.params.id };
  }

  componentDidMount() {
    getProductById(this.state.id, (data) => {
      this.setState({ myObj: data })
    });
  }

  render() {
    console.log("MyObj: ", this.state.myObj);
    const { name, deadline, description, startPrice } = this.state.myObj;
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
          <div className="name">{name}</div>
          <div className="timer">Time left: {deadline} </div>

          <div className="bid-details">
            <div className="current-bid">Current bid: {startPrice}$</div>
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
              {description}
            </span>
          </div>

        </div>
      </div>
    )
  }
}
export default CardInformations;