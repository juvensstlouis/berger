import { Layout } from "antd";
import Header from "../Header";
import Footer from "../Footer";
import Sider from "../Sider";
import "./index.css"

const { Content } = Layout;

export default function CustomLayout({
  children,
}: {
  children?: React.ReactNode;
}) {
  return (
    <Layout>
      <Header />
      <Layout>
        <Sider />
        <Content>{children}</Content>
      </Layout>
      <Footer />
    </Layout>
  );
}
