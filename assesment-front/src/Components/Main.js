import React, { useContext } from 'react';
import AppContext from '../store/AppContext';
import FarewellComponent from './FarewellComponent/FarewellComponent';
import LoginComponent from './InitialComponent/LoginComponent';
import QuestionComponent from './QuestionComponent/QuestionComponent';

function Main() {
	const currentAppContext = useContext(AppContext);
	return (
		<div>
			{currentAppContext.step == 1 && <LoginComponent />}
			{currentAppContext.step == 2 && <QuestionComponent />}
			{currentAppContext.step == 3 && <FarewellComponent color='#0000FF' />}
		</div>
	);
}

export default Main;
