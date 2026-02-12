import axios from "axios";

const axiosClient = axios.create({
    baseURL: "https://localhost:44307/api",
    headers: {
        "Content-Type": "application/json"
    }
});

export default axiosClient;