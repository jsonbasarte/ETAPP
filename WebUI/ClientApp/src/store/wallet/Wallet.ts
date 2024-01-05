import { create } from "zustand";
import { getAllWallets, createWallet } from "../../services/wallet";

type WalletType = {
  balance: number;
  id: number;
  name: string;
  type: number;
  typeName: string;
};

type CreateWalletType = {
  balance: number;
  name: string;
  type: number;
};

export interface IWalletStore {
  wallets: WalletType[];
  getAllWallet: () => void;
  createNewWallet: (params: CreateWalletType) => any;
}

export const useWalletStore = create<IWalletStore>((set) => ({
  wallets: [],
  getAllWallet: async () => {
    const response = await getAllWallets();
    set({ wallets: await response.data });
  },
  createNewWallet: async (params: CreateWalletType) => {
    const response = await createWallet(params);
    return response;
  },
}));
