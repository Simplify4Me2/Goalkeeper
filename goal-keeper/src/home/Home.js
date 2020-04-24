import React from 'react';
import Match from '../match/Match';
import Ranking from '../ranking-table/Ranking.js';

class Home extends React.Component {
    render() {
        return (
            <div>
                <Match />
                <Ranking />
            </div>
        );
    }
}

export default Home