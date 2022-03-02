import React from "react";
import './group.css';

export default function Index({ title, onHandleClick }) {
    return (
        <div className="container" onClick={onHandleClick}>
            <span>{title}</span>
        </div>
    );
}