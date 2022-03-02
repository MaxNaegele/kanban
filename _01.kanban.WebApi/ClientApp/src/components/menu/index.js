import React from "react";
import { Layout, Menu } from 'antd';
import {AppstoreFilled, PlusCircleFilled} from '@ant-design/icons';

import iconCadastrar from '../../assets/icone-cadastrar.svg';
import bullseye from '../../assets/bullseye-arrow.svg';
import calendarClock from '../../assets/calendar-clock.svg';
import iconNotificacao from '../../assets/icone-notificacao.svg';
import iconConfigurar from '../../assets/icone-configurar.svg';
import iconFileChart from '../../assets/file-chart-outline.svg';
import iconWork from '../../assets/work.svg';

export default function Index({ collapsed, onCollapse }) {
    return (
        <Layout.Sider collapsible collapsed={true}>
            <Menu theme="light" >
                <Menu.Item key="1" icon={<AppstoreFilled />} />
                <Menu.Item key="2">
                    <img src={iconNotificacao} />
                </Menu.Item>
                <Menu.Item key="3">
                    <img src={calendarClock}/>
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