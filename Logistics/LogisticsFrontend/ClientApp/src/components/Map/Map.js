import React, { useCallback,useState, useRef, useEffect } from 'react';
import { useGoogleMaps } from '../../hooks';
import { generateLayer, generateMultipleLayer } from '../../helpers/mapHelpers';
import './Map.css';

const Map = ({
  nodes = null,
  route = false,
  routes = null,
  segment = null,
}) => {
  const [gmapLoaded] = useGoogleMaps();
  const [map, setMap] = useState(null);
  const [currentLayer, setCurrentLayer] = useState(null);
  const [currentOriginMarker, setCurrentOriginMarker] = useState(null);
  const [currentSegmentLayer, setCurrentSegmentLayer] = useState(null);
  const target = useRef();

  const updateMapFromNodes = useCallback(
    () => {
      if (currentOriginMarker && currentLayer) {
        currentOriginMarker.unbind();
        currentLayer.unbind();
      }
      if (currentSegmentLayer) currentSegmentLayer.unbind();
      const [originMarker, mainLayer, segmentLayer] = generateLayer(nodes, segment, map, { route, fit: true });
      setCurrentLayer(mainLayer);
      setCurrentOriginMarker(originMarker);
      setCurrentSegmentLayer(segmentLayer);
    },
    [map, nodes],
  )

  const updateMapFromRoutes = useCallback(
    () => {
      generateMultipleLayer(routes, map);
    },
    [map, routes],
  )

  useEffect(() => {
    if (target.current && gmapLoaded) {
      const gmap = new window.google.maps.Map(
        target.current,
        {
          mapTypeId: window.google.maps.MapTypeId.ROADMAP,
          zoom: 0,
          center: {
            lat: -34.61315,
            lng: -58.37723
          },
          zoomControl: false,
          mapTypeControl: false,
          scaleControl: false,
          streetViewControl: false,
          rotateControl: false,
          fullscreenControl: false,
        },
      );
      setMap(gmap);
    }
  }, [target, gmapLoaded]);
  
  useEffect(() => {
    if (map) {
      if (nodes) updateMapFromNodes();
      if (routes) updateMapFromRoutes();
    }
  }, [nodes, routes, map])

  return (
    <div ref={target} id="logistics_map" />
  );
};

export default Map;