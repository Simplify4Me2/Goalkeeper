import React from 'react';
import './Score.css';

class Score extends React.Component {
    render() {
    return <span className="score" >{this.props.value}</span>
    }
}

class Match extends React.Component {
    render() {
        return ( 
            <div>
                <span className="team">OHL Leuven</span>
                <div>
                    <Score value={0} />
                    <Score value={2} />
                </div>
                <span className="team">KV Mechelen</span>
            </div>
        );
    }
}

export default Match