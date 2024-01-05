import { Flex, Table, Tag, Typography, Button } from "antd";
import { PlusOutlined } from "@ant-design/icons";
import type { ColumnsType } from "antd/es/table";
import { TransactionType } from "./hook/useTransaction";
import { useTransaction } from "./hook/useTransaction";

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

const Transaction = () => {
  const { transactions } = useTransaction();
  return (
    <Flex vertical>
      <Flex vertical gap={10}>
        <Flex vertical={false} justify="space-between">
          <Typography.Title level={3}>Transaction</Typography.Title>
          <Button
            type="primary"
            shape="circle"
            icon={<PlusOutlined />}
            size="large"
          />
        </Flex>
        <Table columns={columns} dataSource={transactions} />
      </Flex>
    </Flex>
  );
};

export default Transaction;
