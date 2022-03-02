import React from "react";
import { Layout } from 'antd';

export default function Index() {
    return (
        <Layout.Header  className="header" style={{ height: 64, padding: 0 }}>
            <div className="logo" />
        </Layout.Header>
    );
}