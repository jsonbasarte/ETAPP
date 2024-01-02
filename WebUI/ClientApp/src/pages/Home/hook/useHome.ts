import { useEffect, useState } from "react"
import { getAllWallets } from "../../../services/wallet"
import { getAllTransaction } from "../../../services/transaction"
import { ResponseStatuses } from "../../../utils/Statuses"

export type WalletType = {
    balance: number;
    id: number;
    name: string;
    type: number;
    typeName: string;
}

export type TransactionType = {
    description: string;
    date: string;
    type: string;
    walletName: string;
    amount: number;
}

export const useHome = () => {
    const [wallets, setWallets] = useState<WalletType[]>([]);
    const [transactions, setTransaction] = useState<TransactionType[]>([]);

    const getWallets = async () => {
        const response = await getAllWallets();
        if (response.status === ResponseStatuses.OK) setWallets(response.data);
    }

    const getTransactions = async () => {
        const response = await getAllTransaction();
        if (response.status === ResponseStatuses.OK) setTransaction(response.data);
    }

    useEffect(() => {
        getWallets();
        getTransactions();
    },[]);

    return {
        wallets,
        transactions
    }
}