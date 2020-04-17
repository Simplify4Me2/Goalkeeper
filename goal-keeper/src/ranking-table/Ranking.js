import React from 'react';
import './Ranking.css';

class Ranking extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            error: null,
            isLoaded: false,
            rankings: []
        }
    }

    componentDidMount() {
        fetch("http://localhost:5000/ranking")
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        isLoaded: true,
                        rankings: result
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
        const { error, isLoaded, rankings } = this.state;
        if (error) {
            return <div>Error:  {error.message}</div>;
        } else if (!isLoaded) {
            return <div>Loading</div>;
        } else {
            return (
                <div>
                    <h1>Ranking</h1>
                    <table>
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Team</th>
                                <th>Points</th>
                            </tr>
                        </thead>
                        <tbody>
                            {rankings.map(item => (
                                <tr key={item.position}>
                                    <td>{item.position}</td>
                                    <td>{item.team}</td>
                                    <td>{item.points}</td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                </div>
            );
        }
    }
}

export default Ranking