import React, { useState, useEffect } from 'react';
import { Group } from '../../components';
import { useHistory } from 'react-router-dom';
import './group.css'

export default function Index() {
    const history = useHistory();
    const [boards, setBoards] = useState([]);

    useEffect(() => {

    }, [])

    const loadBoards = () => {

    }
    const onHandleClick = () => {
        history.push('/board');
    }

    return (
        <div className='container-group'>        
            <Group title="Projeto numero 1" onHandleClick={onHandleClick}/>
            <Group title="Projeto numero 1" />
            <Group title="Projeto numero 1" />
            <Group title="Projeto numero 1" />
            <Group title="Projeto numero 1" />
            <Group title="Projeto numero 1" />
            <Group title="Projeto numero 1" />
        </div>
    );
}