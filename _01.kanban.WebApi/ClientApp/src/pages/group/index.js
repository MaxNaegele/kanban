import React, { useState, useEffect } from 'react';
import { Group, AddGroup, Modal } from '../../components';
import { Form } from "antd";
import { useHistory } from 'react-router-dom';
import { useLocation } from "react-router-dom";
import api from '../../services/api';
import './group.css'

export default function Index() {
    const history = useHistory();
    const [visibleModal, setVisibleModal] = useState(false);
    const location = useLocation();
    const [form] = Form.useForm();
    const [groups, setGroups] = useState([]);
    const [updateList, setUpdateList] = useState(false);
    const [collaborators, setCollaborators] = useState([]);

    useEffect(() => {
        console.log('location.state sdssadsasaaaaaaaaa', location.state)
        loadGroups();
        getCollaborators();
    }, [])



    const loadGroups = async () => {
        const response = await api.get(`Group?BrdId=${location.state.brdId}`);
        if (response.status === 200) {
            setGroups(response.data);
        }
    }



    const getCollaborators = async () => {
        const response = await api.get(`User/GetAll`);
        console.log('response users', response);
        if (response.status === 200) {
            setCollaborators(response.data);
        }
    }


    const onHandleClickCreatGroup = async values => {
        console.log('values', values)
        setVisibleModal(false);
        values.BrdId = location.state.brdId;
        values.GrpSequence = groups.length + 1;
        await api.post(`Group`, values);
        loadGroups();
    }
    const onCreateCard = async values => {
        if (values) {
            // values.CrdSequence = cards.length + 1;
            values.Stt = getStatus(values.SttId);
            delete values.SttId;
            values.Dpts = [{DptName: values.DptName}];
            delete values.DptName;
            values.Uses = [];//values.Uses.map((x) => JSON.parse(x));
            values.CrdExpectedDate = new Date(values.CrdExpectedDate);
            values.CrdEstimatedTime = new Date(values.CrdEstimatedTime).toTimeString();
            let result = await api.post(`Card`, values);
            debugger
            form.resetFields();
            loadGroups();
            setUpdateList((prev)=> prev = !updateList);


            console.log('values', values);
            console.log('result', result);
        }
    }

    const getStatus = (id) => {
        let status = {};
        switch (id) {
            case 1:
                status = { SttDescription: 'EN DIA', SttColor: 'green' };
                break;
            case 2:
                status = { SttDescription: 'ATENÇÃO', SttColor: 'yellow' };
                break;
            case 3:
                status = { SttDescription: 'EM ATRASO', SttColor: 'red' };
                break;

            default:
                break;
        }
        return status;
    }

    return (
        <div className='container-group'>
            {groups.map((data, idx) => <Group
                key={idx}
                update={updateList}
                form={form}
                grpId={data.grpId}
                team={collaborators}
                onCreateCard={onCreateCard}
                title={data.grpTitle}
                time="2"
                quantity={3} />)}

            <AddGroup title="Add tarefa + " color='#8CC587' onHandleClick={() => setVisibleModal(true)} />

            <Modal
                title="Cadastro grupos "
                label="Nome grupo"
                name="GrpTitle"
                onSave={onHandleClickCreatGroup}
                showModal={visibleModal}
                closeModal={() => setVisibleModal(false)} />
        </div>
    );
}