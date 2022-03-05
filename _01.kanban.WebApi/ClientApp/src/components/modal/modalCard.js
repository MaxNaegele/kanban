import React, { useRef, useEffect } from "react";
import { Row, Col, Form, Input, Modal, Select, TimePicker, DatePicker } from "antd";
import { ExclamationCircleOutlined, CheckOutlined, CloseOutlined } from "@ant-design/icons";

export default function Index({ form, onSave, team, showModal, closeModal, grpId }) {


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

    const onFinish = values => {
        values.GrpId = grpId;
        onSave(values);
        // form.resetFields();
    }

    return (
        <Modal centered
            title="Criar tarefa"
            visible={showModal}
            onCancel={onCloseModal}
            onOk={() => form.submit()}
            okText={
                <>
                    <CheckOutlined /> Salvar
                </>
            }
            cancelText={
                <>
                    <CloseOutlined /> Cancelar
                </>
            }
            maskClosable={false}
        >
            <Form layout="vertical" form={form} name="form" onFinish={onFinish}>
                <Row align="middle" gutter={[8, 0]}>
                    <Col span={16}>
                        <Form.Item
                            rules={[{ required: true, message: `O titulo deve ser informado!` }]}
                            name="CrdTitle"
                            label="Titulo tarefa:">
                            <Input placeholder="Titulo da tarefa" />
                        </Form.Item>
                    </Col>
                    <Col span={6}>
                        <Form.Item
                            name="SttId"
                            label="Status:">
                            <Select allowClear >
                                <Select.Option style={{color: 'green'}} value={1}>EM DIA</Select.Option>
                                <Select.Option style={{color: 'yellow'}} value={2}>ATENÇÃO</Select.Option>
                                <Select.Option style={{color: 'red'}} value={3}>EM ATRASO</Select.Option>
                            </Select>
                        </Form.Item>
                    </Col>
                </Row>
                <Row align="middle" gutter={[8, 0]}>
                    <Col span={22}>
                        <Form.Item
                            rules={[{ required: true, message: `O departamento deve ser informado!` }]}
                            name="DptName"
                            label="Departamento:">
                            <Input placeholder="Informe o departamento" />
                        </Form.Item>
                    </Col>
                </Row>
                <Row align="middle" gutter={[8, 0]}>
                    <Col span={22}>
                        <Form.Item
                            name="Uses"
                            label="Colaboradores:">
                            <Select mode="multiple" allowClear>
                                {team.map((item) => <Select.Option key={item.id} value={JSON.stringify(item)}>{item.name}</Select.Option>)}
                            </Select>
                        </Form.Item>
                    </Col>
                </Row>
                <Row align="middle" justify="space-between" gutter={[0, 8]}>
                    <Col span={6}>
                        <Form.Item
                            rules={[{ required: true, message: `O Tempo Previsto deve ser informado!` }]}
                            name="CrdEstimatedTime"
                            label="Tempo Previsto:">
                            <TimePicker placeholder="Previsto" format='HH:mm' />
                        </Form.Item>
                    </Col>
                    <Col span={10} >
                        <Form.Item
                            rules={[{ required: true, message: `O Data Prevista deve ser informado!` }]}
                            name="CrdExpectedDate"
                            label="Data Prevista:">
                            <DatePicker format='DD/MM/YYYY' />
                        </Form.Item>
                    </Col>
                </Row>
                <Row align="middle" gutter={[8, 0]}>
                    <Col span={22}>
                        <Form.Item
                            name="CrdDescription"
                            label="Descrição:">
                            <Input.TextArea placeholder="Descrição da tarefa" />
                        </Form.Item>
                    </Col>
                </Row>
            </Form>
        </Modal>
    );
}