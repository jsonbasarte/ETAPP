import { useEffect } from "react";
import { IWalletStore, useWalletStore } from "../../../store/wallet/Wallet";

export const useWallet = () => {

  const getWallets = useWalletStore((state: IWalletStore) => state.getAllWallet);
  const createWallet = useWalletStore((state: IWalletStore) => state.createNewWallet)
  const wallets = useWalletStore((state: IWalletStore) => state.wallets);

  useEffect(() => {
    getWallets();
  }, []);

  return {
    wallets,
    getWallets,
    createWallet,
  };
};
