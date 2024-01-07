import httpHelper from "./axios";

const baseUrl = '/transactionDetails';

export type TransactionType = {
    description: string;
    date: string;
    type: string;
    walletName: string;
    amount: number;
}
export type CreateTransactionType = {
    description: string;
    amount: number;
    categoryId: number;
    walletId: number;
    transactionType: number | null;
}

export type UpdateTransactionType = CreateTransactionType & {
    id: number;
}

export const getAllTransaction = () => httpHelper.get(baseUrl);

export const createTransaction = (params: CreateTransactionType) => httpHelper.post(baseUrl, params);

export const updateTransaction = (params: UpdateTransactionType) => httpHelper.put(baseUrl, params);