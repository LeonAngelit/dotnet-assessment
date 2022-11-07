import { React, createContext, useState } from 'react';

let initialAppContext = JSON.parse(
	window.localStorage.getItem('app-context')
) || {
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
	setStep: (step) => {},
	setUserEmail: (email) => {},
	setAnswer: (answer) => {},
	setQuestions: (questions) => {},
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

	const context = {
		step: currentStep,
		userEmail: currentUserEmail,
		answer: currentAnswer,
		questions: currentQuestions,
		setStep: handleStep,
		setUserEmail: handleUserEmail,
		setAnswer: handleAnswer,
		setQuestions: handleQuestions,
	};

	window.localStorage.setItem('app-context', JSON.stringify(context));

	return (
		<AppContext.Provider value={context}>{props.children}</AppContext.Provider>
	);
}

export default AppContext;
