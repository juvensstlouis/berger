import { LockOutlined, MailOutlined, UserOutlined } from "@ant-design/icons";
import { Button, Divider, Form, Input, notification } from "antd";
import Link from "antd/lib/typography/Link";
import { AxiosError } from "axios";
import { useState } from "react";
import api from "../../services/api";
import "./index.css";
import "../styles/form.css";
import { UnauthenticatedPage } from "../../routes";

export default function SignUp() {
  const [username, setUsername] = useState<string>();
  const [email, setEmail] = useState<string>();
  const [password, setPassword] = useState<string>();

  const onFinish = () => {
    api
      .post("/users", { username, email, password })
      .then(() => {
        notification.success({
          message: "Usuário cadastrado com sucesso",
        });

        setTimeout(() => window.location.href = "/sign-in", 3000);
      })
      .catch((error: AxiosError) => {
        if (error.response?.status === 400) {
          notification.error({
            message: error.response?.data,
          });
        } else {
          notification.error({
            message: "Ocorreu um erro ao registrar sua conta.",
          });
        }
      });
  };

  return (
    <UnauthenticatedPage className="sign-up-page">
      <Form onFinish={onFinish}>
        <Form.Item
          name="username"
          rules={[
            {
              required: true,
              message: "O nome de usuário deve ser informado!",
            },
            {
              min: 5,
              message: "O nome de usuário deve ter no mínimo 5 caracteres",
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
          name="email"
          rules={[
            {
              required: true,
              message: "O email deve ser informado!",
            },
            {
              type: "email",
              message: "O email informado não é válido!",
            },
          ]}
        >
          <Input
            prefix={<MailOutlined />}
            type="email"
            placeholder="Endereço de e-mail"
            onChange={(e) => setEmail(e.target.value)}
          />
        </Form.Item>

        <Form.Item
          name="password"
          rules={[
            {
              required: true,
              message: "A senha deve ser informada!",
            },
            {
              min: 10,
              message: "A senha deve ter no mínimo 10 caracteres",
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
            Cadastrar
          </Button>
          <Divider />
          <div className="other-action">
            <Link href="/sign-in">Entrar</Link>
          </div>
        </Form.Item>
      </Form>
    </UnauthenticatedPage>
  );
}
