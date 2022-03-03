import React, { useState, useEffect } from 'react';
import { BoardItem, AddGroup, Modal } from '../../components';
import { useHistory } from 'react-router-dom';
import api from '../../services/api';
import './board.css';

export default function Index() {
    const history = useHistory();
    const [visibleModal, setVisibleModal] = useState(false);
    const [boards, setBoards] = useState([]);

    useEffect(() => {
        console.log('0 --------------------------------');
        loadBoards();
    }, [])

    const loadBoards = async () => {

        const response = await api.get(`Board`);
        console.log('response', response)
        if (response.status === 200) {
            setBoards(response.data);
        }
    }

    const onHandleClick = (id) => {
        history.push({
            pathname: `/group/`,
            state: { brdId: id },
        });
    }

    const onHandleClickCreatBoard = async values => {
        console.log('values', values)
        setVisibleModal(false);
        let result = await api.post(`Board`, values);
        onHandleClick(result.data.brdId);
    }

    return (
        <div className='bd010'>
            {boards.map((data, idx) => <BoardItem key={idx} title={data.brdName} onHandleClick={() => onHandleClick(data.brdId)} />)}

            <AddGroup title="Criar novo projeto +" onHandleClick={() => setVisibleModal(true)} />

            <Modal
                title="Cadastro de projeto"
                label="Nome do Projeto"
                name="BrdName"
                onSave={onHandleClickCreatBoard}
                showModal={visibleModal}
                closeModal={() => setVisibleModal(false)} />
        </div>
    );
}