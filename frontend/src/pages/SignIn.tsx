import { notification } from "antd";
import { AxiosResponse } from "axios";
import { useState } from "react";
import { Link } from "react-router-dom";
import api from "../services/api";
import { isAuthenticated, login } from "../services/auth";
import { Form, Container } from "./styles/SignInStyles";

export default function SignIn() {
  const [username, setUsername] = useState<string>();
  const [password, setPassword] = useState<string>();
  const [error, setError] = useState<string>();

  const handleSignUp = async (e: any) => {
    e.preventDefault();

    if (!username || !password) {
      setError("Preencha e-mail e senha para continuar!");
    } else {
      api
        .post("/user/login", { username, password })
        .then((response: AxiosResponse<UserResponseModel>) => {
          if (response.status === 200) {
            login(response.data.token);
            window.location.href = "/create-church";
          } else if (response.status === 404) {
            setError("Usuário ou senha inválidos");
          } else {
            throw new Error();
          }
        })
        .catch((err) => {
          console.log(err);
          notification.error({
            message:
              "Houve um problema com o login, verifique suas credenciais.",
          });
        });
    }
  };

  return (
    <Container>
      {isAuthenticated() ? (
        // Atalhos
        <h1>Bem-vindo</h1>
      ) : (
        <Form onSubmit={handleSignUp}>
          {error && <p>{error}</p>}
          <input
            type="text"
            placeholder="Nome de usuário"
            onChange={(e) => setUsername(e.target.value)}
          />
          <input
            type="password"
            placeholder="Senha"
            onChange={(e) => setPassword(e.target.value)}
          />
          <button type="submit">Entrar</button>
          <hr />
          <Link to="/sign-up">Cadastrar-se</Link>
        </Form>
      )}
    </Container>
  );
}
