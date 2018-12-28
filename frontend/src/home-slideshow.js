import React from 'react';
import { Slide } from 'react-slideshow-image';
 
const slideImages = [
  'images/img1.jpg',
  'images/img2.jpg',
  'images/img3.jpg'
];
 
const properties = { 
  duration: 5000,
  transitionDuration: 500,
  infinite: true,
  indicators: true,
  arrows: true
}
 
export class Slideshow extends React.Component  {
    render() {
        return (
        <Slide {...properties}>
            <div className="each-slide">
            <div style={{'backgroundImage': `url(${slideImages[0]})`}}>
                <span>Slide 1</span>
            </div>
            </div>
            <div className="each-slide">
            <div style={{'backgroundImage': `url(${slideImages[1]})`}}>
                <span>Slide 2</span>
            </div>
            </div>
            <div className="each-slide">
            <div style={{'backgroundImage': `url(${slideImages[2]})`}}>
                <span>Slide 3</span>
            </div>
            </div>
        </Slide>
        )
    }
}