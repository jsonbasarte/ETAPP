import { create } from "zustand";
import { getAllCategories } from "../../services/category";

type CategoryType = {
    name: string;
    id: number;
}

export interface ICategories {
    categories: CategoryType[],
    getAllCategories: () => void;
}

export const useCategoryStore = create<ICategories>((set) => ({
    categories: [],
    getAllCategories: async () => {
        const response = await getAllCategories();
        set({ categories: await response.data });
    } 
}));