import axios from "axios";

const API = axios.create({
  baseURL: "http://localhost:5044", // backend URL
});

export const loginUser = async (username, password) => {
  const res = await API.post("/api/auth/login", { username, password });
  console.log(res);
  return res.data;
};

export const getDashboardContent = async (token) => {
  const res = await API.get("/api/content/dashboard", {
    headers: { Authorization: `Bearer ${token}` },
  });
  return res.data;
};
