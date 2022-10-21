import axios, { AxiosRequestHeaders } from "axios";
import { getToken } from "./auth";

const api = axios.create({
  baseURL: "https://localhost:5001",
});

api.interceptors.request.use(async (config) => {
  const token = getToken();
  if (token) {
    config.headers = {
      ...config.headers,
      Authorization: `Bearer ${token}`,
    } as AxiosRequestHeaders;
  }
  return config;
});

export default api;
