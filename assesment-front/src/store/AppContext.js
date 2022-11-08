import { React, createContext, useState } from "react";

let initialAppContext = {
  step: 1,
  userEmail: false,
  answer: {
    data: [],
    logistics: [],
    identity: [],
    fidelization: [],
    payments: [],
  },
  questions: [],
  results: null,
  setStep: (step) => {},
  setUserEmail: (email) => {},
  setAnswer: (answer) => {},
  setQuestions: (questions) => {},
  setResults: (results) => {},
};

const AppContext = createContext(initialAppContext);

export function AppContextProvider(props) {
  const [currentStep, setCurrentStep] = useState(initialAppContext.step);
  const [currentUserEmail, setUserEmail] = useState(
    initialAppContext.userEmail
  );
  const [currentAnswer, setAnswer] = useState(initialAppContext.answer);
  const [currentQuestions, setCurrentQuestions] = useState(
    initialAppContext.questions
  );
  const [currentResults, setCurrentResults] = useState(
    initialAppContext.results
  );

  function handleStep(step) {
    setCurrentStep(step);
  }

  function handleUserEmail(email) {
    setUserEmail(email);
  }

  function handleAnswer(answer) {
    setAnswer(answer);
  }

  function handleQuestions(questions) {
    setCurrentQuestions(questions);
  }

  function handleResults(results) {
    setCurrentResults(results);
  }

  const context = {
    step: currentStep,
    userEmail: currentUserEmail,
    answer: currentAnswer,
    questions: currentQuestions,
    results: currentResults,
    setStep: handleStep,
    setUserEmail: handleUserEmail,
    setAnswer: handleAnswer,
    setQuestions: handleQuestions,
    setResults: handleResults,
  };

  // window.localStorage.setItem("app-context", JSON.stringify(context));

  return (
    <AppContext.Provider value={context}>{props.children}</AppContext.Provider>
  );
}

export default AppContext;
