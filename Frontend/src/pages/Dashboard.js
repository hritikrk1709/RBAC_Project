import React, { useEffect, useState, useContext } from "react";
import { getDashboardContent } from "../services/api";
import { AuthContext } from "../context/AuthContext";
import Navbar from "../components/Navbar";

const Dashboard = () => {
  const { token } = useContext(AuthContext);
  const [content, setContent] = useState("");

  useEffect(() => {
    const fetchData = async () => {
      try {
        const data = await getDashboardContent(token);
        setContent(data);
      } catch (err) {
        setContent("Failed to load content");
      }
    };
    fetchData();
  }, [token]);

  return (
    <div>
      <Navbar />
      <h2>Dashboard</h2>
      <p>{content}</p>
    </div>
  );
};

export default Dashboard;
