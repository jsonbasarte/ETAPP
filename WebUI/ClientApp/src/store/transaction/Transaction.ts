import { create } from "zustand";
import { 
    createTransaction, 
    getAllTransaction, 
    CreateTransactionType, 
    UpdateTransactionType, 
    updateTransaction 
} from "../../services/transaction";

export type TransactionType = {
    description: string;
    date: string;
    type: string;
    walletName: string;
    amount: number;
}

export interface ITransactionStore {
    transaction: [],
    createNewTransaction: (params: CreateTransactionType) => any,
    getAllTransaction: () => void
}

export const useTransactionStore = create<ITransactionStore>((set) => ({
    transaction: [],
    getAllTransaction: async () => {
        const response = await getAllTransaction();
        set({ transaction: await response.data });
    },
    createNewTransaction: async (params: CreateTransactionType) => {
        const response = await createTransaction(params);
        console.log('store response: ', response);
        return response.data;
    },
    updateTransaction: async (params: UpdateTransactionType) => {
        const response = await updateTransaction(params);
        return response;
    }
}));