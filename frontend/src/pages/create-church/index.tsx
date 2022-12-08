import "antd/dist/antd.css";
import { Form, Input, Button, notification } from "antd";
import { AxiosError } from "axios";
import "./index.css";
import "../styles/form.css";
import { AuthenticatedPage } from "../../routes";
import { useState } from "react";
import api from "../../services/api";

export default function CreateChurch() {
  const [name, setName] = useState<string>();

  const onFinish = () => {
    api
      .post("/churchs", { name } as ChurchRequestModel)
      .then(() => {
        notification.success({
          message: "Igreja cadastrada com sucesso.",
        });
      })
      .catch((error: AxiosError) => {
        if (error.response?.status === 400) {
          notification.error({
            message: error.response?.data,
          });
        } else {
          notification.error({
            message: "Ocorreu um erro ao cadastrar uma igreja.",
          });
        }
      });
  };

  return (
    <AuthenticatedPage className="create-church-page">
      <Form onFinish={onFinish}>
        <Form.Item
          name="name"
          label="Nome"
          rules={[
            {
              required: true,
              message: "O nome da igreja deve ser informado!",
            },
          ]}
        >
          <Input onChange={(e) => setName(e.target.value)} />
        </Form.Item>

        <Form.Item>
          <Button type="primary" htmlType="submit">
            Cadastrar
          </Button>
        </Form.Item>
      </Form>
    </AuthenticatedPage>
  );
}
