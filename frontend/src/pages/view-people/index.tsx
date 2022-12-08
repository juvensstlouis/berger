import "antd/dist/antd.css";
import { notification, Pagination } from "antd";
import { AxiosError, AxiosResponse } from "axios";
import "./index.css";
import { AuthenticatedPage } from "../../routes";
import { useEffect, useState } from "react";
import api from "../../services/api";
import { Card, Col, Row } from "antd";

export default function ViewPeople() {
  const [page, setPage] = useState<number>(1);
  const [pageSize, setPageSize] = useState<number>(3);
  const [people, setPeople] = useState<PersonResponseModel[]>([]);

  const getAllPeople = () => {
    api
      .get("/people")
      .then((response: AxiosResponse) => {
        setPeople(response.data as PersonResponseModel[]);
      })
      .catch((_: AxiosError) => {
        notification.error({
          message: "Falha ao carregar as pessoas cadatsradas.",
        });
      });
  };

  function paginate<T>(array: T[], pageSize: number, page: number): T[] {
    return array.slice((page - 1) * pageSize, page * pageSize);
  }

  useEffect(() => {
    getAllPeople();
  }, []);

  return (
    <AuthenticatedPage className="view-people-page">
      <div className="card-list">
        <Row gutter={16}>
          {paginate(people, pageSize, page).map((p) => {
            <Col span={8}>
              <Card title="Card title" bordered={false}>
                Card content
              </Card>
            </Col>;
          })}
        </Row>
      </div>
      <Pagination
        defaultCurrent={1}
        pageSize={pageSize}
        total={people.length}
        onChange={(page) => setPage(page)}
      />
    </AuthenticatedPage>
  );
}
