import React from "react";
import './letterAvatar.css';

export default function Index({ name }) {
    return (
        <div className="container-avatar" >
            <span>{name}</span>
        </div>
    );
}