import { useNavigate } from "react-router-dom";

const AdminDashboard = () => {
   const navigate = useNavigate();
   const email = localStorage.getItem("email");

   const handleLogout = () => {
      localStorage.removeItem("token");
      localStorage.removeItem("email");
      localStorage.removeItem("roles");

      navigate("/login");
   };

   return(
       <div style = {{padding : "30px" }}>
          <h2>Admin Dashboard</h2>
          <p>Welcome, {email}</p>

          <button onClick={handleLogout}>Logout</button>
       </div>
   );
};

export default AdminDashboard;
