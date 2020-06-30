import React, { useContext, useState, useCallback } from 'react';
import { DropdownItem, DropdownMenu, UncontrolledDropdown, Form, DropdownToggle, Label, Input, FormGroup, Spinner, Button } from 'reactstrap';
import { GlobalContext } from '../../context/GlobalContext';
import { fetchShortestRoute } from '../../utils/apiCalls';

import './RouteCalculation.css';
import Map from '../Map/Map';

const RouteCalculation = () => {
  const { nodes, nodesAsObject } = useContext(GlobalContext);
  const [origin, setOrigin] = useState(null);
  const [shortestRoute, setShortestRoute] = useState(null);
  const [shortestRouteNodes, setShortestRouteNodes] = useState(null);
  const [destinationsDraft, setDestinationsDraft] = useState([]);

  const extendedSetOrigin = useCallback(
    (id) => {
      setOrigin(id);
      if (destinationsDraft.indexOf(id) > -1) removeFromDraft(id);
    }, [destinationsDraft],
  );

  const appendToDraft = useCallback(
    (id) => { setDestinationsDraft(draft => [...draft, id])}, [],
  );

  const removeFromDraft = useCallback(
    (id) => {  setDestinationsDraft(draft => [...draft.filter(d => d !== id)]); }, [],
  );

  return !!nodes && !!nodesAsObject ? (
    <>
      <Form>
        <UncontrolledDropdown>
          <DropdownToggle caret>
            Lugares
          </DropdownToggle>
          <DropdownMenu>
            {
              nodes.map(({ name, id }) => (
                <DropdownItem 
                  onClick={() => extendedSetOrigin(id) }
                  key={id}
                >
                  {name}
                </DropdownItem>
              ))
            }
          </DropdownMenu>
        </UncontrolledDropdown>
        {
          origin && (
            <>
              <span>
                Origen: <b>{ nodesAsObject[origin].name }</b> 
              </span>
              {
                nodes
                  .filter(({ id }) => id !== origin)
                  .map(({ name, id }) => (
                    <FormGroup check key={id}>
                      <Label check>
                        <Input 
                          type="checkbox" 
                          onChange={({ target }) => {
                            if (target.checked) appendToDraft(id);
                            else removeFromDraft(id);
                          }}
                        />
                        {name}
                      </Label>
                    </FormGroup>
                  ))
              }
            </>
          )
        }
        <Button
          color="primary"
          onClick={( ) => {
            fetchShortestRoute({
              OriginNodeId: origin,
              DestinationNodeIds: destinationsDraft.filter(id => id != origin)
            }).then(data => {
              setShortestRoute(data);
              setShortestRouteNodes(data.nodeIds.map(node => nodesAsObject[node]));
            })
          }}
          disabled={destinationsDraft.length < 3}
        >
          Calcular
        </Button>
      </Form>
      {
        !!shortestRoute && (
          <div>
            <p>
              Ruta sugerida: {shortestRoute.detail}
              <br/>
              Distancia total: {shortestRoute.distance}
            </p>
          </div>
        )
      }
      {
        !!shortestRouteNodes && (
          <Map
            nodes={shortestRouteNodes}
            route={true}
          />
        )
      }
    </>
  ) : (
    <Spinner type="grow" color="primary" />
  );
}
 
export default RouteCalculation;