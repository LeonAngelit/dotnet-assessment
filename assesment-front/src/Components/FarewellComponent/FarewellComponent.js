import React from 'react';
import { BarChart, Bar, XAxis, YAxis, Tooltip, Legend } from 'recharts';

function FarewellComponent() {
	const results = [
		{ name: 'DATA', afinity: 50 },
		{ name: 'LOGISTICS', afinity: 80 },
		{ name: 'IDENTITY_VALIDATION', afinity: 90 },
		{ name: 'FIDELIZATION', afinity: 60 },
		{ name: 'PAYMENTS', afinity: 100 },
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
					fill='#8884d8'
				/>
			</BarChart>
		</div>
	);
}

export default FarewellComponent;
