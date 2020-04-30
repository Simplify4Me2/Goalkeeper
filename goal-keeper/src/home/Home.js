import React from 'react';
import Match from './match/Match';
import Ranking from './ranking-table/Ranking.js';
import UpcomingMatch from './upcoming-match/upcoming-match.js';
import News from './news/news.js';
import './Home.css';

class Home extends React.Component {
    render() {
        return (
            <div className="container">
                <div className="headlights">
                    <UpcomingMatch />
                    <div className="flex-column">
                        <News />
                        <News />
                    </div>
                    <Match />
                </div>
                <Ranking />
            </div>
        );
    }
}

export default Home