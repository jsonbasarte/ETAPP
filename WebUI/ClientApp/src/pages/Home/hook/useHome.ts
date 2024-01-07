import { useEffect } from "react";
import {
  ITransactionStore,
  useTransactionStore,
} from "../../../store/transaction/Transaction";
import { IWalletStore, useWalletStore } from "../../../store/wallet/Wallet";

export type WalletType = {
  balance: number;
  id: number;
  name: string;
  type: number;
  typeName: string;
};

export type TransactionType = {
  description: string;
  date: string;
  type: string;
  walletName: string;
  amount: number;
};

export const useHome = () => {
  const getAllTransaction = useTransactionStore(
    (state: ITransactionStore) => state.getAllTransaction
  );
  const transactions = useTransactionStore(
    (state: ITransactionStore) => state.transaction
  );
  const getAllWallet = useWalletStore(
    (state: IWalletStore) => state.getAllWallet
  );
  const wallets = useWalletStore((state: IWalletStore) => state.wallets);

  useEffect(() => {
    getAllWallet();
    getAllTransaction();
  }, []);

  return {
    wallets,
    transactions,
  };
};
