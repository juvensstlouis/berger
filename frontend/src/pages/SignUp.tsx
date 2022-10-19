import { notification } from "antd";
import { AxiosResponse } from "axios";
import { useState } from "react";
import { Link } from "react-router-dom";
import api from "../services/api";
import { Form, Container } from "./styles/SignUpStyles";

export default function SignUp() {

  const [username, setUsername] = useState<string>();
  const [email, setEmail] = useState<string>();
  const [password, setPassword] = useState<string>();
  const [error, setError] = useState<string>();

  const handleSignUp = async (e : any) => {
    e.preventDefault();

    if (!username || !email || !password) {
      setError("Preencha todos os dados para se cadastrar");
    } else {
      api.post("/user", { username, email, password })
      .then((response: AxiosResponse) => {
        if(response.status == 200) {
          window.location.href = "/";
        }
        else if(response.status == 400) {
          setError("Nome de usuário já existente.");
        }
        else {
          throw new Error()
        }
      })
      .catch(err => {
        console.log(err);
        notification.error({
          message: "Ocorreu um erro ao registrar sua conta.",
        });
      })
    }
  };

  return (
    <Container>
      <Form onSubmit={handleSignUp}>
        {error && <p>{error}</p>}
        <input
          type="text"
          placeholder="Nome de usuário"
          onChange={(e) => setUsername(e.target.value)}
        />
        <input
          type="email"
          placeholder="Endereço de e-mail"
          onChange={(e) => setEmail(e.target.value)}
        />
        <input
          type="password"
          placeholder="Senha"
          onChange={(e) => setPassword(e.target.value)}
        />
        <button type="submit">Cadastrar</button>
        <hr />
        <Link to="/">Fazer login</Link>
      </Form>
    </Container>
  );
}
