import { React, useContext, useState, useEffect } from 'react';
import AppContext from '../../store/AppContext';
import './QuestionComponent.component.css';
import axios from 'axios';

function QuestionComponent() {
	const currentAppContext = useContext(AppContext);
	const [currentQuestion, setCurrentQuestion] = useState(0);
	const [selectedOption, setSelectedOption] = useState(null);
	let answers = { ...currentAppContext.answer };
	const [questions, setQuestions] = useState([...currentAppContext.questions]);

	function getQuestions() {
		axios
			.get('https://localhost:7010/api/Question', {
				headers: {
					Accept: 'application/json',
				},
			})
			.then((response) => {
				currentAppContext.setQuestions(response.data);
			});
	}

	useEffect(() => {
		if (currentAppContext.questions.length == 0) {
			console.log('en el useEffect');
			getQuestions();
			setQuestions([...currentAppContext.questions]);
			console.log(questions);
		}
	}, []);

	useEffect(() => {
		if (questions.length == 0) window.location.reload();
	}, [questions]);

	function handleSaveQuestion(event) {
		event.preventDefault();
		if (selectedOption != null) {
			switch (questions[currentQuestion].subject) {
				case 'data':
					answers.data.push(parseInt(selectedOption));
					break;
				case 'logistics':
					answers.logistics.push(parseInt(selectedOption));
					break;
				case 'identity validation':
					answers.identity.push(parseInt(selectedOption));
					break;
				case 'fidelization':
					answers.fidelization.push(parseInt(selectedOption));
					break;
				case 'payments':
					answers.payments.push(parseInt(selectedOption));
					break;
				default:
					break;
			}

			currentAppContext.setAnswer({ ...answers });
			if (currentQuestion < questions.length - 1) {
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

	if (questions.length > 0) {
		return (
			<div className='question-container'>
				<h2>
					Question {currentQuestion + 1} of {questions.length}
				</h2>
				<form onSubmit={handleSaveQuestion}>
					<div className='question-title'>
						<h2>{questions[currentQuestion].title}</h2>
					</div>
					<div className='answers-container'>
						{JSON.parse(questions[currentQuestion].options).map(
							(option, index) => (
								<label
									className='answer-label'
									key={index}>
									<input
										type='radio'
										value={index}
										name={`question${currentQuestion}`}
										id={index}
										key={index}
										onChange={handleChange}
									/>
									{option}
								</label>
							)
						)}
					</div>
					<div className='save-question'>
						<input
							type='submit'
							value={
								currentQuestion == questions.length - 1
									? 'Send Questions'
									: 'Save'
							}
						/>
					</div>
				</form>
			</div>
		);
	} else return <p>Questions are loading</p>;
}

export default QuestionComponent;
