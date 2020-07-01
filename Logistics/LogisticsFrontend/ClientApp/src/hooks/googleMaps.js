import useScript from './script';

const defaultLibraries = ['geometry', 'visualization', 'places'];
/**
 * generates google maps url api given an apiKey, libraries and mode
 * @param {string} apiKey
 * @param {string[]} libraries
 * @param {boolean} interactive
 */
const getUrl = (apiKey = 'API_KEY', libraries) => {
  const baseMapUrl = 'https://maps.googleapis.com/maps/api';
  const librariesParam = libraries.length ? `&libraries=${libraries}` : '';
  return `${baseMapUrl}/js?key=${apiKey}${librariesParam}`;
};

export const useGoogleMaps = (apiKey, libraries) => useScript(getUrl(apiKey, libraries));

export default () => useGoogleMaps('API_KEY', defaultLibraries);
