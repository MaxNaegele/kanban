import React from "react";
import './card.css';
import { CalendarOutlined, ClockCircleOutlined } from '@ant-design/icons';
import LetteredAvatar from 'react-lettered-avatar';
import { ButtonStatus } from '../../components';
export default function Index({ data: { crdId, dpts, crdTitle, crdExpectedDate, crdDescription, crdEstimatedTime, stt, uses } }) {
    return (
        <div className="container-master-card">
            <div className="container-card">
                <div className="head01">
                    <div>
                        {dpts.map((item) => <div className="font-label01 head02">{item.dptName}</div>)}
                    </div>
                    <div className="head03">
                        <small>Código:</small>
                        <span>#{crdId}</span>
                    </div>
                </div>
                <div className="titl01">
                    <span className="font-label1">{crdTitle}</span>
                </div>
                <div className="prj01">
                    <div className="prj02">
                        <small>Projeto:</small>
                        <span className="font-label1">Company</span>
                    </div>
                    <div className="head03">
                        <small>Prevista:</small>
                        <div className="prj03 font-label1">
                            <CalendarOutlined />
                            <span className="m-g-l">{new Date(crdExpectedDate).toLocaleDateString()}</span>
                        </div>
                    </div>
                </div>
                <div className="bd01">
                    <div>
                        <small>Descrição:</small>
                        <p>{crdDescription}</p>
                    </div>
                </div>
            </div>
            <div className="line-vertical">
                Acompanhamento
            </div>
            <div className="container-card">
                <div className="prj01">
                    <div className="prj04">
                        <div className="prj05">
                            <ClockCircleOutlined />
                        </div>
                        <div className="prj02">
                            <small>Previsto:</small>
                            <span className="font-label1">{crdEstimatedTime}</span>
                        </div>
                    </div>
                    <div className="head03">
                        <ButtonStatus description={stt.sttDescription} color={stt.sttColor} />
                    </div>
                </div>
                <div className="prj01">
                    <div className="prj04">
                        <div className="prj05">
                            <ClockCircleOutlined />
                        </div>
                        <div className="prj02">
                            <small>Saldo:</small>
                            <div className="head02">- 00:30</div>
                        </div>
                    </div>
                    <div className="head03">
                        <small>Equipe:</small>
                        <div className="prj03">
                            {uses.map((item) => <LetteredAvatar size={23} color="#FFF" backgroundColor="#00000080" name={item.name} />)}
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}