import httpHelper from "./axios";

const baseUrl = "/wallet";

type CreateWalletType = {
  balance: number;
  name: string;
  type: number;
};

export const getAllWallets = () => httpHelper.get(baseUrl);

export const createWallet = (params: CreateWalletType) => httpHelper.post(baseUrl, params);

export const deleteWallet = (id: number) => httpHelper.delete(baseUrl, { data: { id } });
