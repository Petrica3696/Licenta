import React from 'react';
import './add-product.scss';
import { Button, FormControl, HelpBlock, FormGroup, ControlLabel } from 'react-bootstrap';
import { Sidebar } from '../../sidebar/products-sidebar';

function FieldGroup({ id, label, help, ...props }) {
  return (
    <FormGroup controlId={id}>
      <ControlLabel>{label}</ControlLabel>
      <FormControl {...props} />
      {help && <HelpBlock>{help}</HelpBlock>}
    </FormGroup>
  );
}

class AddProduct extends React.Component {
  render() {
    return (
      <div className="products-informations">
        <div className="sidebar">
          <Sidebar />
        </div>
        <div className="add-product">
          <h1>Add product</h1>

          <form>
            <FieldGroup
              id="formControlsText"
              type="text"
              label="Product name"
              placeholder="Enter text"
            />

            <FieldGroup
              id="formControlsText"
              type="text"
              label="Start price"
              placeholder="Enter text"
            />

            <FormGroup controlId="formControlsSelect">
              <ControlLabel>Select category</ControlLabel>
              <FormControl componentClass="select" placeholder="select">
                <option value="select">Electronics</option>
                <option value="select">Buildings</option>
                <option value="select">Arts</option>
                <option value="other">...</option>
              </FormControl>
            </FormGroup>

            <FormGroup controlId="formControlsTextarea">
              <ControlLabel>Description</ControlLabel>
              <FormControl componentClass="textarea" placeholder="Description.." />
            </FormGroup>

            <FieldGroup
              id="formControlsFile"
              type="file"
              label="File"
              help="Example block-level help text here."
            />

            <Button bsStyle="primary">Add product</Button>
          </form>
        </div>
      </div>
    )
  }
}
export default AddProduct;