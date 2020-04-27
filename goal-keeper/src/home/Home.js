import React from 'react';
import Match from '../match/Match';
import Ranking from '../ranking-table/Ranking.js';
import './Home.css';

class Home extends React.Component {
    render() {
        return (
            <div className="container">
                <Match />
                <Ranking />
            </div>
        );
    }
}

export default Home