import React, { useRef, useEffect } from "react";
import { Row, Col, Form, Input, Modal } from "antd";
import { ExclamationCircleOutlined, CheckOutlined, CloseOutlined } from "@ant-design/icons";

export default function Index({ title, label, name, onSave, showModal, closeModal }) {

    const [form] = Form.useForm();
    const inputLabel = useRef(null);

    useEffect(() => {
        if (inputLabel.current) {
            inputLabel.current.focus();
        }
    }, [inputLabel]);

    const onCloseModal = () => {
        Modal.confirm({
            title: 'Cancelar?',
            icon: <ExclamationCircleOutlined />,
            content: 'Deseja cancelar?',
            okText: 'Sim',
            cancelText: 'Não',
            centered: true,
            onOk() {
                form.resetFields();
                closeModal();
            }
        });
    };

    const onFinish = values =>{
        onSave(values);
        form.resetFields();
    } 

    return (
        <Modal centered
            title={title}
            visible={showModal}
            onCancel={onCloseModal}
            onOk={() => form.submit()}
            okText={
                <>
                    <CheckOutlined /> Definir
                </>
            }
            cancelText={
                <>
                    <CloseOutlined /> Cancelar
                </>
            }
            maskClosable={false}
        >
            <div>
                <Form layout="vertical" form={form} name="formModal" onFinish={onFinish}>
                    <Row align="middle" gutter={[8, 0]}>
                        <Col span={12}>
                            <Form.Item
                                rules={[{ required: true, message: `${label} deve ser informado!` }]}
                                name={name}
                                label={label}>
                                <Input ref={inputLabel} placeholder={label} />
                            </Form.Item>
                        </Col>

                    </Row>
                </Form>
            </div>
        </Modal>
    );
}