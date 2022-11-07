import { React, useContext } from 'react';
import { BarChart, Bar, XAxis, YAxis, Tooltip, Legend } from 'recharts';
import AppContext from '../../store/AppContext';

function FarewellComponent(props) {
	const currentAppContext = useContext(AppContext);

	console.log(currentAppContext.answer.data.reduce((a, b) => a + b));
	const results = [
		{
			name: 'DATA',
			afinity: Math.round(
				(currentAppContext.answer.data.reduce((a, b) => a + b) /
					(currentAppContext.answer.data.length * 3)) *
					100
			),
		},
		{
			name: 'LOGISTICS',
			afinity: Math.round(
				(currentAppContext.answer.logistics.reduce((a, b) => a + b) /
					(currentAppContext.answer.logistics.length * 3)) *
					100
			),
		},
		{
			name: 'IDENTITY_VALIDATION',
			afinity: Math.round(
				(currentAppContext.answer.identity.reduce((a, b) => a + b) /
					(currentAppContext.answer.identity.length * 3)) *
					100
			),
		},
		{
			name: 'FIDELIZATION',
			afinity: Math.round(
				(currentAppContext.answer.fidelization.reduce((a, b) => a + b) /
					(currentAppContext.answer.fidelization.length * 3)) *
					100
			),
		},
		{
			name: 'PAYMENTS',
			afinity: Math.round(
				(currentAppContext.answer.payments.reduce((a, b) => a + b) /
					(currentAppContext.answer.payments.length * 3)) *
					100
			),
		},
	];
	return (
		<div className='results-container'>
			<h2>Results: </h2>

			<BarChart
				width={800}
				height={400}
				data={results}>
				<XAxis dataKey='name' />
				<YAxis />
				<Tooltip />
				<Legend />
				<Bar
					dataKey='afinity'
					barSize={50}
					fill={props.color}
				/>
			</BarChart>
		</div>
	);
}

export default FarewellComponent;
