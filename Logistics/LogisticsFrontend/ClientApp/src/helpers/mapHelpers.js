import RedPin from '../assets/red-pin.svg';
import BluePin from '../assets/blue-pin.svg';

const nodeToFeature = ({ latitude, longitude }) => ({
  type: 'Feature',
  properties: {},
  geometry: {
    type: 'Point',
    coordinates: [
      longitude,
      latitude
    ]
  }
});

const nodesToFeature = (nodes) => ({
  type: 'Feature',
  properties: {},
  geometry: {
    type: 'LineString',
    coordinates: nodes.map(({ longitude, latitude }) => ([
      longitude,
      latitude
    ]))
  }
})

export const generateGeoJson = (nodes, { route, markers}) => {
  let geoJSON = {
    type: 'FeatureCollection',
    features: []
  };

  if (route) geoJSON.features = [...(geoJSON.features), nodesToFeature(nodes)];

  if (markers) {
    geoJSON.features = [
      ...(geoJSON.features),
      ...(nodes.slice((route ? 1 : 0), nodes.length - 1).map(node => nodeToFeature(node)))
    ]
  }

  return geoJSON;
};

export const generateLayer = (nodes, route, segment, map) => {
  if (!nodes || !map || !window.google) return null;
  
  const latSet = Array.from(new Set(nodes.map(node=> node.latitude)));
  const lngSet = Array.from(new Set(nodes.map(node=> node.longitude)));

  const minLat = Math.min(...latSet);
  const maxLat = Math.max(...latSet);
  const minLng = Math.min(...lngSet);
  const maxLng = Math.max(...lngSet);

  const bounds = new window.google.maps.LatLngBounds(
    new window.google.maps.LatLng(minLat, minLng),
    new window.google.maps.LatLng(maxLat, maxLng),
  );

  let segmentLayer = null;
  // initialize style
  const mainLayer = new window.google.maps.Data({ 
    style: { 
      strokeWeight: 5,
      zIndex: 10,
      icon: RedPin,
      visible: true 
    } 
  });


  const mainLayerGeoJSON = generateGeoJson(nodes, { route, markers: true });
  mainLayer.addGeoJson(mainLayerGeoJSON);
  mainLayer.setMap(map);

  if (segment) {
    segmentLayer = new window.google.maps.Data({ 
      style: { 
        strokeColor: '#AAEEBB',
        strokeWeight: 3,
        zIndex: 11,
        visible: true 
      } 
    });
    const segmentLayerGeoJSON = generateGeoJson(segment, { route, markers: false });
    segmentLayer.addGeoJson(segmentLayerGeoJSON);
    segmentLayer.setMap(map);
  }

  const { latitude, longitude } = nodes[0];

  const originMarker = new window.google.maps.Marker({
    position: { lat: latitude, lng: longitude },
    icon: BluePin,
    zIndex: 10,
    map,
  })

  mainLayer.unbind = () => { mainLayer.setMap(null) };
  originMarker.unbind = () => { originMarker.setMap(null) };
  if (segmentLayer) segmentLayer.unbind = () => { segmentLayer.setMap(null) };

  map.fitBounds(bounds);

  return [originMarker, mainLayer, segmentLayer];
};