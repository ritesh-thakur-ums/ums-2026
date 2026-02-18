import { useNavigate } from "react-router-dom";
import { clearAuth } from "../utils/auth";
import { useEffect } from "react";
import axiosClient from "../api/axiosClient";

const AdminDashboard = () => {
   const navigate = useNavigate();
   const email = localStorage.getItem("email");

   const handleLogout = () => {
      clearAuth();
      navigate("/login");
   };

   useEffect(() => {
      axiosClient.get("/protected/testtokenexpiry")
      .then(res => console.log(res.data))
      .catch(err => console.log(err))
   }, [])

   return(
       <div style = {{padding : "30px" }}>
          <h2>Admin Dashboard</h2>
          <p>Welcome, {email}</p>

          <button onClick={handleLogout}>Logout</button>
       </div>
   );
};

export default AdminDashboard;
