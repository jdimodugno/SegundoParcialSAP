import React, { useState, useEffect, useContext } from 'react';
import { Link } from 'react-router-dom';
import { Table, Badge } from 'reactstrap';
import { fetchVehicleByLicense } from '../../utils/apiCalls';
import { GlobalContext } from '../../context/GlobalContext';
import moment from 'moment';
import './VehicleShippings.css';

const VehicleShippings = ({
  match
}) => {
  const { shippingStatuses } = useContext(GlobalContext);
  const [vehicle, setVehicle] = useState(null);
  const [vehicleShippings, setVehicleShippings] = useState(null);

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
              status: shippingStatuses[status],
              routeId,
              dateCompleted,
              currentSegment,
            }))
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
                <th>Id Ruta</th>
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
                    dateCompleted,
                    currentSegment,
                    routeId,
                  }) => (
                    <tr key={id}>
                      <td>{ moment(dateScheduled).format('DD/MM/YYYY, h:mm:ss a') }</td>
                      <td>{ dateCompleted ? moment(dateCompleted).format('DD/MM/YYYY, h:mm:ss a') : '' }</td>
                      <td>{ status }</td>
                      <td>
                        <Link to={`/route/${routeId}`}>
                          <Badge>Ver Ruta</Badge>
                        </Link>
                      </td>
                      <td>{ currentSegment }</td>
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
    </>
  );
}
 
export default VehicleShippings;