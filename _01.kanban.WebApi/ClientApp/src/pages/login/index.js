import React, { useState } from "react";
import { Form, Input, Layout, Row, Button, Col } from 'antd';
import { UnlockFilled, MailOutlined, UserOutlined } from '@ant-design/icons';
import { useHistory } from 'react-router-dom';
import './style.css'
export default function Login() {

    const [form] = Form.useForm();
    const history = useHistory();
    const [visible, setVisible] = useState(false);
    const [loadLogin, setLoadLogin] = useState(false);
    const [recoverPassword, setRecoverPassword] = useState(false);

    const [formUser] = Form.useForm();

    const executLogin = ({ email, password }) => {
        setLoadLogin(true);
        history.push('home/board');

    };

    const onFinishRecoverPassword = () => { }

    return (
        <Layout className="h-100p">
            <Layout.Content className="b-s h-100p" >

                <Row style={{ marginTop: "10%", textAlign: 'center' }} justify="center">

                    <Col span="24" style={{ zIndex: 10 }}>
                        <div className="u-i-l">
                            <UserOutlined />
                        </div>
                    </Col>
                </Row>
                <Row justify="center" style={{ marginTop: "2%" }}>
                    <div className="login-form">
                        {recoverPassword === false && <Form
                            form={form}
                            onFinish={executLogin}>
                            <Row align="middle" justify="center">
                                <Col span={24}>
                                    <div className="l-l-c" style={{ marginTop: '-80px', background: '#b14e7c' }}></div>
                                </Col>
                            </Row>
                            <Row align="middle">
                                <Col span={24}>
                                    <Form.Item
                                        className="i-s-g"
                                        label=""
                                        name="email"
                                        rules={[{ required: true, message: 'Informe seu e-mail.' }]}>
                                        <Input className="i-s-g" placeholder="Informe seu e-mail" prefix={<MailOutlined />} />
                                    </Form.Item>
                                </Col>
                            </Row>
                            <Row>
                                <Col span={24}>
                                    <Form.Item
                                        className="i-s-g"
                                        label=""
                                        name="password"
                                        rules={[{ required: true, message: 'Informe seu senha.' }]}>
                                        <Input.Password className="i-s-g" placeholder="Informe sua senha" prefix={<UnlockFilled />} />
                                    </Form.Item>
                                </Col>
                            </Row>
                            <Row align="middle" justify="center">
                                <Col span={24}>
                                    <Form.Item>
                                        <Button type="primary" loading={loadLogin} htmlType="submit" className="s-b-l">
                                            ENTRAR
                                        </Button>
                                    </Form.Item>
                                </Col>
                            </Row>
                            <Row align="middle" justify="center">
                                <Col span={24}>
                                    <Form.Item>
                                        <Button className="e-s-l" type="link" onClick={() => setRecoverPassword(true)}>
                                            Não possui conta? Cadastre-se aqui.
                                        </Button>
                                    </Form.Item>
                                </Col>
                                <div className="l-l-c"></div>
                            </Row>
                        </Form>}

                        {recoverPassword &&
                            <Form
                                name="recoverPassword"
                                onFinish={onFinishRecoverPassword}>
                                <Row align="middle" justify="center">
                                    <Col span={24}>
                                        <div className="l-l-c" style={{ marginTop: '-80px', background: '#b14e7c' }}></div>
                                    </Col>
                                </Row>
                                <Row align="middle">
                                    <Col span={24}>
                                        <Form.Item
                                            className="i-s-g"
                                            label=""
                                            name="useName"
                                            rules={[{ required: true, message: 'Informe seu nome.' }]}>
                                            <Input className="i-s-g" placeholder="Informe seu nome" prefix={<UserOutlined />} />
                                        </Form.Item>
                                    </Col>
                                </Row>
                                <Row align="middle">
                                    <Col span={24}>
                                        <Form.Item
                                            className="i-s-g"
                                            label=""
                                            name="useEmail"
                                            rules={[{ required: true, message: 'Informe seu e-mail.' }]}>
                                            <Input className="i-s-g" placeholder="Informe seu e-mail" prefix={<MailOutlined />} />
                                        </Form.Item>
                                    </Col>
                                </Row>
                                <Row align="middle">
                                    <Col span={24}>
                                        <Form.Item
                                            className="i-s-g"
                                            label=""
                                            name="usePassword"
                                            rules={[{ required: true, message: 'Informe uma senha.' }]}>
                                            <Input.Password className="i-s-g" placeholder="Informe uma senha. " prefix={<UnlockFilled />} />
                                        </Form.Item>
                                    </Col>
                                </Row>

                                <Row align="middle" justify="space-around">
                                    <Col span={6}>
                                        <Form.Item>
                                            <Button onClick={() => setRecoverPassword(false)}>
                                                VOLTAR
                                            </Button>
                                        </Form.Item>
                                    </Col>
                                    <Col span={14} offset={4}>
                                        <Form.Item>
                                            <Button type="primary" htmlType="submit" className="s-b-l">
                                                CADASTRAR
                                            </Button>
                                        </Form.Item>
                                    </Col>
                                </Row>
                            </Form>
                        }

                    </div>                   
                </Row>
            </Layout.Content>
        </Layout>
    );
}