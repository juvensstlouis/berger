import styled from "styled-components";

export const Container = styled.div``;

export const Header = styled.div`
  display: flex;
  justify-content: space-between;
  align-items: center;
  background-color: cadetblue;
  width: 100%;
  height: 70px;
  padding: 12px;

  p {
    font-size: 24px;
    margin: 0;
  }

  .anticon-logout {
    font-size: 24px;
    cursor: pointer;
  }

  .ant-btn {
    padding: 0;
    background: none;
    border: none;
    font-size: 18px;
  }

  .ant-btn:hover {
    color: white;
  }
`;
