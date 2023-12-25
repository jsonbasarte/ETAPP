import { useEffect, useState } from "react"
import { getAllWallets } from "../../../services/wallet"
import { ResponseStatuses } from "../../../utils/Statuses"

type WalletType = {
    balance: number;
    id: number;
    name: string;
    type: number;
    typeName: string;
}

export const useHome = () => {
    const [wallets, setWallets] = useState<WalletType[]>([]);

    const getWallets = async () => {
        const response = await getAllWallets();
        if (response.status === ResponseStatuses.OK) setWallets(response.data);
    }

    useEffect(() => {
        getWallets();
    },[]);

    return {
        wallets
    }
}