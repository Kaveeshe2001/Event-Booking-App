import axios from "axios";
import { handleError } from "../handlers/ErrorHandler";
import { UserProfileToken } from "../models/User";

const api = 'https://localhost:7107/api/';

export const loginApi = async (username: string, password: string) => {
    try {
        const data = await axios.post<UserProfileToken>(api + 'Authorization/Login', {
            username: username,
            password: password,
        });
        return data;
    } catch (error) {
        handleError(error);
    }
};

export const registerApi = async (
    email: string,
    username: string,
    phoneNumber: string,
    password: string,
) => {
    try {
        const data = await axios.post<UserProfileToken>(api + 'Authorization/Registration', {
            email: email,
            username: username,
            phoneNumber: phoneNumber,
            password: password,
        });
        return data;
    }catch (error) {
        handleError(error);
    }
};

export const getUserByIdApi = async (userId: string) => {
    try {
        const data = await axios.get<UserProfileToken>(`${api}Athorization/${userId}`);
        return data;
    } catch (error) {
        handleError(error);
    }
};