import httpHelper from "./axios";

const baseUrl = '/category';

export const getAllCategories = () => httpHelper.get(baseUrl);