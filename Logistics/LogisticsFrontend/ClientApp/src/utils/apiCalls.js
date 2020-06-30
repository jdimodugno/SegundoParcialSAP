import axios from 'axios';

export const fetchNodes = async () => {
  const res = await axios.get(`${process.env.REACT_APP_API_URL}/locations`);
  return res.data;
}

export const fetchShippingStatuses = async () => {
  const res = await axios.get(`${process.env.REACT_APP_API_URL}/shippings/statuses`);
  return res.data;
}

export const fetchVehicles = async () => {
  const res = await axios.get(`${process.env.REACT_APP_API_URL}/vehicles`);
  return res.data;
}

export const fetchVehicleByLicense = async (licencePlate) => {
  const res = await axios.get(`${process.env.REACT_APP_API_URL}/vehicles/${licencePlate}`);
  return res.data;
}

export const fetchRouteById = async (id) => {
  const res = await axios.get(`${process.env.REACT_APP_API_URL}/routes/${id}`);
  return res.data;
}

export const fetchShortestRoute = async (payload) => {
  const res = await axios.post(`${process.env.REACT_APP_API_URL}/routes/calculate`, payload);
  return res.data;
}