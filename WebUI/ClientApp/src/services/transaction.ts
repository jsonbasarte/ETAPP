import httpHelper from "./axios";

const baseUrl = '/transactionDetails';

export const getAllTransaction = () => httpHelper.get(baseUrl);