import React, { useContext } from 'react';
import { GlobalContext } from '../../context/GlobalContext'
import { Table, Spinner, Badge } from 'reactstrap';
import { Link } from 'react-router-dom';
import '../../Global.css';
import './Vehicles.css';

const Vehicles = () => {
  const { vehicles } = useContext(GlobalContext);

  return (
    <>
      <Table hover>
        <thead>
          <tr>
            <th>Patente</th>
            <th>Modelo</th>
            <th>Año</th>
            <th>Estado</th>
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
        !vehicles && (
          <Spinner type="grow" color="primary" /> 
        ) 
      }
    </>
  );
}
 
export default Vehicles;