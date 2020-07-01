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

const nodesToFeature = (nodes, label) => ({
  type: 'Feature',
  properties: {
    label,
  },
  geometry: {
    type: 'LineString',
    coordinates: nodes.map(({ longitude, latitude }) => ([
      longitude,
      latitude
    ]))
  }
})

export const generateGeoJson = (nodes, { route, markers, label = null }) => {
  let geoJSON = {
    type: 'FeatureCollection',
    features: []
  };

  if (route) geoJSON.features = [...(geoJSON.features), nodesToFeature(nodes, label)];

  if (markers) {
    geoJSON.features = [
      ...(geoJSON.features),
      ...(nodes.slice((route ? 1 : 0), nodes.length).map(node => nodeToFeature(node)))
    ]
  }

  return geoJSON;
};

const fitMapBounds = (nodes, map) => {
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
  map.fitBounds(bounds);
}

export const generateLayer = (nodes, segment, map, options) => {
  if (!nodes || !map || !window.google) return null;
  
  const { color, route, fit, label } = options;

  let segmentLayer = null;
  // initialize style
  const mainLayer = new window.google.maps.Data({ 
    style: {
      strokeColor: color,
      strokeWeight: 5,
      zIndex: 10,
      icon: RedPin,
      visible: true 
    } 
  });


  const mainLayerGeoJSON = generateGeoJson(nodes, { route, markers: true, label});
  mainLayer.addGeoJson(mainLayerGeoJSON);
  mainLayer.setMap(map);

  if (segment) {
    segmentLayer = new window.google.maps.Data({ 
      style: { 
        strokeColor: '#ffffff',
        strokeWeight: 2,
        zIndex: 11,
        visible: true 
      } 
    });
    const segmentLayerGeoJSON = generateGeoJson(segment, { route, markers: false, label });
    segmentLayer.addGeoJson(segmentLayerGeoJSON);
    segmentLayer.setMap(map);
  }

  const { latitude, longitude } = nodes[0];

  const originMarker = new window.google.maps.Marker({
    position: { lat: latitude, lng: longitude },
    icon: BluePin,
    zIndex: route ? 11 : 10,
    map,
  })

  const infoWindow = new window.google.maps.InfoWindow({
    content: label,
  });

  mainLayer.addListener('click', () => {
    infoWindow.open(map, originMarker);
  }); 

  mainLayer.unbind = () => { mainLayer.setMap(null) };
  originMarker.unbind = () => { originMarker.setMap(null) };

  if (segmentLayer) segmentLayer.unbind = () => { segmentLayer.setMap(null) };
  if (fit) fitMapBounds(nodes, map);

  return [originMarker, mainLayer, segmentLayer];
};

export const generateMultipleLayer = (routes, map) => {
  let nodes = [];
  routes.map(r => {
    nodes = [...nodes, ...r.nodes];
    generateLayer(r.nodes, r.segment, map, { route: true, color: r.color, fit: false, label: r.label })
  });

  fitMapBounds(nodes, map);
}