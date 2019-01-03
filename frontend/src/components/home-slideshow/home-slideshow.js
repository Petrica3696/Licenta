import React from 'react';
import './home-slideshow.scss';
import { Carousel } from 'react-bootstrap';
import img1 from '../../images/img.jpeg';
import img2 from '../../images/img2.jpg';
import img3 from '../../images/img3.jpg';

export class Slideshow extends React.Component {
	render() {
		return (
			<div className="carousel">
				<Carousel>
					<Carousel.Item>
						<img width={900} height={500} alt="900x500" src={img3} />
					</Carousel.Item>
					<Carousel.Item>
						<img width={900} height={500} alt="900x500" src={img2} />
					</Carousel.Item>
					<Carousel.Item>
						<img width={900} height={500} alt="900x500" src={img3} />
					</Carousel.Item>
				</Carousel>
			</div>
		)
	}
}