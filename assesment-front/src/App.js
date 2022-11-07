import './App.css';
import { Routes, Route } from 'react-router-dom';
import Main from './Components/Main';

function App() {
	return (
		<Routes>
			<Route
				path='/'
				exact={true}
				element={<Main />}
			/>
		</Routes>
	);
}

export default App;
