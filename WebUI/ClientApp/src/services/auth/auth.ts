import httpHelper from "../axios";

const baseUrl = '/authentication'

export const getCurrentAuthUser = () => httpHelper.get(`${baseUrl}/current-user`);