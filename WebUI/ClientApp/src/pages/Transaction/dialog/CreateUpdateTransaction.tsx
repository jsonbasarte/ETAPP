import { FC, useEffect, useState } from "react";
import { Button, Modal, Form, Input, Select, Flex } from "antd";
import {
  userCreateUpdateTransaction,
  FieldType,
} from "../hook/useCreateUpdateTransaction";
import { WalletType } from "../../../store/wallet/Wallet";
import { useCategories } from "../../Categories/hook/useCategories";
import { useWallet } from "../../Wallet/hook/useWallet";

enum TransactionType {
  Credit = 1,
  Expense = 2,
}

type CreateUpdateTransactionType = {
  isModalOpen: boolean;
  setIsModalOpen: (val: boolean) => void;
};
const onFinishFailed = (errorInfo: any) => {
  console.log("Failed:", errorInfo);
};

const CreateUpdateTransaction: FC<CreateUpdateTransactionType> = ({
  isModalOpen,
  setIsModalOpen,
}) => {
  const { getAllCategories, categories } = useCategories();
  const { getWallets } = useWallet();
  const [isOpen, setIsOpen] = useState(false);

  const { onFinish, save, form, wallet, transactionType, setTransactionType } =
    userCreateUpdateTransaction();

  const handleClose = () => {
    setIsModalOpen(false);
  };

  useEffect(() => {
    setIsOpen(isModalOpen);
  }, [isModalOpen]);

  useEffect(() => {
    getAllCategories();
    getWallets();
  }, []);

  const title =
    transactionType === null
      ? null
      : transactionType === TransactionType.Credit
      ? "Credit"
      : "Expense";

  return (
    <Modal
      closable={false}
      title={title}
      open={isOpen}
      onOk={save}
      onCancel={handleClose}
      afterClose={() => setTransactionType(null)}
      footer={
        transactionType ? (
          <>
            <Button type="link" onClick={() => setTransactionType(null)}>
              Cancel
            </Button>
            <Button type="primary" onClick={() => form.submit()}>
              Save
            </Button>
          </>
        ) : null
      }
    >
      {!transactionType ? (
        <Flex vertical={false} flex="column" gap={3}>
          <Flex
            flex={1}
            justify="center"
            align="center"
            onClick={() => setTransactionType(TransactionType.Credit)}
            style={{ height: 80 }}
          >
            Credit
          </Flex>
          <Flex
            flex={1}
            justify="center"
            align="center"
            onClick={() => setTransactionType(TransactionType.Expense)}
            style={{ height: 80 }}
          >
            Expense
          </Flex>
        </Flex>
      ) : (
        <Form
          className="mt-10"
          labelCol={{ span: 5 }}
          wrapperCol={{ span: 16 }}
          initialValues={{ remember: true }}
          onFinish={onFinish}
          onFinishFailed={onFinishFailed}
          autoComplete="off"
          form={form}
        >
          <Form.Item<FieldType>
            label="Description"
            name="description"
            rules={[{ required: true, message: "Description is required." }]}
          >
            <Input />
          </Form.Item>

          <Form.Item<FieldType>
            label="Amount"
            name="amount"
            rules={[{ required: true, message: "Amount is required" }]}
          >
            <Input type="number" />
          </Form.Item>
          <Form.Item
            label="Wallet"
            name="walletId"
            rules={[{ required: true, message: "Wallet is required" }]}
          >
            <Select>
              {wallet.map((prop: WalletType) => (
                <Select.Option value={prop.id} key={prop.id}>
                  {prop.name}
                </Select.Option>
              ))}
            </Select>
          </Form.Item>
          <Form.Item
            label="Category"
            rules={[{ required: true, message: "Category is required" }]}
          >
            <Select>
              {categories.map((prop: { name: string; id: number }) => (
                <Select.Option value={prop.id}>{prop.name}</Select.Option>
              ))}
            </Select>
          </Form.Item>
        </Form>
      )}
    </Modal>
  );
};

export default CreateUpdateTransaction;
