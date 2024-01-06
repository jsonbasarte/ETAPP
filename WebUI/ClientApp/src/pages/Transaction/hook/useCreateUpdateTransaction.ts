import { Form } from "antd";
import { useState } from "react";
import { useWalletStore, IWalletStore } from "../../../store/wallet/Wallet";

export type FieldType = {
    description: string;
    amount: number;
    categoryId: number;
    walletId: number;
  };

export const userCreateUpdateTransaction = () => {
    const [transactionType, setTransactionType] = useState<number | null>(null);
    const wallet = useWalletStore((state: IWalletStore) => state.wallets);

    const [form] = Form.useForm();
    const save = () => form.submit();
   
  
    const onFinish = async (values: FieldType) => {
      console.log('values: ', values);
    };

    return {
        setTransactionType,
        transactionType,
        onFinish,
        save,
        form,
        wallet
    }
    
};