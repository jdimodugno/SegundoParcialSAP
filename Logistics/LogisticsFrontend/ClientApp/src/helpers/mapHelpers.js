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

export const generateGeoJson = (nodes) => ({
  type: 'FeatureCollection',
  features: [
    {
      type: 'Feature',
      properties: {},
      geometry: {
        type: 'LineString',
        coordinates: nodes.map(({ longitude, latitude }) => ([
          longitude,
          latitude
        ]))
      }
    },
    ...(nodes.slice(1, nodes.length - 1).map(node => nodeToFeature(node)))
  ]
});

export const generateLayer = (nodes, map) => {
  if (!nodes || !map || !window.google) return null;
  // initialize style
  const layer = new window.google.maps.Data({ style: { 
    strokeWeight: 3,
    zIndex: 10,
    icon: RedPin,
    visible: true } });

  const geoJSON = generateGeoJson(nodes);
  layer.addGeoJson(geoJSON);
  layer.setMap(map);

  const { latitude, longitude } = nodes[0];

  new window.google.maps.Marker({
    position: { lat: latitude, lng: longitude },
    icon: BluePin,
    zIndex: 10,
    map,
  })

  return layer;
};