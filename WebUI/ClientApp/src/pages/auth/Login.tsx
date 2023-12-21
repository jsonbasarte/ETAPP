import React from "react";
import { LockOutlined, UserOutlined, ContainerFilled } from "@ant-design/icons";
import { Button, Checkbox, Form, Input, Col, Row } from "antd";
import httpHelper from "../../services/axios";
import { useNavigate } from "react-router-dom";

type FieldType = {
  username?: string;
  password?: string;
  remember?: string;
};

const Login: React.FC = () => {
  const navigate = useNavigate();
  const onFinish = async (values: any) => {
    const response = await httpHelper.post("/api/authentication/login", {
      username: values.username,
      password: values.password,
    });

    if (response.data?.statusCode) navigate("/", { replace: true });
  };

  const onFinishFailed = (errorInfo: any) => {
    console.log("Failed:", errorInfo);
  };

  return (
  <>
    <div style={{ display: "flex", justifyContent: "center", marginTop: 100, paddingBottom: 50 }}>
     Expense Tracker
    </div>
    <Row >
      <Col span={8} offset={8}>
        <Form
          name="normal_login"
          initialValues={{ remember: true }}
          onFinish={onFinish}
        >
          <Form.Item
            name="username"
            rules={[{ required: true, message: "Please input your Username!" }]}
          >
            <Input
            size="large"
              prefix={<UserOutlined className="site-form-item-icon" />}
              placeholder="Username"
            />
          </Form.Item>
          <Form.Item
          
            name="password"
            rules={[{ required: true, message: "Please input your Password!" }]}
          >
            <Input
            size="large"

              prefix={<LockOutlined className="site-form-item-icon" />}
              type="password"
              placeholder="Password"
            />
          </Form.Item>
          <Form.Item className="flex mt-5" style={{ marginTop: "50px" }}>
            <Button type="primary" htmlType="submit" style={{ width: "100%" }}>
              Log in
            </Button>
          </Form.Item>
        </Form>
      </Col>
    </Row>
  </>
  );
};

export default Login;
