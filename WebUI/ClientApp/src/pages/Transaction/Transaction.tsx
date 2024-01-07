import { useState } from "react";
import { Flex, Table, Tag, Typography, Button } from "antd";
import { PlusOutlined } from "@ant-design/icons";
import type { ColumnsType } from "antd/es/table";
import { TransactionType } from "../../services/transaction";
import { useTransaction } from "./hook/useTransaction";
import CreateUpdateTransaction from "./dialog/CreateUpdateTransaction";

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
  const [isModalOpen, setIsModalOpen] = useState<boolean>(false);

  const { transaction } = useTransaction();
  return (
    <Flex vertical>
      <Flex vertical gap={10}>
        <Flex vertical={false} justify="space-between">
          <Typography.Title level={3}>Transaction</Typography.Title>
          <Button
            type="primary"
            icon={<PlusOutlined />}
            onClick={() => setIsModalOpen(true)}
          >
            Create
          </Button>
        </Flex>
        <Table columns={columns} dataSource={transaction} />
      </Flex>
      <CreateUpdateTransaction
        isModalOpen={isModalOpen}
        setIsModalOpen={setIsModalOpen}
      />
    </Flex>
  );
};

export default Transaction;
