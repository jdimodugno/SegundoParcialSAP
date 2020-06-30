import React, { useState, useRef, useEffect } from 'react';
import { useGoogleMaps } from '../../hooks';
import { generateLayer, generateGeoJson } from '../../helpers/mapHelpers';
import { fetchGeoJSON } from '../../utils/apiCalls';
import './Map.css';
import googleMaps from '../../hooks/googleMaps';

const Map = ({
  nodes
}) => {
  const [gmapLoaded] = useGoogleMaps();
  const [map, setMap] = useState(null);
  const target = useRef();

  useEffect(() => {
    if (target.current && gmapLoaded) {
      const gmap = new window.google.maps.Map(
        target.current,
        {
          mapTypeId: window.google.maps.MapTypeId.ROADMAP,
          zoom: 4,
          center: {
            lat: -34.61315,
            lng: -58.37723
          },
        },
      );
      setMap(gmap);
    }
  }, [target, gmapLoaded]);

  useEffect(() => {
    if (map) generateLayer(nodes, map);
  }, [map])

  return (
    <div ref={target} id="logistics_map" />
  );
};

export default Map;