import React, { Component } from 'react';
import './MyProfile.scss';
import { Col, Image, FormGroup, ControlLabel, FormControl, HelpBlock, Button } from 'react-bootstrap';

import { getProductById } from '../api/services/product-services';
import { getByUsername } from '../api/services/user-services';

function FieldGroup({ id, label, help, ...props }) {
  return (
    <FormGroup controlId={id}>
      <ControlLabel>{label}</ControlLabel>
      <FormControl {...props} />
      {help && <HelpBlock>{help}</HelpBlock>}
    </FormGroup>
  );
} 

class MyProfile extends Component {
  constructor(props) {
    super(props);

    this.state = { myObj: [] };
  }

  componentDidMount() {
    getByUsername('TestUser', (data) => {
      this.setState({ myObj: data })
    });
  }

  render() {
    console.log("works! ", this.state.myObj);
    const { firstName, lastName, username } = this.state.myObj;
    return (
      <div className="my-profile">
        <div className="profile-photo">
          <Col xs={6} md={4}>
            <Image src="/thumbnail.png" circle />
          </Col>
          <p>photo</p>
        </div>
        <div className="profile-informations">

          <div className="first-name">
            <form>
              <FieldGroup
                id="formControlsText"
                type="text"
                label="First Name"
                placeholder= {firstName}
              />
            </form>
          </div>
          
          <div className="last-name">
            <form>
              <FieldGroup
                id="formControlsText"
                type="text"
                label="Last Name"
                placeholder={lastName}
              />
            </form>
          </div>

          <div className="username">
            <form>
              <FieldGroup
                id="formControlsText"
                type="text"
                label="Username"
                placeholder={username}
              />
            </form>
          </div>
          <Button type="submit">Change</Button>
        </div>
      </div>
    );
  }
}

export default MyProfile;