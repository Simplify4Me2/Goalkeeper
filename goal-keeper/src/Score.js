import React from 'react';
import './Score.css';

class Score extends React.Component {
    render() {
    return <span>{this.props.value}</span>
    }
}

class MatchScore extends React.Component {
    render() {
        return ( 
            <div>
                <Score value={0} />
                <Score value={1} />
            </div>
        );
    }
}

export default MatchScore