import httpHelper from "./axios";

const baseUrl = '/wallet';

export const getAllWallets = () => httpHelper.get(baseUrl);