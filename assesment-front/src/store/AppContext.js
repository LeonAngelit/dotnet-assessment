import { React, createContext, useState } from "react";

let initialAppContext = JSON.parse(
  window.localStorage.getItem("app-context")
) || {
  step: 1,
  userEmail: false,
  setStep: (step) => {},
  setUserEmail: (email) => {},
};

const AppContext = createContext(initialAppContext);

export function AppContextProvider(props) {
  const [currentStep, setCurrentStep] = useState(initialAppContext.step);
  const [currentUserEmail, setUserEmail] = useState(
    initialAppContext.userEmail
  );

  function handleStep(step) {
    setCurrentStep(step);
  }

  function handleUserEmail(email) {
    setUserEmail(email);
  }

  const context = {
    step: currentStep,
    userEmail: currentUserEmail,
    setStep: handleStep,
    setUserEmail: handleUserEmail,
  };

  window.localStorage.setItem("app-context", JSON.stringify(context));

  return (
    <AppContext.Provider value={context}>{props.children}</AppContext.Provider>
  );
}

export default AppContext;
