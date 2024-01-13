import { create } from "zustand";
import { 
    createTransaction, 
    getAllTransaction, 
    CreateTransactionType, 
    UpdateTransactionType, 
    updateTransaction,
    getTransactionById,
} from "../../services/transaction";

export type TransactionType = {
    description: string;
    date: string;
    type: string;
    typeId: number;
    walletName: string;
    amount: number;
}

export interface ITransactionStore {
    transaction: TransactionType[],
    transactionDetails: TransactionType | null,
    createNewTransaction: (params: CreateTransactionType) => any,
    getAllTransaction: () => void,
    getTransactionDetails: (id: number) => void
}

export const useTransactionStore = create<ITransactionStore>((set) => ({
    transaction: [],
    transactionDetails: null,
    getAllTransaction: async () => {
        const response = await getAllTransaction();
        set({ transaction: await response.data });
    },
    getTransactionDetails: async (id: number) => {
        const response = await getTransactionById(id)
        set({ transactionDetails: await response.data });
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