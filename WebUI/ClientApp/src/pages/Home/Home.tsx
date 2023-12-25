import { useHome } from "./hook/useHome";

const Home = () => {
    const { wallets } = useHome();
    return <h1>Home {wallets.length}</h1>
};

export default Home;