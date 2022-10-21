import { LogoutOutlined } from "@ant-design/icons";
import { Button } from "antd";
import React, { useEffect } from "react";
import { isAuthenticated, logout } from "../services/auth";
import { Container, Header } from "./styles/PageHeaderStyles";

type PageHeaderProps = {
  children?: React.ReactNode;
};

export default function PageHeader({ children }: PageHeaderProps) {
  return (
    <Container>
      <Header>
        <p>Storpa</p>
        {isAuthenticated() ? <Button icon={<LogoutOutlined />} onClick={logout} /> : <Button onClick={() => window.location.href = "sign-in"}>Entrar</Button>}
      </Header>
      {children}
    </Container>
  );
}
