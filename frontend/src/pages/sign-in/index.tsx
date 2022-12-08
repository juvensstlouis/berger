import { LockOutlined, UserOutlined } from "@ant-design/icons";
import { Button, Divider, Form, Input, notification } from "antd";
import Link from "antd/lib/typography/Link";
import { AxiosError, AxiosResponse } from "axios";
import { useState } from "react";
import api from "../../services/api";
import { login } from "../../services/auth";
import "./index.css";
import "../styles/form.css";
import { UnauthenticatedPage } from "../../routes";

export default function SignIn() {
  const [username, setUsername] = useState<string>();
  const [password, setPassword] = useState<string>();

  const onFinish = () => {
    api
      .post("/users/login", { username, password })
      .then((response: AxiosResponse) => {
        login(response.data.token);
        window.location.href = "/";
      })
      .catch((error: AxiosError) => {
        if (error.response?.status === 400) {
          notification.error({
            message: error.response?.data,
          });
        } else {
          notification.error({
            message: "Ocorreu um erro ao fazer login na sua conta.",
          });
        }
      });
  };

  return (
    <UnauthenticatedPage className="sign-in-page">
      <Form onFinish={onFinish}>
        <Form.Item
          name="username"
          rules={[
            {
              required: true,
              message: "O nome de usuário deve ser informado!",
            },
          ]}
        >
          <Input
            prefix={<UserOutlined />}
            placeholder="Nome de usuário"
            onChange={(e) => setUsername(e.target.value)}
          />
        </Form.Item>

        <Form.Item
          name="password"
          rules={[
            {
              required: true,
              message: "A senha deve ser informada!",
            },
          ]}
        >
          <Input
            prefix={<LockOutlined />}
            type="password"
            placeholder="Senha"
            onChange={(e) => setPassword(e.target.value)}
          />
        </Form.Item>

        <Form.Item>
          <Button type="primary" htmlType="submit">
            Entrar
          </Button>
          <Divider />
          <div className="other-action">
            <Link href="/sign-up">Cadastrar</Link>
          </div>
        </Form.Item>
      </Form>
    </UnauthenticatedPage>
  );
}
