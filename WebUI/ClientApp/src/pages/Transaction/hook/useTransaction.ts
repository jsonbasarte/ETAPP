import { useEffect, useState } from "react"
import { getAllTransaction } from "../../../services/transaction"
import { ResponseStatuses } from "../../../utils/Statuses"

export type TransactionType = {
    description: string;
    date: string;
    type: string;
    walletName: string;
    amount: number;
}

export const useTransaction = () => {
    const [transactions, setTransaction] = useState<TransactionType[]>([]);

    const getTransactions = async () => {
        const response = await getAllTransaction();
        if (response.status === ResponseStatuses.OK) setTransaction(response.data);
    }

    useEffect(() => {
        getTransactions();
    },[]);

    return {
        transactions
    }
}