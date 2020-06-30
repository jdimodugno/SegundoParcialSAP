import React, { useContext, useCallback, useEffect, useState } from 'react';
import { fetchRouteById } from '../../utils/apiCalls';
import { GlobalContext } from '../../context/GlobalContext';
import Map from '../Map/Map';

const RouteMap = ({
  match
}) => {
  const { nodesAsObject } = useContext(GlobalContext);
  const [route, setRoute] = useState(null);

  useEffect(() => {
    if (nodesAsObject) {
      const { params : { routeId } } = match;
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
    }
  }, [match, nodesAsObject]);

  return (
    !!route ? (
      <>
        <h1>{route.detail}</h1>
        <Map
          nodes={route.nodes}
          route={true}
        />
      </>
    ) : (
      <p>loading</p>
    )
  );
}
 
export default RouteMap;