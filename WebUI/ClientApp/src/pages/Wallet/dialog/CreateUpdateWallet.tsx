import { FC, useEffect, useState } from "react";
import { Button, Modal, Radio, Form, Input } from "antd";
import type { RadioChangeEvent } from "antd";
import { useWallet } from "../hook/useWallet";

type CreateUpdateWalletType = {
  isModalOpen: boolean;
  setIsModalOpen: (val: boolean) => void;
};
const onFinishFailed = (errorInfo: any) => {
  console.log("Failed:", errorInfo);
};

type FieldType = {
  name: string;
  balance: number;
  type: number;
};
type WalletType = { name: string; value: number };
const walletTypes: WalletType[] = [
  { name: "Cash", value: 1 },
  { name: "EWallet", value: 2 },
  { name: "Bank", value: 3 },
];
const CreateUpdateWallet: FC<CreateUpdateWalletType> = ({
  isModalOpen,
  setIsModalOpen,
}) => {
  const { getWallets, createWallet } = useWallet();
  const [form] = Form.useForm();
  const [isOpen, setIsOpen] = useState(false);

  const handleOk = () => form.submit();

  const handleClose = () => {
    setIsModalOpen(false);
  };

  useEffect(() => {
    setIsOpen(isModalOpen);
  }, [isModalOpen]);
  const [value, setValue] = useState(1);

  const onChange = (e: RadioChangeEvent) => {
    console.log("radio checked", e.target.value);
    setValue(e.target.value);
  };
  const onFinish = async (values: FieldType) => {
    const response = await createWallet(values);
    if (typeof response.data === 'number') {
      getWallets();
      handleClose();
    }
  };
  
  return (
    <Modal
      title="Create Wallet"
      open={isOpen}
      onOk={handleOk}
      onCancel={handleClose}
      footer={<Button type="primary" onClick={() => form.submit()}>Save</Button>}
    >
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
          label="Name"
          name="name"
          rules={[{ required: true, message: "Name is required." }]}
        >
          <Input />
        </Form.Item>

        <Form.Item<FieldType>
          label="Balance"
          name="balance"
          rules={[{ required: true, message: "Balance is required" }]}
        >
          <Input type="number" />
        </Form.Item>

        <Form.Item<FieldType> label="Type" name="type">
          <Radio.Group onChange={onChange} value={value}>
            {walletTypes.map((w: WalletType) => (
              <Radio value={w.value} key={w.value}>{w.name}</Radio>
            ))}
          </Radio.Group>
        </Form.Item>
      </Form>
    </Modal>
  );
};

export default CreateUpdateWallet;
