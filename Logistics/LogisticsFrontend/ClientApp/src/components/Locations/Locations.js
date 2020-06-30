import React, { useContext } from 'react';
import { GlobalContext } from '../../context/GlobalContext'
import { Table, Spinner } from 'reactstrap';
import './Locations.css';
import Map from '../Map/Map';

const Locations = () => {
  const { nodes } = useContext(GlobalContext);

  return !nodes ? (
    <Spinner type="grow" color="primary" /> 
  ) : (
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
      <Map nodes={nodes} />
    </>
  );
}
 
export default Locations;