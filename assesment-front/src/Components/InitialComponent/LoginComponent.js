import { React, useRef } from 'react';
import './Login.component.css';

function LoginComponent() {
	const emailRef = useRef(null);
	const emailTwoRef = useRef(null);

	return (
		<div className='login-form'>
			<form>
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
