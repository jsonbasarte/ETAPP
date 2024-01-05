import { useState } from "react";
import { Flex, Typography, Table, Button } from "antd";
import { PlusOutlined } from "@ant-design/icons";
import type { ColumnsType } from "antd/es/table";
import { WalletType, useWallet } from "./hook/useWallet";
import CreateUpdateWallet from "./modal/CreateUpdateWallet";

const columns: ColumnsType<WalletType> = [
  {
    title: "Name",
    dataIndex: "name",
    key: "name",
  },
  {
    title: "Type",
    dataIndex: "type",
    key: "type",
  },
  {
    title: "Balance",
    key: "balance",
    dataIndex: "balance",
  },
];

const Wallet = () => {
  const [isModalOpen, setIsModalOpen] = useState<boolean>(false);
  const { wallets } = useWallet();
  return (
    <Flex vertical>
      <Flex vertical gap={10}>
        <Flex vertical={false} justify="space-between">
          <Typography.Title level={3}>Wallet</Typography.Title>
          <Button
            type="primary"
            shape="circle"
            icon={<PlusOutlined />}
            size="large"
            onClick={() => setIsModalOpen(true)}
          />
        </Flex>
        <Table columns={columns} dataSource={wallets} />
      </Flex>
      <CreateUpdateWallet isModalOpen={isModalOpen} setIsModalOpen={setIsModalOpen} />
    </Flex>
  );
};

export default Wallet;
