import { useEffect, Suspense } from "react";
import { Outlet } from "react-router";

import { Layout, theme } from "antd";

const { Content, Footer, Sider } = Layout;

import SidebarMenu from "./SidebarMenu";
import AppHeader from "./AppHeader";
import useApp from "../../hooks/useApp";

const MainApp = () => {

  const { getCurrentUser } = useApp();

  const {
    token: { colorBgContainer, borderRadiusLG },
  } = theme.useToken();

  useEffect(() => {
    getCurrentUser();
  }, []);
  
  return (
    <Layout>
      <AppHeader></AppHeader>
      <Content>
        <Layout
          style={{
            padding: "24px 0",
            background: colorBgContainer,
            borderRadius: borderRadiusLG,
          }}
        >
          <Sider style={{ background: colorBgContainer }} width={200}>
            <SidebarMenu />
          </Sider>
          <Content style={{ padding: "0 24px", minHeight: 280 }}>
            <Suspense fallback={ <h1>Error</h1> }>
            <Outlet />
            </Suspense>
          </Content>
        </Layout>
      </Content>
      <Footer style={{ textAlign: "center" }}>
        Ant Design ©2023 Created by Ant UED
      </Footer>
    </Layout>
  );
};

export default MainApp;
