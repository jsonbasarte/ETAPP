import {
  useCategoryStore,
  ICategories,
} from "../../../store/category/Category";

export const useCategories = () => {
  const getAllCategories = useCategoryStore((state: ICategories) => state.getAllCategories);
  const categories = useCategoryStore((state: ICategories) => state.categories);

  return {
    getAllCategories,
    categories,
  };
};
