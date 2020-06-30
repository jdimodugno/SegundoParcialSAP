import React, { useState, createContext, useCallback } from 'react';

export const GlobalContext = createContext({
  loading: false,
  setLoading: () => {},
  shippingStatuses: null,
  setShippingStatuses: () => {},
  nodes: null,
  setNodes: () => {},
  nodesAsObject: null,
  setNodesAsObject: () => {},
  vehicles: null,
  setVehicles: () => {},
});

export const GlobalProvider = ({ children }) => {
  const [loading, setLoading] = useState(true);
  const [shippingStatuses, setShippingStatuses] = useState(null);
  const [nodes, setNodes] = useState(null);
  const [nodesAsObject, setNodesAsObject] = useState(null);
  const [vehicles, setVehicles] = useState(null);

  const notify = useCallback(
    (notifier, action) => {
      notifier(true);
      action();
      notifier(false);
    }, [],
  )

  const extendedSetNodes = (data) => {
    setNodesAsObject(
      data.reduce((acc, current) => {
        const { id, name, latitude, longitude } = current;
        return { ...acc, [id]: { name, latitude, longitude }};
      }, {})
    );
    setNodes(data);
  }

  const extendedSetShippingStatuses = (data) => notify(
    setLoading, 
    () => {
      setShippingStatuses(
        data.reduce((acc, current) => {
          const { value, description } = current;
          return { ...acc, [value]: description};
        }, {})
      );
    }
  )

  return (
    <GlobalContext.Provider value={{
      loading,
      setLoading,
      shippingStatuses,
      setShippingStatuses: extendedSetShippingStatuses,
      nodes,
      setNodes: extendedSetNodes,
      nodesAsObject,
      vehicles,
      setVehicles,
    }}>
      {children}
    </GlobalContext.Provider>
  )
};
