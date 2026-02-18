import { ReactNode } from "react";
import {Navigate} from "react-router-dom";
import { getToken } from "../utils/auth";

interface Props{
    children: ReactNode;
}

const ProtectedRoute = ({children}: Props) => {
    const token = getToken();

    if(!token)
    {
        return <Navigate to = "/login" replace />;
    }

    return <>{children}</>;
};

export default ProtectedRoute;