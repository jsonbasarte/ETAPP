import React, { useEffect } from 'react'
import { Button, Checkbox, Form, Input } from 'antd'
import httpHelper from '../services/axios'

const onFinish = async (values: any) => {
    const response = await httpHelper.post("/api/authentication/login", {
        username: values.username,
        password: values.password,
    });
  console.log('Success:', response);
}

const onFinishFailed = (errorInfo: any) => {
  console.log('Failed:', errorInfo)
}

type FieldType = {
  username?: string
  password?: string
  remember?: string
}

const Login: React.FC = () => {
  useEffect(() => {
    const getCurrentUser = async () => {
      // const response = await axios.get('/api/authentication/current-user')
      const response = await httpHelper.get('/api/authentication/current-user');
      console.log('response: ', response)
    }
    getCurrentUser()
  }, [])
  return (
    <div>
      <button onClick={async () => {
        const response = await httpHelper.post("/api/authentication/logout");
        console.log('response: ', response);
      }}>Logout</button>
    <Form
      name='basic'
      labelCol={{ span: 8 }}
      wrapperCol={{ span: 16 }}
      style={{ maxWidth: 600 }}
      initialValues={{ remember: true }}
      onFinish={onFinish}
      onFinishFailed={onFinishFailed}
      autoComplete='off'
    >
      <Form.Item<FieldType>
        label='Username'
        name='username'
        rules={[{ required: true, message: 'Please input your username!' }]}
      >
        <Input />
      </Form.Item>

      <Form.Item<FieldType>
        label='Password'
        name='password'
        rules={[{ required: true, message: 'Please input your password!' }]}
      >
        <Input.Password />
      </Form.Item>

      <Form.Item<FieldType>
        name='remember'
        valuePropName='checked'
        wrapperCol={{ offset: 8, span: 16 }}
      >
        <Checkbox>Remember me</Checkbox>
      </Form.Item>

      <Form.Item wrapperCol={{ offset: 8, span: 16 }}>
        <Button type='primary' htmlType='submit'>
          Submit
        </Button>
      </Form.Item>
    </Form></div>
  )
}

export default Login
