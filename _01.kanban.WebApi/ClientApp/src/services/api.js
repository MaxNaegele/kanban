import axios from 'axios';
import {getToken} from './authorize';

const api = axios.create({ baseURL: 'http://localhost:5000/api/' });

api.interceptors.request.use(config => {
    const token = getToken();
    if (token) config.headers.Authorization = `Bearer ${token}`;
    return config;
});

api.interceptors.response.use(function (response) {
    return response;
}, function (error) {
    console.error("Error request ", error);
    if (error.response) {
        switch (error.response.status) {
          case 401:
            window.location.href = window.location.origin;
            break;
          default:
            break;
        }
      }
    return Promise.reject(error);
});

export default api;