import React, { useContext } from "react";
import { Link } from "react-router-dom";
import { AuthContext } from "../context/AuthContext";

const Navbar = () => {
  const { logout } = useContext(AuthContext);

  return (
    <nav>
      <Link to="/dashboard">Dashboard</Link>
      <button onClick={logout}>Logout</button>
    </nav>
  );
};

export default Navbar;
