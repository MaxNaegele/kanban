import React, { useState, useEffect } from 'react';
import { Group, AddGroup, Modal } from '../../components';
import { useHistory } from 'react-router-dom';
import { useLocation } from "react-router-dom";
import api from '../../services/api';
import './group.css'

export default function Index() {
    const history = useHistory();
    const [visibleModal, setVisibleModal] = useState(false);
    const location = useLocation();

    const [groups, setGroups] = useState([]);
    const [search, setSearch] = useState("");

    useEffect(() => {
        console.log('location.state sdssadsasaaaaaaaaa', location.state)
        loadGroups();
    }, [search])

    const loadGroups = async () => {
        const response = await api.get(`Group?BrdId=${location.state.brdId}`);
        if (response.status === 200) {
            setGroups(response.data);
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

    return (
        <div className='container-group'>
            {groups.map((data, idx) => <Group key={idx} title={data.grpTitle} time="2" quantity={3} />)}

            <AddGroup title="Add Card + " onHandleClick={() => setVisibleModal(true)} />

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