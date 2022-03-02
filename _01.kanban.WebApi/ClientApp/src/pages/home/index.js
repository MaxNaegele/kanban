import React, { useState } from 'react';
import { Layout } from 'antd';
import { Route, Switch, HashRouter } from "react-router-dom";

import './home.css';
import {
    Group,
    Board,
} from '../../pages';
import { Menu, Header } from '../../components';

export default function Index() {
    
    const [collapsed, setCollapsed] = useState(true);

    const onCollapse = () => {
        setCollapsed(!collapsed);
    }

    return (
        <div>
            <Header />
            <Layout>
                <Menu collapsed={collapsed} onCollapse={onCollapse} />
                <Layout.Content className='content'>
                    <HashRouter>
                        <Switch>
                            <Route>
                                <Route exact path='/' component={Group}></Route>
                                <Route exact path='/board' component={Board}></Route>
                            </Route>
                        </Switch>
                    </HashRouter>
                </Layout.Content>
            </Layout>
        </div>
    )
}
