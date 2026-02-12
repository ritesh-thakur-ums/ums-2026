const AdminDashboard = () => {
   const email = localStorage.getItem("email");

   return(
       <div style = {{padding : "30px" }}>
          <h2>Admin Dashboard</h2>
          <p>Welcome, {email}</p>
       </div>
   );
};

export default AdminDashboard;
