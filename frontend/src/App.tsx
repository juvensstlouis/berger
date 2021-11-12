import "antd/dist/antd.css";
import { Form, Input, Button, Alert } from "antd";
import ChurchRequestModel from "./models/ChurchRequestModel";
import axios from "axios";
import { useState } from "react";
import "./index.css";
import "./App.css";

function App() {
  const [success, setSuccess] = useState<boolean | null>(null);

  const validateMessages = {
    required: "${label} deve ser informado(a)!",
  };

  const onSubmit = (values: ChurchRequestModel) => {
    console.log("Success:", values);

    axios
      .post("https:localhost:5001/church", values)
      .then(function (response) {
        if (response.status === 200) {
          setSuccess(true);
        }
      })
      .catch(function (error) {
        setSuccess(false);
        console.log(error);
      });
  };

  return (
    <Form
      className="forms"
      onFinish={onSubmit}
      autoComplete="off"
      validateMessages={validateMessages}
    >
      <Form.Item
        label="Nome"
        name="name"
        rules={[
          {
            required: true,
          },
        ]}
      >
        <Input />
      </Form.Item>
      <Form.Item
        label="Data de Fundação"
        name="foundationDate"
        rules={[
          {
            required: true,
          },
        ]}
      >
        <Input type="date" />
      </Form.Item>
      <Form.Item
        label="CEP"
        name="zipCode"
        rules={[
          {
            required: true,
          },
        ]}
      >
        <Input />
      </Form.Item>
      <Form.Item
        label="Número"
        name="number"
        rules={[
          {
            required: true,
          },
        ]}
      >
        <Input type="number" />
      </Form.Item>
      <Form.Item>
        <Button type="primary" htmlType="submit">
          Submit
        </Button>
      </Form.Item>
      {success === true && (
        <Alert
          message="Cadastrado com sucesso"
          type="success"
          showIcon
          closable
        />
      )}
      {success === false && (
        <Alert message="Erro ao cadastrar" type="error" showIcon closable />
      )}
    </Form>
  );
}

export default App;
