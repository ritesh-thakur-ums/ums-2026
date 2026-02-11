import {useState} from "react";
import {loginUser} from "../services/authService";

const Login= ()=> {
    const[email , setEmail] = useState<string>("");

    const [password, setPassword] = useState<string>("");

    const [errors, setErrors] = useState<string>("");

    const[loading, setLoading] = useState<boolean>(false);

    const handleSubmit = async (e: React.FormEvent) => { 
          e.preventDefault();
          debugger;
          if(!email || !password)
          {
            setErrors("Email and password are required");
            return;
          }

          if(!email.includes('@'))
          {
            setErrors("Invalid email format");
            return;
          }

          try{
            setLoading(true);
            setErrors("");
            
            const result = await loginUser({
              email,
              password
            });

            console.log("Login success:", result);

            alert("Login success! Token received.");
          } catch(error: any) {
              console.log(error);

              if(error.response?.status === 401) {
                 setErrors("Invalid credentials");
              } else {
                setErrors("Server error");
              }
          } finally {
            setLoading(false);
          }
          console.log("Valid form:", email, password);
    }

    return (
        <div style={styles.container}>
          <form style={styles.form} onSubmit={handleSubmit}>
            <h2>Login</h2>

            <input type = "email"
            placeholder="Email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            style = {styles.input}
            />

            <input type = "password"
            placeholder = "Password"
            value={password}
            onChange={(e) => setPassword(e.target.value)} style={styles.input} />
            {errors && <p style={styles.error}>{errors}</p>}

            <button type="submit" style={styles.button} disabled={loading}>
              {loading ? "Logging in..." : "Login" }
            </button>
          </form>
        </div>
    );
};

const styles  = {
   container: {
     height: "100vh",
     display: "flex",
     justifyContent: "center",
     alignItems: "center",
     background: "#f5f5f5"
   },
   form: {
    width: "320px",
    padding: "30px",
    background: "white",
    borderRadius: "8px",
    boxShadow: "0 0 10px rgba(0, 0, 0, 0.1)",
    display: "flex",
    flexDirection: "column" as const
   },
   input: {
    marginBottom: "12px",
    padding: "10px"
   },
   button: {
    padding: "10px",
    background: "#1976d2",
    color: "white",
    border: "none",
    cursor: "pointer"
   },
   error: {
    color: "red",
    fontSize: "14px"
   }
};

export default Login;