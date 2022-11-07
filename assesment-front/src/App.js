import './App.css';
import { Routes, Route } from 'react-router-dom';
import LoginComponent from './Components/InitialComponent/LoginComponent';

function App() {
	return (
		<Routes>
			<Route
				path='/'
				exact={true}
				element={<LoginComponent />}
			/>
		</Routes>
	);
}

export default App;
