import { React, useRef, useContext } from 'react';
import './Login.component.css';
import AppContext from '../../store/AppContext';

function LoginComponent() {
	const currentAppContext = useContext(AppContext);
	const emailRef = useRef(null);
	const emailTwoRef = useRef(null);

	function handleSubmit(event) {
		event.preventDefault();
		if (emailRef.current.value == emailTwoRef.current.value) {
			currentAppContext.setStep(++currentAppContext.step);
		} else {
			window.alert("Emails don't match");
		}
	}

	return (
		<div className='login-form'>
			<form onSubmit={handleSubmit}>
				<div className='input-container'>
					<label htmlFor='email'>Email: </label>
					<input
						type='email'
						placeholder='Email'
						name='email'
						ref={emailRef}
					/>
				</div>
				<div className='input-container'>
					<label htmlFor='email'>Repeat email: </label>
					<input
						type='email'
						placeholder='Email'
						name='repeatEmail'
						ref={emailTwoRef}
					/>
				</div>
				<div className='submit-container'>
					<input
						type='submit'
						defaultValue='Accept'
					/>
				</div>
			</form>
		</div>
	);
}

export default LoginComponent;
