import "antd/dist/antd.css";
import { Form, Input, Button, notification, Select } from "antd";
import { AxiosError, AxiosResponse } from "axios";
import "./index.css";
import "../styles/form.css";
import { AuthenticatedPage } from "../../routes";
import { useEffect, useState } from "react";
import api from "../../services/api";

export default function CreatePerson() {
  const [code, setCode] = useState<string>();
  const [name, setName] = useState<string>();
  const [address, setAddress] = useState<string>();
  const [phoneNumber, setPhoneNumber] = useState<string>();
  const [churchId, setChurchId] = useState<string>();

  const [churchOptions, setChurchOptions] = useState<ChurchResponseModel[]>([]);

  const onFinish = async () => {
    api
      .post("/people", { code, name, address, phoneNumber, churchId })
      .then(() => {
        notification.success({
          message: "Pessoa cadastrada com sucesso.",
        });
      })
      .catch((error: AxiosError) => {
        if (error.response?.status === 400) {
          notification.error({
            message: error.response?.data,
          });
        } else {
          notification.error({
            message: "Ocorreu um erro ao cadastrar uma pessoa.",
          });
        }
      });
  };

  const getChurchOptions = () => {
    api
      .get("/churchs")
      .then((response: AxiosResponse) => {
        setChurchOptions(response.data as ChurchResponseModel[]);
      })
      .catch((_: AxiosError) => {
        notification.error({
          message: "Falha ao carregar as opções de igreja.",
        });
      });
  };

  useEffect(() => {
    getChurchOptions();
  }, []);

  return (
    <AuthenticatedPage className="create-person-page">
      <Form onFinish={onFinish}>
        <Form.Item
          name="code"
          label="Código"
          rules={[
            {
              required: true,
              message: "O código da pessoa deve ser informado!",
            },
          ]}
        >
          <Input type="number" onChange={(e) => setCode(e.target.value)} />
        </Form.Item>

        <Form.Item
          name="name"
          label="Nome"
          rules={[
            {
              required: true,
              message: "O nome da pessoa deve ser informado!",
            },
          ]}
        >
          <Input onChange={(e) => setName(e.target.value)} />
        </Form.Item>

        <Form.Item
          name="address"
          label="Endereço"
          rules={[
            {
              required: true,
              message: "O endereço da pessoa deve ser informado!",
            },
          ]}
        >
          <Input onChange={(e) => setAddress(e.target.value)} />
        </Form.Item>

        <Form.Item
          name="phoneNumber"
          label="Telefone"
          rules={[
            {
              required: true,
              message: "O telefone da pessoa deve ser informado!",
            },
          ]}
        >
          <Input
            type="number"
            onChange={(e) => setPhoneNumber(e.target.value)}
          />
        </Form.Item>

        <Form.Item
          name="church"
          label="Igreja"
          rules={[
            {
              required: true,
              message: "A igreja que a pessoa é membro deve ser informado!",
            },
          ]}
        >
          <Select onChange={(value) => setChurchId(value)}>
            {churchOptions.map((church, index) => {
              return (
                <Select.Option key={index} value={church.id}>
                  {church.name}
                </Select.Option>
              );
            })}
          </Select>
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
