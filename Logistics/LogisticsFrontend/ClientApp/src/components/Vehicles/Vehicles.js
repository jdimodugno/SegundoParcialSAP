import React, { useContext, useState, useEffect } from 'react';
import { GlobalContext } from '../../context/GlobalContext'
import { Table, Spinner, Badge } from 'reactstrap';
import { Link } from 'react-router-dom';
import { castStringToColor } from '../../helpers/miscHelpers';
import '../../Global.css';
import './Vehicles.css';
import ColorIndicator from '../ColorIndicator/ColorIndicator';
import Map from '../Map/Map';
import { fetchCurrentShippings } from '../../utils/apiCalls';

const Vehicles = () => {
  const { vehicles, nodesAsObject } = useContext(GlobalContext);
  const [currentShippings, setCurrentShippings] = useState(null)
  
  useEffect(() => {
    if (vehicles) {
      fetchCurrentShippings()
        .then((data) => {
          setCurrentShippings(
            data.map(
              ({ transportationVehicleLicensePlate, currentSegment, route: { detail, routeNodes }}) => {
                const originNode = nodesAsObject[currentSegment.originId];
                const destinationNode = nodesAsObject[currentSegment.destinationId];
                return ({
                  nodes: routeNodes
                    .sort((a, b) => a.order - b.order)
                    .map(({ nodeId, order }) => ({ ...nodesAsObject[nodeId], order })),
                  segment: [originNode, destinationNode],
                  color: castStringToColor(transportationVehicleLicensePlate),
                  label: `Vehículo: ${transportationVehicleLicensePlate} | Ruta ${detail}`
                });
              }
            )
          );
        })
    }
  }, [vehicles]);

  return vehicles ? (
    <>
      <Table hover>
        <thead>
          <tr>
            <th>Patente</th>
            <th>Modelo</th>
            <th>Año</th>
            <th>Estado</th>
            <th>Indicador</th>
            <th>Acciones</th>
          </tr>
        </thead>
        <tbody>
          { 
            !!vehicles && (
              !!vehicles.length ? vehicles.map(({ licensePlate, model, year, available }) => (
                <tr key={licensePlate}>
                  <td>{ licensePlate }</td>
                  <td>{ model }</td>
                  <td>{ year }</td>
                  <td>
                    <Badge color={ available ? 'success' : 'danger'}>
                      { available ? 'Disponible' : 'No Disponible' }
                    </Badge>
                  </td>
                  <td>
                    <ColorIndicator backgroundColor={castStringToColor(licensePlate)} />
                  </td>
                  <td>
                    <Link to={`/shippings/${licensePlate}`}>
                      <Badge color="primary">Ver Viajes</Badge>
                    </Link>
                  </td>
                </tr>
              )) : (
                <tr>
                  <td>No se encontraron vehículos</td>
                </tr>
              )
            )
          }
        </tbody>
      </Table>
      {
        !!currentShippings && (
          <Map
            routes={currentShippings}
          />
        )
      }
    </>
  ) : (
    <Spinner type="grow" color="primary" /> 
  );
}
 
export default Vehicles;