import React, { useState } from "react";
import type { MenuProps } from "antd";
import { Menu } from "antd";
import {
  LaptopOutlined,
  NotificationOutlined,
  UserOutlined,
} from "@ant-design/icons";

const items2: MenuProps["items"] = [{
    key: 1,
    label: 'Home',
    icon: React.createElement(UserOutlined),
  },
  {
    key: 2,
    label: 'Transaction',
    icon: React.createElement(LaptopOutlined),
  },
  {
    key: 3,
    label: 'Wallet',
    icon: React.createElement(NotificationOutlined),

  }]

const SidebarMenu: React.FC = () => {
  const onClick: MenuProps['onClick'] = (e) => {
    console.log('click ', e);
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
