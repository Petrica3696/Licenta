import React from 'react';
import './home-slideshow.scss';
import { Carousel } from 'react-bootstrap';
import img1 from '../../images/img.jpeg';
import img2 from '../../images/img2.jpg';
import img3 from '../../images/img3.jpg';

export class Slideshow extends React.Component {
	render() {
		return (
				<Carousel className="image-carousel">
					<Carousel.Item>
						<img width={900} height={400} alt="900x400" src={img1} />
					</Carousel.Item>
					<Carousel.Item>
						<img width={900} height={400} alt="900x400" src={img2} />
					</Carousel.Item>
					<Carousel.Item>
						<img width={900} height={400} alt="900x400" src={img3} />
					</Carousel.Item>
				</Carousel>
		)
	}
}