import React, { useState } from "react";
import type { MenuProps } from "antd";
import { Menu } from "antd";
import {
  LaptopOutlined,
  NotificationOutlined,
  UserOutlined,
} from "@ant-design/icons";
import { useNavigate } from "react-router-dom";

const items2: MenuProps["items"] = [{
    key: 'home',
    label: 'Home',
    icon: React.createElement(UserOutlined),
  },
  {
    key: 'transaction',
    label: 'Transaction',
    icon: React.createElement(LaptopOutlined),
  },
  {
    key: 'wallet',
    label: 'Wallet',
    icon: React.createElement(NotificationOutlined),

  }]

const SidebarMenu: React.FC = () => {
  const navigate = useNavigate();
  const onClick: MenuProps['onClick'] = (e) => {
    console.log('click ', e);
    if (e.key === 'home') 
      navigate('')
    else 
      navigate(e.key)
  };

  return (
    <Menu
      mode="inline"
      onClick={onClick}
      defaultSelectedKeys={["1"]}
      defaultOpenKeys={["sub1"]}
      style={{ height: "100%" }}
      items={items2}
    />
  );
};

export default SidebarMenu;
