import React from "react";
import './buttonStatus.css'

export default function Index({description, color}) {

    let cor = '';
    switch (color) {
        case 'red':
            cor = 'btn-status-danger';
            break;
        case 'green':
            cor = 'btn-status-success';
            break;
        case 'yellow':
            cor = 'btn-status-warning';
            break;
    
        default:
            cor = 'btn-status-success';
            break;
    }

    return (
        <button className={cor}>
            {description}
        </button>
    );
}