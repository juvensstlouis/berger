import "antd/dist/antd.css";
import { Form, Input, Button, notification } from "antd";
import ChurchRequestModel from "./models/ChurchRequestModel";
import axios from "axios";
import "./index.css";
import "./App.css";

function App() {
  const validateMessages = {
    required: "'${label}' deve ser informado(a)!",
    pattern: {
      mismatch: "'${label}' não está no formato correto!"
    }
  };

  const onSubmit = (values: ChurchRequestModel) => {
    console.log("Success:", values);

    axios
      .post("https:localhost:5001/church", values)
      .then(function (response) {
        if (response.status === 200) {
          notification.success({
            message: "Cadastrado com sucesso",
          });
        } else {
          throw new Error();
        }
      })
      .catch(function (error) {
        console.log(error);

        notification.error({
          message: "Erro ao cadastrar",
        });
      });
  };

  const maskCep = (_cep: string | undefined) : string => {
    if (!_cep) {
      return "";
    }
    _cep = _cep.replace(/\D/g, "");
    _cep = _cep.replace(/(\d{5})(\d)/, "$1-$2");
    return _cep;
  };

  return (
    <div className="content">
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
              pattern: new RegExp("[0-9]+")
            },
          ]}
        >
          <Input maxLength={8}/>
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
      </Form>
    </div>
  );
}

export default App;
