import { useHome } from "./hook/useHome";
import {
  Col,
  Row,
  Statistic,
  Flex,
  Card,
  Space,
  Table,
  Tag,
  Typography,
} from "antd";
import { WalletType, TransactionType } from "./hook/useHome";
import type { ColumnsType } from "antd/es/table";
const { Title, Link } = Typography;
const baseStyle: React.CSSProperties = {
  width: "25%",
  height: 54,
};
interface DataType {
  key: string;
  name: string;
  age: number;
  address: string;
  tags: string[];
}

const columns: ColumnsType<TransactionType> = [
  {
    title: "Description",
    dataIndex: "description",
    key: "name",
    render: (text) => <a>{text}</a>,
  },
  {
    title: "Date",
    dataIndex: "date",
    key: "date",
  },
  {
    title: "Type",
    dataIndex: "type",
    key: "type",
  },
  {
    title: "Wallet",
    key: "walletName",
    dataIndex: "walletName",
    render: (text) => (
      <>
        {/* let color = tag.length > 5 ? 'geekblue' : 'green'; */}

        <Tag color={"green"}>{text.toUpperCase()}</Tag>
      </>
    ),
  },
  {
    title: "Amount",
    key: "amount",
    dataIndex: "amount",
  },
];

const data: DataType[] = [
  {
    key: "1",
    name: "John Brown",
    age: 32,
    address: "New York No. 1 Lake Park",
    tags: ["nice", "developer"],
  },
  {
    key: "2",
    name: "Jim Green",
    age: 42,
    address: "London No. 1 Lake Park",
    tags: ["loser"],
  },
  {
    key: "3",
    name: "Joe Black",
    age: 32,
    address: "Sydney No. 1 Lake Park",
    tags: ["cool", "teacher"],
  },
];
const Home = () => {
  const { wallets, transactions } = useHome();
  return (
    <Flex vertical gap={50}>
      <Flex vertical>
        <Title level={3}>Wallet</Title>
        <Flex vertical={false} gap={10}>
          {wallets.map((wallet: WalletType, i) => (
            <div key={i} style={{ ...baseStyle }}>
              <Statistic title={wallet.name} value={wallet.balance} />
            </div>
          ))}
        </Flex>
      </Flex>
      <Flex vertical gap={10}>
        <Title level={3}>Transactions</Title>
        <Table columns={columns} dataSource={transactions} />
      </Flex>
    </Flex>
  );
};

export default Home;
