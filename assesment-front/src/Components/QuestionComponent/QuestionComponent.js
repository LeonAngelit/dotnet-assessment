import { React, useContext, useState } from 'react';
import AppContext from '../../store/AppContext';
import './QuestionComponent.component.css';

function QuestionComponent() {
	const currentAppContext = useContext(AppContext);
	const [currentQuestion, setCurrentQuestion] = useState(0);
	const [selectedOption, setSelectedOption] = useState(null);
	let answers = [...currentAppContext.answer];

	let fetchedQuestions = [
		{
			title: '¿Cómo te llamas?',
			options: ['Pepe', 'Juan', 'Manolo'],
		},
		{
			title: '¿Cuántos años tienes?',
			options: [1, 2, 3],
		},
		{
			title: '¿Cuál es tu color favorito?',
			options: ['Rojo', 'Verde', 'Azul'],
		},
		{
			title: '¿Cuál es tu comida favorita?',
			options: ['Pizza', 'Pasta', 'Hamburguesa'],
		},
	];

	function handleSaveQuestion(event) {
		event.preventDefault();
		if (selectedOption != null) {
			answers.push(selectedOption);
			currentAppContext.setAnswer([...answers]);
			if (currentQuestion < fetchedQuestions.length - 1) {
				document
					.getElementsByName(`question${currentQuestion}`)
					.forEach((element) => {
						element.checked = false;
					});
				setSelectedOption(null);
				setCurrentQuestion(currentQuestion + 1);
			} else {
				currentAppContext.setStep(++currentAppContext.step);
			}
		}
	}

	function handleChange(event) {
		setSelectedOption(event.target.value);
	}

	return (
		<div className='question-container'>
			<h2>
				Question {currentQuestion + 1} of {fetchedQuestions.length}
			</h2>
			<form onSubmit={handleSaveQuestion}>
				<div className='question-title'>
					<h2>{fetchedQuestions[currentQuestion].title}</h2>
				</div>
				<div className='answers-container'>
					{fetchedQuestions[currentQuestion].options.map((option, index) => (
						<label className='answer-label'>
							<input
								type='radio'
								value={option}
								name={`question${currentQuestion}`}
								key={index}
								onChange={handleChange}
							/>
							{option}
						</label>
					))}
				</div>
				<div className='save-question'>
					<input
						type='submit'
						value={
							currentQuestion == fetchedQuestions.length - 1
								? 'Send Questions'
								: 'Save'
						}
					/>
				</div>
			</form>
		</div>
	);
}

export default QuestionComponent;
