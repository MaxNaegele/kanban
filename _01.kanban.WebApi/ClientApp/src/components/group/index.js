// import React from "react";
// import './group.css';

// export default function Index({ title, onHandleClick }) {
//     return (
//         <div className="container" onClick={onHandleClick}>
//             <span>{title}</span>
//         </div>
//     );
// }

import React from "react";
import './group.css';
import { ClockCircleOutlined } from '@ant-design/icons';
import { CardItem } from '../../components';

export default function Index({ title, time, quantity }) {
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
                <CardItem />
            </div>
        </div>
    );
}
