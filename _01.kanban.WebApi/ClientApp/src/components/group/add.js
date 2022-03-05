import React from "react";
import './group.css';

export default function Index({ title, onHandleClick, color = 'dodgerblue' }) {
    return (
        <div className="container-add" style={{background: color}} onClick={onHandleClick}>
            <span>{title}</span>
        </div>
    );
}