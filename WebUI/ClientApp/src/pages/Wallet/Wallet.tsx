import { useState } from "react";
import { Flex, Typography, Table, Button } from "antd";
import { PlusOutlined, DeleteFilled } from "@ant-design/icons";
import type { ColumnsType } from "antd/es/table";
import { useWallet } from "./hook/useWallet";
import { WalletType } from "../../store/wallet/Wallet";
import CreateUpdateWallet from "./dialog/CreateUpdateWallet";

const Wallet = () => {
  const [isModalOpen, setIsModalOpen] = useState<boolean>(false);
  const { wallets, deleteWallet, getWallets } = useWallet();
  const deleteUserWallet = async (id: number) => {
    await deleteWallet(id);
    getWallets();
  };
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
    {
      title: "Action",
      key: "action",
      render: (_, item) => {
        return <div style={{ display: "flex", justifyContent: "flex-end" }}>
          <DeleteFilled className="text-danger" style={{ fontSize: "1.3em" }} onClick={() => {
          if (confirm("Are you sure you want to delete this wallet?")) {
            deleteUserWallet(item.id)
          }
        }} color="danger" />
        </div>;
      },
    },
  ];
  return (
    <Flex vertical>
      <Flex vertical gap={10}>
        <Flex vertical={false} justify="space-between">
          <Typography.Title level={3}>Wallet</Typography.Title>
          <Button
            type="primary"
            icon={<PlusOutlined />}
            onClick={() => setIsModalOpen(true)}
          >Create </Button>
        </Flex>
        <Table columns={columns} dataSource={wallets} />
      </Flex>
      <CreateUpdateWallet
        isModalOpen={isModalOpen}
        setIsModalOpen={setIsModalOpen}
      />
    </Flex>
  );
};

export default Wallet;
