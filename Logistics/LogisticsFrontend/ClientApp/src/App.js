import React, { useContext, useEffect } from 'react';
import { Route } from 'react-router';
import { Spinner } from 'reactstrap';
import Layout from './layout/Main';
import { GlobalContext } from './context/GlobalContext';
import Locations from './components/Locations/Locations';
import Vehicles from './components/Vehicles/Vehicles';
import { fetchNodes, fetchVehicles, fetchShippingStatuses } from './utils/apiCalls';

import VehicleShippings from './components/VehicleShippings/VehicleShippings';
import RouteCalculation from './components/RouteCalculation/RouteCalculation';

import './Global.css'

const App = () => {
  const { loading, setNodes, setVehicles, setShippingStatuses } = useContext(GlobalContext);

  useEffect(() => {
    fetchNodes()
      .then(nodes => {
        setNodes(nodes);
      });

    fetchVehicles()
      .then(vehicles => {
        setVehicles(vehicles);
      });

    fetchShippingStatuses()
      .then(statuses => {
        setShippingStatuses(statuses);
      });
  }, []);
  
  return (
    <Layout>
      {
        loading ? (
          <Spinner type="grow" color="primary" />
        ) : (
          <>
            <Route exact path='/' component={Locations} />
            <Route path='/vehicles' component={Vehicles} />
            <Route path='/shippings/:licensePlate' component={VehicleShippings} />
            <Route path='/routecalculation' component={RouteCalculation} />
          </>
        )
      }
    </Layout>
  )
};

App.displayName = 'App';

export default App;