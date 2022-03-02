export const TOKEN_KEY = "@SystemWeb-Token";
export const isAuthenticated = localStorage.getItem(TOKEN_KEY) !== null;
export const getUser = () => "";

export const setToken = token => localStorage.setItem(TOKEN_KEY, token);
export const getToken = () => localStorage.getItem(TOKEN_KEY);