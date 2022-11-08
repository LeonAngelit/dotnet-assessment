import { React, useContext, useRef, useEffect } from "react";
import AppContext from "../../store/AppContext";
import "./Login.component.css";
import axios from "axios";

function LoginComponent() {
  const emailRef = useRef(null);
  const emailTwoRef = useRef(null);
  const currentAppContext = useContext(AppContext);
  const validateEmail = (email) => {
    return String(email)
      .toLowerCase()
      .match(
        /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
      );
  };

  useEffect(() => {
    if (currentAppContext.questions.length == 0) {
      getQuestions();
    }
  }, []);

  function getQuestions() {
    axios
      .get("https://localhost:7010/api/Question", {
        headers: {
          Accept: "application/json",
        },
      })
      .then((response) => {
        currentAppContext.setQuestions(response.data);
      });
  }

  function validateEmpty() {
    if (emailRef.current.value != "" && emailTwoRef.current.value != "") {
      return true;
    }
    return false;
  }

  function validateMatch(params) {
    if (emailRef.current.value === emailTwoRef.current.value) {
      return true;
    }
    return false;
  }

  async function handleClick(e) {
    e.preventDefault();
    document.getElementById("unmatch").classList.add("invisible");
    document.getElementById("registered").classList.add("invisible");
    document.getElementById("empty").classList.add("invisible");

    if (!validateEmpty()) {
      document.getElementById("empty").classList.remove("invisible");

      return false;
    }

    if (!validateMatch()) {
      document.getElementById("unmatch").classList.remove("invisible");

      return false;
    }

    axios
      .get(`https://localhost:7010/api/User/${emailRef.current.value}`, {
        headers: {
          Accept: "application/json",
        },
      })
      .then((response) => {
        if (response.data.length == 0) {
          currentAppContext.setUserEmail(emailRef.current.value);
          currentAppContext.setStep(++currentAppContext.step);
        } else {
          document.getElementById("registered").classList.remove("invisible");
        }
      });
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
      <span className="errorSpan invisible" id="unmatch">
        The emails don't match
      </span>
      <span className="errorSpan invisible" id="empty">
        The emails field cannot be empty
      </span>
      <span className="errorSpan invisible" id="registered">
        Email already registered
      </span>
    </div>
  );
}

export default LoginComponent;
