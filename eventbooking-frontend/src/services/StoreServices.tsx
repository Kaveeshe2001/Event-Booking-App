import axios from "axios";
import { handleError } from "../handlers/ErrorHandler";
import { StoreGet, StorePost } from "../models/Store";

const api = 'https://localhost:7107/api/Store';

export const storePostApi = async (
    name: string,
    email: string,
    phoneNumber: string,
    address: string,
    coverPhoto: string,
    profilePhoto: string,
) => {
    try {
        const token = localStorage.getItem('token');

        const data = await axios.post<StorePost>(
            api, {
                name: name,
                email: email,
                phoneNumber: phoneNumber,
                address: address,
                coverPhoto: coverPhoto,
                profilePhoto: profilePhoto,
            }, {
                headers: {
                    Authorization: `Bearer ${token}`, 
                },
            }
        );

        return data;
    }catch (error) {
        handleError(error);
    }
};

export const storeGetApi = async () => {
    try {
        const data = await axios.get<StoreGet>(api);
        return data;
    } catch (error) {
        handleError(error);
    }
};

export const storeGetByUser = async (id: string) => {
    try {
        const data = await axios.get<StoreGet>(`${api}/user/${id}`);
        return data;
    } catch (error) {
        handleError(error);
    }
};