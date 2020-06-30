import React, { useCallback, useState, useEffect, useContext } from 'react';
import { Table, Badge } from 'reactstrap';
import { fetchVehicleByLicense, fetchRouteById } from '../../utils/apiCalls';
import { GlobalContext } from '../../context/GlobalContext';
import moment from 'moment';
import './VehicleShippings.css';
import Map from '../Map/Map';

const VehicleShippings = ({
  match
}) => {
  const { shippingStatuses, nodesAsObject } = useContext(GlobalContext);
  const [vehicle, setVehicle] = useState(null);
  const [vehicleShippings, setVehicleShippings] = useState(null);
  const [route, setRoute] = useState(null);
  const [shippingCurrentSegment, setShippingCurrentSegment] = useState(null);
  
  const updateRoute = useCallback(
    (routeId) => {
      fetchRouteById(routeId)
        .then(({ detail, distance, routeNodes }) => {
          setRoute({
            detail,
            distance,
            nodes: routeNodes
              .sort((a, b) => a.order - b.order)
              .map(({ nodeId, order }) => ({ ...nodesAsObject[nodeId], order }))
          });
        })
    }, [nodesAsObject],
  )

  const getColor = (status) => {
    if (status === 0) return 'secondary';
    if (status === 1) return 'success';
    if (status === 2) return 'info';
  }

  useEffect(() => {
    if (shippingStatuses) {
      const { params: { licensePlate } } = match;
      fetchVehicleByLicense(licensePlate)
        .then(({ licensePlate, model, year, shippings }) => {
          setVehicle({ licensePlate, model, year });
          setVehicleShippings(
            shippings.map(({
              id,
              dateScheduled,
              dateCompleted,
              currentSegment,
              routeId,
              status
            }) => ({
              id,
              dateScheduled,
              status,
              statusLabel: shippingStatuses[status],
              routeId,
              dateCompleted,
              currentSegment,
            })).sort((a, b) => new Date(b.dateScheduled) - new Date(a.dateScheduled))
          )
        })
    }
  }, [])

  return (
    <>
      {
        !!vehicle && (
          <h1>
            {vehicle.licensePlate}
            <br /> 
            Modelo: <b>{vehicle.model}</b> | Año: <b>{vehicle.year}</b>
          </h1>
        )
      }
      {
        vehicleShippings && vehicleShippings.length && (
          <Table hover>
            <thead>
              <tr>
                <th>Fecha Programada</th>
                <th>Fecha Fin</th>
                <th>Estado</th>
                <th>Ruta</th>
                <th>Tramo Actual</th>
              </tr>
            </thead>
            <tbody>
              { 
                !!vehicleShippings && (
                  !!vehicleShippings.length ? vehicleShippings.map(({
                    id,
                    dateScheduled,
                    status,
                    statusLabel,
                    dateCompleted,
                    currentSegment,
                    routeId,
                  }) => (
                    <tr key={id}>
                      <td>{ moment(dateScheduled).format('DD/MM/YYYY, h:mm:ss a') }</td>
                      <td>{ dateCompleted ? moment(dateCompleted).format('DD/MM/YYYY, h:mm:ss a') : '' }</td>
                      <td>
                        {
                          <Badge color={getColor(status)}>{ statusLabel }</Badge>
                        }
                      </td>
                      <td>
                        <Badge onClick={() => {
                          if (currentSegment) {
                            const originNode = nodesAsObject[currentSegment.originId];
                            const destinationNode = nodesAsObject[currentSegment.destinationId];
                            setShippingCurrentSegment([originNode, destinationNode])
                          } else setShippingCurrentSegment(null);
                          updateRoute(routeId);
                        }}>Ver</Badge>
                      </td>
                      <td>{ currentSegment ? currentSegment.segmentIdentifierName : '' }</td>
                    </tr>
                  )) : (
                    <tr>
                      <td>No se encontraron viajes</td>
                    </tr>
                  )
                )
              }
            </tbody>
          </Table>
        )
      }
      {
        !!route && (
          <>
            <h1>{route.detail}</h1>
            <Map
              nodes={route.nodes}
              segment={shippingCurrentSegment}
              route={true}
            />
          </>
        ) 
      }
    </>
  );
}
 
export default VehicleShippings;