import { Form } from "antd";
import { useState } from "react";
import { useWalletStore, IWalletStore } from "../../../store/wallet/Wallet";
import { ITransactionStore, useTransactionStore } from "../../../store/transaction/Transaction";


export const userCreateUpdateTransaction = () => {
    const [transactionType, setTransactionType] = useState<number | null>(null);
    const wallet = useWalletStore((state: IWalletStore) => state.wallets);
    const createTransaction = useTransactionStore((state: ITransactionStore) => state.createNewTransaction);
    const transactionDetails = useTransactionStore((state: ITransactionStore) => state.transactionDetails);
    const [form] = Form.useForm();
    const save = () => form.submit();

    return {
        setTransactionType,
        transactionType,
        save,
        form,
        wallet,
        createTransaction,
        transactionDetails,
    }
    
};