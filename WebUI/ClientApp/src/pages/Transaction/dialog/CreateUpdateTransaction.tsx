import { FC, useEffect, useState } from "react";
import { Button, Modal, Form, Input, Select, Flex } from "antd";
import { userCreateUpdateTransaction } from "../hook/useCreateUpdateTransaction";
import { WalletType } from "../../../store/wallet/Wallet";
import { useCategories } from "../../Categories/hook/useCategories";
import { useTransaction } from "../hook/useTransaction";
import { useWallet } from "../../Wallet/hook/useWallet";
import { CreditCardFilled, WalletFilled } from "@ant-design/icons";

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
export type FieldType = {
  description: string;
  amount: number;
  categoryId: number;
  walletId: number;
};
const CreateUpdateTransaction: FC<CreateUpdateTransactionType> = ({
  isModalOpen,
  setIsModalOpen,
}) => {
  const { getAllCategories, categories } = useCategories();
  const { getAllTransaction } = useTransaction();
  const { getWallets } = useWallet();
  const [isOpen, setIsOpen] = useState(false);

  const { save, form, wallet, transactionType, setTransactionType, createTransaction, transactionDetails } =
    userCreateUpdateTransaction();

  const onFinish = async (values: FieldType) => {
    const response = await createTransaction({ ...values, transactionType });
    console.log(response)
    if (typeof response === 'number') {
        getAllTransaction();
        handleClose();
    }
    console.log("response: ", response);
  };

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

  useEffect(() => {
    if (transactionDetails) {
      setTransactionType(transactionDetails.typeId);
    }
    console.log('transactionDetails: ', transactionDetails)
  }, [transactionDetails])

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
      width={transactionType ? 500 : 300}
      onCancel={handleClose}
      afterClose={() => {
        setTransactionType(null);
        form.resetFields();
      }}
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
            vertical
            className="cursor-pointer"
            onClick={() => setTransactionType(TransactionType.Credit)}
            style={{ height: 80 }}
          >
            <CreditCardFilled
              className="text-primary"
              style={{ fontSize: "3em" }}
            />
            Credit
          </Flex>
          <Flex
            flex={1}
            justify="center"
            align="center"
            vertical
            className="cursor-pointer"
            onClick={() => setTransactionType(TransactionType.Expense)}
            style={{ height: 80 }}
          >
            <WalletFilled
              className="text-primary"
              style={{ fontSize: "3em" }}
            />
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
            name="categoryId"
            rules={[{ required: true, message: "Category is required" }]}
          >
            <Select>
              {categories.map((prop: { name: string; id: number }) => (
                <Select.Option value={prop.id} key={prop.id}>
                  {prop.name}
                </Select.Option>
              ))}
            </Select>
          </Form.Item>
        </Form>
      )}
    </Modal>
  );
};

export default CreateUpdateTransaction;
