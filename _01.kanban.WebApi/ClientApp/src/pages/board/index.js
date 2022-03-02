import React, { useState, useEffect } from 'react';
import { BoardItem } from '../../components';
import './board.css';

export default function Index() {

    const [boards, setBoards] = useState([]);

    useEffect(() => {

    }, [])

    const loadBoards = () => {

    }

    return (
        <div className='bd010'>        
            <BoardItem title="Aguardando" time="2" quantity={3} />
            <BoardItem title="Aguardando" time="2" quantity={3} />
            <BoardItem title="Aguardando" time="2" quantity={3} />
            <BoardItem title="Aguardando" time="2" quantity={3} />
            <BoardItem title="Aguardando" time="2" quantity={3} />
            <BoardItem title="Aguardando" time="2" quantity={3} />
            <BoardItem title="Aguardando" time="2" quantity={3} />
            <BoardItem title="Aguardando" time="2" quantity={3} />
            <BoardItem title="Aguardando" time="2" quantity={3} />
            <BoardItem title="Aguardando" time="2" quantity={3} />
        </div>
    );
}