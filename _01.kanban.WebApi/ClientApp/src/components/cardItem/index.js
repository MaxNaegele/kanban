import React from "react";
import './card.css';
import { CalendarOutlined, ClockCircleOutlined } from '@ant-design/icons';
import LetteredAvatar from 'react-lettered-avatar';
import { ButtonStatus } from '../../components';
export default function Index() {
    return (
        <div className="container-master-card">
            <div className="container-card">
                <div className="head01">
                    <div>
                        <div className="font-label01 head02">DESENVOLVIMENTO</div>
                    </div>
                    <div className="head03">
                        <small>Código:</small>
                        <span>#12356</span>
                    </div>
                </div>
                <div className="titl01">
                    <span className="font-label1">CRIAR MIGRATION</span>
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
                            <span className="m-g-l">30/12/2022</span>
                        </div>
                    </div>
                </div>
                <div className="bd01">
                    <div>
                        <small>Descrição:</small>
                        <p>Usar um pull request, master apos isso dnasd daskdndd kdsadkn dsnd dnsdan kdnasdnd</p>
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
                            <span className="font-label1">05:45</span>
                        </div>
                    </div>
                    <div className="head03">
                        <ButtonStatus description={"EM ATRASO"}  />
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
                            <LetteredAvatar size={23} color="#FFF" backgroundColor="#00000080" name="Max " />
                            <LetteredAvatar size={23} color="#FFF" backgroundColor="#00000080" name="Max Naegele" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}