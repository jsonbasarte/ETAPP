import { useEffect } from "react"
import { ITransactionStore, useTransactionStore } from "../../../store/transaction/Transaction"


export const useTransaction = () => {
    const transaction = useTransactionStore((state: ITransactionStore) => state.transaction);
    const getAllTransaction = useTransactionStore((state: ITransactionStore) => state.getAllTransaction);
    const getTransactionById = useTransactionStore((state: ITransactionStore) => state.getTransactionDetails);

    useEffect(() => {
        getAllTransaction();
    },[]);

    return {
        getAllTransaction,
        getTransactionById,
        transaction
    }
}