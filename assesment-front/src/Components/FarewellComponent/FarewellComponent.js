import axios from "axios";
import { React, useContext } from "react";
import { BarChart, Bar, XAxis, YAxis, Tooltip, Legend } from "recharts";
import AppContext from "../../store/AppContext";

function FarewellComponent(props) {
  const currentAppContext = useContext(AppContext);
  const temporalAnswer = { ...currentAppContext.answer };

  const results = [
    {
      name: "DATA",
      afinity: Math.round(
        (temporalAnswer.data.reduce((a, b) => a + b) /
          temporalAnswer.data.length) *
          100
      ),
    },
    {
      name: "LOGISTICS",
      afinity: Math.round(
        (temporalAnswer.logistics.reduce((a, b) => a + b) /
          temporalAnswer.logistics.length) *
          100
      ),
    },
    {
      name: "IDENTITY_VALIDATION",
      afinity: Math.round(
        (temporalAnswer.identity.reduce((a, b) => a + b) /
          temporalAnswer.identity.length) *
          100
      ),
    },
    {
      name: "FIDELIZATION",
      afinity: Math.round(
        (temporalAnswer.fidelization.reduce((a, b) => a + b) /
          temporalAnswer.fidelization.length) *
          100
      ),
    },
    {
      name: "PAYMENTS",
      afinity: Math.round(
        (temporalAnswer.payments.reduce((a, b) => a + b) /
          temporalAnswer.payments.length) *
          100
      ),
    },
  ];

  axios
    .post(
      "https://localhost:7010/api/User",
      { email: currentAppContext.userEmail, answers: JSON.stringify(results) },
      {
        headers: {
          "Content-Type": "application/json",
        },
      }
    )
    .then((response) => {
    console.log(response)
    });

  return (
    <div className="results-container">
      <h2>Results: </h2>

      <BarChart width={800} height={400} data={results}>
        <XAxis dataKey="name" />
        <YAxis />
        <Tooltip />
        <Legend />
        <Bar dataKey="afinity" barSize={50} fill={props.color} />
      </BarChart>
    </div>
  );
}

export default FarewellComponent;
