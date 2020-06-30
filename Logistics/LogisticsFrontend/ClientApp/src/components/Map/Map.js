import React, { useCallback,useState, useRef, useEffect } from 'react';
import { useGoogleMaps } from '../../hooks';
import { generateLayer } from '../../helpers/mapHelpers';
import './Map.css';

const Map = ({
  nodes,
  route = false,
  segment = null,
}) => {
  const [gmapLoaded] = useGoogleMaps();
  const [map, setMap] = useState(null);
  const [currentLayer, setCurrentLayer] = useState(null);
  const [currentOriginMarker, setCurrentOriginMarker] = useState(null);
  const [currentSegmentLayer, setCurrentSegmentLayer] = useState(null);
  const target = useRef();

  const updateMap = useCallback(
    () => {
      if (currentOriginMarker && currentLayer) {
        currentOriginMarker.unbind();
        currentLayer.unbind();
      }
      if (currentSegmentLayer) currentSegmentLayer.unbind();
      const [originMarker, mainLayer, segmentLayer] = generateLayer(nodes, route, segment, map);
      setCurrentLayer(mainLayer);
      setCurrentOriginMarker(originMarker);
      setCurrentSegmentLayer(segmentLayer);
    },
    [map, nodes],
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
        },
      );
      setMap(gmap);
    }
  }, [target, gmapLoaded]);
  
  useEffect(() => {
    if (map) updateMap();
  }, [nodes, map])

  return (
    <div ref={target} id="logistics_map" />
  );
};

export default Map;