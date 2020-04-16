import React from 'react';
import './Ranking.css';

// https://css-tricks.com/complete-guide-table-element/

class Ranking extends React.Component {
    render() {
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
                        <tr>
                            <td>1</td>
                            <td>Germinal Beerschot</td>
                            <td>7</td>
                        </tr>
                        <tr>
                            <td>2</td>
                            <td>OHL Leuven</td>
                            <td>7</td>
                        </tr>
                        <tr>
                            <td>3</td>
                            <td>KV Mechelen</td>
                            <td>2</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        )
    }
}

export default Ranking