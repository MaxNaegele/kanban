import React, { useState, useEffect } from "react";
import './group.css';
import { ClockCircleOutlined } from '@ant-design/icons';
import { CardItem, ModalCard, AddGroup } from '../../components';
import api from '../../services/api';

export default function Index({form, title, time, quantity, onCreateCard, team, grpId }) {
    const [visibleModal, setVisibleModal] = useState(false);
    const [cards, setCards] = useState([]);

    useEffect(()=>getCards(),[]);
    
    const getCards = async () => {
        const response = await api.get(`Card?grpId=${grpId}`);
        console.log('response lista de cardssssss ===> ', response)
        if (response.status === 200) {
            setCards(response.data);
        }
    }

    return (
        <div className="container-board cont01">
            <div className="container-header-board">
                <span>{title}</span>
                <div className="bd10">
                    <div className="bd10">
                        <ClockCircleOutlined />
                        <span className="m-l2">{time}h</span>
                    </div>
                    <div className="qt10">{quantity}</div>
                </div>
            </div>
            <div className="list-cards">
                {cards.map((item, idx)=> <CardItem key={idx} data={item} />)}
                
                <AddGroup title="Add Card + " onHandleClick={() => setVisibleModal(true)} />
            </div>
            <ModalCard
            form={form}
                grpId={grpId}
                team={team}
                onSave={onCreateCard}
                showModal={visibleModal}
                closeModal={() => setVisibleModal(false)} />
        </div>
    );
}
