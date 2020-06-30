import React from 'react';

const ColorIndicator = ({ backgroundColor }) => {
  const customStyle = {
    padding: '10px',
    borderRadius: '10px',
    backgroundColor,
    content: ''
  }

  return (<span style={customStyle}></span>);
}
 
export default ColorIndicator;