import React from 'react';
import './my-products-body.scss';
import MyProductsCard from '../../card/my-products-card/my-products-card';
import { Sidebar } from '../../sidebar/products-sidebar';

import { Button, Col, Thumbnail, Grid, Row } from 'react-bootstrap';

class MyProductsBody extends React.Component {
	render() {
		return (
      <div className="products-informations">
        <div className="sidebar">
            <Sidebar />
          </div>
        <div className="my-products">
          <Grid>
              <Row>
                <MyProductsCard />
                <MyProductsCard />
                <MyProductsCard />           
              </Row>
              <Row>
                <MyProductsCard />
                <MyProductsCard />
                <MyProductsCard />  
              </Row>
              <Row>
                <MyProductsCard />
                <MyProductsCard />
                <MyProductsCard />  
              </Row>
            </Grid>
          </div>
        </div>
		)
	}
}
export default MyProductsBody;