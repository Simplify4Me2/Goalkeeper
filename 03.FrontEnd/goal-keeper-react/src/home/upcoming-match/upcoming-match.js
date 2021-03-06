import React from 'react';
import './upcoming-match.css';
import awayTeamLogoPlaceholder from '../../images/away-team-logo-placeholder.png';
import homeTeamLogoPlaceholder from '../../images/home-team-logo-placeholder.png';

// https://sporza.be/nl/matches/voetbal/jupiler-pro-league/2019-2020/regulier/30/waasland-beveren-kaa-gent~1562002561980/

class UpcomingMatch extends React.Component {
    render() {
        return (
            <section id="upcoming">
                <div className="">
                    <img src={homeTeamLogoPlaceholder} alt="team emblem" />
                    <span>Datum</span>
                    <img src={awayTeamLogoPlaceholder} alt="team emblem" />
                </div>
                <span >upcoming</span>
            </section>
        );
    }
}

export default UpcomingMatch