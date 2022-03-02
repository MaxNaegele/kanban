import axios from 'axios';

const api = axios.create();

api.interceptors.request.use(config => {
    return config;
});

api.interceptors.response.use(function (response) {
    return response;
}, function (error) {
    console.error("Error request ", error)
    return Promise.reject(error);
});

export default api;