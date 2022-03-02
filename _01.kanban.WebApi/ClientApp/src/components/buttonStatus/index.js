import React from "react";
import './buttonStatus.css'

export default function Index({description}) {
    return (
        <button className="btn-status-danger">
            {description}
        </button>
    );
}