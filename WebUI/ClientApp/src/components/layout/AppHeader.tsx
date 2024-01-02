import { Layout } from "antd";
import type { MenuProps } from "antd";
import { Dropdown, Avatar } from "antd";
import { UserOutlined } from "@ant-design/icons";
import httpHelper from "../../services/axios";
import { useNavigate } from "react-router-dom";

const AppHeader = () => {
  const navigate = useNavigate();
  const items: MenuProps["items"] = [
    {
      key: "1",
      label: (
        <a
          onClick={async () => {
            const response = await httpHelper.post(
              "/authentication/logout"
            );
            if (response.status === 200) navigate("/login", { replace: true });
            console.log("response: ", response);
          }}
        >
          Logout
        </a>
      ),
    },
  ];
  return (
    <Layout.Header
      style={{
        position: "sticky",
        top: 0,
        zIndex: 1,
        width: "100%",
        display: "flex",
        justifyContent: "space-between",
        alignItems: "center",
        background: "white",
        borderBottom: "1px solid #e3e3e3",
      }}
    >
      <div>Expense Tracker</div>

      <Dropdown menu={{ items }} placement="bottomRight" arrow>
        <Avatar
          style={{ backgroundColor: "#87d068" }}
          icon={<UserOutlined />}
        />
      </Dropdown>
    </Layout.Header>
  );
};

export default AppHeader;
