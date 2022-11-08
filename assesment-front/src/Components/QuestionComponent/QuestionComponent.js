import { React, useContext, useState } from 'react';
import AppContext from '../../store/AppContext';
import './QuestionComponent.component.css';

function QuestionComponent() {
	const currentAppContext = useContext(AppContext);
	const [currentQuestion, setCurrentQuestion] = useState(0);
	const [selectedOption, setSelectedOption] = useState(null);
	let answers = { ...currentAppContext.answer };

	function handleSaveQuestion(event) {
		event.preventDefault();
		if (selectedOption != null) {
			document.getElementById('emptyAnswer').classList.add('invisible');
			switch (currentAppContext.questions[currentQuestion].subject) {
				case 'data':
					answers.data.push(
						parseFloat(
							selectedOption /
								JSON.parse(currentAppContext.questions[currentQuestion].options)
									.length
						)
					);
					break;
				case 'logistics':
					answers.logistics.push(
						parseFloat(
							selectedOption /
								JSON.parse(currentAppContext.questions[currentQuestion].options)
									.length
						)
					);
					break;
				case 'identity validation':
					answers.identity.push(
						parseFloat(
							selectedOption /
								JSON.parse(currentAppContext.questions[currentQuestion].options)
									.length
						)
					);
					break;
				case 'fidelization':
					answers.fidelization.push(
						parseFloat(
							selectedOption /
								JSON.parse(currentAppContext.questions[currentQuestion].options)
									.length
						)
					);
					break;
				case 'payments':
					answers.payments.push(
						parseFloat(
							selectedOption /
								JSON.parse(currentAppContext.questions[currentQuestion].options)
									.length
						)
					);
					break;
				default:
					break;
			}

			currentAppContext.setAnswer({ ...answers });
			if (currentQuestion < currentAppContext.questions.length - 1) {
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
		} else {
			document.getElementById('emptyAnswer').classList.remove('invisible');
		}
	}

	function handleChange(event) {
		setSelectedOption(event.target.value);
	}

	return (
		<div className='question-container'>
			<h2>
				Question {currentQuestion + 1} of {currentAppContext.questions.length}
			</h2>
			<form onSubmit={handleSaveQuestion}>
				<div className='question-title'>
					<h2>{currentAppContext.questions[currentQuestion].title}</h2>
				</div>
				<div className='answers-container'>
					{JSON.parse(currentAppContext.questions[currentQuestion].options).map(
						(option, index) => (
							<label
								className='answer-label'
								key={index}>
								<input
									type='radio'
									value={index + 1}
									name={`question${currentQuestion}`}
									id={index}
									key={index}
									onChange={handleChange}
								/>
								{option}
							</label>
						)
					)}
					<span
						className='errorSpan invisible'
						id='emptyAnswer'>
						You have to choose an answer before continue
					</span>
				</div>
				<div className='save-question'>
					<input
						type='submit'
						value={
							currentQuestion == currentAppContext.questions.length - 1
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
