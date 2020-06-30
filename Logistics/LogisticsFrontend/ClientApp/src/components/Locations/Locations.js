import React, { useContext } from 'react';
import { GlobalContext } from '../../context/GlobalContext'
import { Table, Spinner } from 'reactstrap';
import './Locations.css';

const Locations = () => {
  const { nodes } = useContext(GlobalContext);

  return (
    <>
      <Table hover>
        <thead>
          <tr>
            <th>Nombre</th>
            <th>Latitud</th>
            <th>Longitud</th>
          </tr>
        </thead>
        <tbody>
          { 
            !!nodes && (
              !!nodes.length ? nodes.map(({ name, id, latitude, longitude }) => (
                <tr key={id}>
                  <td>{ name }</td>
                  <td>{ latitude }</td>
                  <td>{ longitude }</td>
                </tr>
              )) : (
                <tr>
                  <td>No se encontraron lugares</td>
                </tr>
              )
            )
          }
        </tbody>
      </Table>
      {
        !nodes && (
          <Spinner type="grow" color="primary" /> 
        ) 
      }
    </>
  );
}
 
export default Locations;