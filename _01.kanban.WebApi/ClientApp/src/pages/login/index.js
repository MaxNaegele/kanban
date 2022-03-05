import React, { useState } from "react";
import { Form, Input, Layout, Row, Button, Col } from 'antd';
import { UnlockFilled, MailOutlined, UserOutlined } from '@ant-design/icons';
import { useHistory } from 'react-router-dom';
import { setToken } from '../../services/authorize';
import api from '../../services/api';
import './style.css';
import logo from '../../assets/logo4@2x.png';
export default function Login() {

    const [form] = Form.useForm();
    const history = useHistory();
    const [visible, setVisible] = useState(false);
    const [loadLogin, setLoadLogin] = useState(false);
    const [loadRegister, setLoadRegister] = useState(false);

    const executLogin = values => {
        setLoadLogin(true);
        api.post(`User/Login`, values).then(response => {
            console.log('response', response);
            if (response.status === 201 || response.status === 200) {
                setToken(response.data);
                history.push('home/board');
            } else if (response.status === 401) {
                alert("Usuário ou senha inválidos, tente novamente!");
            }
            else {
                alert("Não foi possível localizar seu usuário no momento!");
            }
        }).catch(e => {
            alert("Usuário ou senha inválidos!");

            console.log('e.erros', e)
        }).finally(() => setLoadLogin(false));

    };

    const onFinishCreateUser = async values => {
        setLoadRegister(true);
        api.post(`User`, values).then(response => {
            console.log('response', response);
            if (response.status === 201) {
                setToken(response.data);
                history.push('home/board');
            } else {
                alert("Não foi possível criar seu usuário neste momento!");
            }
        }).catch(e => {
            console.log('e.erros', e)
            alert("Não foi possível criar seu usuário neste momento!");
        }).finally(() => setLoadRegister(false));

    }

    return (
        <Layout className="h-100p">
            <Layout.Content className="b-s h-100p" >

                <Row style={{ marginTop: "10%", textAlign: 'center' }} justify="center">

                    <Col span="24" style={{ zIndex: 10 }}>
                            <img className="u-i-l"  src={logo} />
                        <div >
                        </div>
                    </Col>
                </Row>
                <Row justify="center" style={{ marginTop: "2%" }}>
                    <div className="login-form">
                        {visible === false && <Form
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
                                        <Button className="e-s-l" type="link" onClick={() => setVisible(true)}>
                                            Não possui conta? Cadastre-se aqui.
                                        </Button>
                                    </Form.Item>
                                </Col>
                                <div className="l-l-c"></div>
                            </Row>
                        </Form>}

                        {visible &&
                            <Form
                                name="recoverPassword"
                                onFinish={onFinishCreateUser}>
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
                                            name="UseName"
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
                                            name="UseEmail"
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
                                            name="UsePassword"
                                            rules={[{ required: true, message: 'Informe uma senha.' }]}>
                                            <Input.Password className="i-s-g" placeholder="Informe uma senha. " prefix={<UnlockFilled />} />
                                        </Form.Item>
                                    </Col>
                                </Row>

                                <Row align="middle" justify="space-around">
                                    <Col span={6}>
                                        <Form.Item>
                                            <Button onClick={() => setVisible(false)}>
                                                VOLTAR
                                            </Button>
                                        </Form.Item>
                                    </Col>
                                    <Col span={14} offset={4}>
                                        <Form.Item>
                                            <Button disabled={loadRegister} loading={loadRegister} type="primary" htmlType="submit" className="s-b-l">
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