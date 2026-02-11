import axiosClient from "../api/axiosClient";

export interface LoginRequest {
    email: string;
    password: string;
}

export interface LoginResponse {
    token: string;
    email: string;
    roles: string[];
}

export const loginUser = async(
    data: LoginRequest
): Promise<LoginResponse> => {
    const response = await axiosClient.post<LoginResponse>(
        "/auth/login",
        data
    );
    return response.data;
};