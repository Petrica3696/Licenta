import React, { Component } from 'react';
import './Register.scss';
import { Panel, FormGroup, ControlLabel, FormControl, HelpBlock, Button } from 'react-bootstrap';

function FieldGroup({ id, label, help, ...props }) {
  return (
    <FormGroup controlId={id}>
      <ControlLabel>{label}</ControlLabel>
      <FormControl {...props} />
      {help && <HelpBlock>{help}</HelpBlock>}
    </FormGroup>
  );
} 

class Register extends Component {

  render() {
    return (
      <div className="register">

        <Panel bsStyle="primary">
          <Panel.Heading className="panelHeader">Register</Panel.Heading>
          <Panel.Body className="panelBody">

            <form>
              <FieldGroup
                id="formControlsText"
                type="text"
                label="Username"
              />
              <FieldGroup
                id="formControlsEmail"
                type="email"
                label="Email address"
              />
              <FieldGroup id="formControlsPassword" label="Password" type="password" />
              <FieldGroup id="formControlsPasswordConfirm" label="Confirm Password" type="password" />

              <Button type="submit">Submit</Button>
            </form>

          </Panel.Body>
        </Panel>

      </div>
    );
  }
}

export default Register;