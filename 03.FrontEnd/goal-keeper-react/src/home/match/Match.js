import React from 'react';
import './Match.css';

class Score extends React.Component {
    render() {
        return <span className="score" >{this.props.value}</span>
    }
}

class Match extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            error: null,
            isLoaded: false,
            matches: []
        }
    }

    // https://reactjs.org/blog/2017/07/26/error-handling-in-react-16.html
    componentDidMount() {
        fetch("http://localhost:5000/match")
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        isLoaded: true,
                        matches: result
                    });
                },
                (error) => {
                    this.setState({
                        isLoaded: true,
                        error
                    })
                }
            )
    }

    render() {
        const { error, isLoaded, matches } = this.state;
        if (error) {
            return <div>Error: {error.message}</div>;
        } else if (!isLoaded) {
            return <div>Loading...</div>
        } else {
            return (
                <section id="fixture">
                    <div>
                        <h1>Fixture</h1>
                        {matches.map(item => (
                            <div key={item.nr} className="match">
                                <span className="team">{item.homeTeam}</span>
                                <div>
                                    <Score value={item.homeScore} />
                                    <Score value={item.awayScore} />
                                </div>
                                <span className="team align-right">{item.awayTeam}</span>
                            </div>
                        ))}
                    </div>
                </section>
            );
        }
    }
}

export default Match

// function getDummyMatches() {
//     return '[{"nr":1,"homeTeam":"Test 1","awayTeam":"Test 2","homeScore":3,"awayScore":1},{"nr":2,"homeTeam":"Test 3","awayTeam":"Test 4","homeScore":2,"awayScore":2},{"nr":3,"homeTeam":"Test 5","awayTeam":"Test 6","homeScore":4,"awayScore":0},{"nr":4,"homeTeam":"Test 7","awayTeam":"Test 8","homeScore":0,"awayScore":1}]';
// }
