import React from "react";
import { Layout, Menu } from 'antd';
import { AppstoreFilled, PlusCircleFilled } from '@ant-design/icons';

import iconCadastrar from '../../assets/icone-cadastrar.svg';
import bullseye from '../../assets/bullseye-arrow.svg';
import calendarClock from '../../assets/calendar-clock.svg';
import iconNotificacao from '../../assets/icone-notificacao.svg';
import iconConfigurar from '../../assets/icone-configurar.svg';
import iconFileChart from '../../assets/file-chart-outline.svg';
import logo from '../../assets/logo4.png';
import './menu.css'
export default function Index() {
    return (
        <Layout.Sider collapsed={true} theme="light" style={{ background: "#8CC587" }} >

            <div className="img-logo">
                <img className="logo" src={logo} />
            </div>
            <Menu style={{ background: "#8CC587" }}>
                <Menu.Item key="1" icon={<AppstoreFilled />} />
                <Menu.Item key="2">
                    <img src={iconNotificacao} />
                </Menu.Item>
                <Menu.Item key="3">
                    <img src={calendarClock} />
                </Menu.Item>
                <Menu.Item key="4">
                    <img src={bullseye} />
                </Menu.Item>
                <Menu.Item key="5">
                    <img src={iconFileChart} />
                </Menu.Item>
                <Menu.Item key="6">
                    <img src={iconCadastrar} />
                </Menu.Item>
                <Menu.Item key="7">
                    <img src={iconConfigurar} />
                </Menu.Item>
                <Menu.Item key="8" icon={<PlusCircleFilled />} />
            </Menu>
        </Layout.Sider>
    );
}