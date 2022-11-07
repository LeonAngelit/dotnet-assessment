import { React, useContext, useRef } from "react";
import AppContext from "../../store/AppContext";
import "./Login.component.css";

function LoginComponent() {
  const emailRef = useRef(null);
  const emailTwoRef = useRef(null);
  const currentAppContext = useContext(AppContext);

  function handleClick(e) {
    e.preventDefault();

    if (
      emailRef.current.value === emailTwoRef.current.value &&
      emailRef.current.value != "" &&
      emailTwoRef.current.value != ""
    ) {
      currentAppContext.setStep(++currentAppContext.step);
    } else {
      document
        .getElementsByClassName("errorSpan")[0]
        .classList.remove("invisible");
    }
  }

  return (
    <div className="login-form">
      <form>
        <div className="input-container">
          <label htmlFor="email">Email: </label>
          <input type="email" placeholder="Email" name="email" ref={emailRef} />
        </div>
        <div className="input-container">
          <label htmlFor="email">Repeat email: </label>
          <input
            type="email"
            placeholder="Email"
            name="repeatEmail"
            ref={emailTwoRef}
          />
        </div>
        <div className="submit-container">
          <input type="submit" defaultValue="Accept" onClick={handleClick} />
        </div>
      </form>
      <span className="errorSpan invisible">The emails don't match</span>
    </div>
  );
}

export default LoginComponent;
