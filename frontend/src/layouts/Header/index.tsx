import { LogoutOutlined } from "@ant-design/icons";
import { Button, Layout } from "antd";
import { isAuthenticated, logout } from "../../services/auth";
import "./index.css";

const { Header } = Layout;

export default function CustomHeader() {
  return (
    <Header>
      <p>Storpa</p>
      {isAuthenticated() && (
        <Button icon={<LogoutOutlined />} onClick={logout} />
      )}
    </Header>
  );
}
