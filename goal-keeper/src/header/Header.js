import React from 'react';
import './Header.css';
import { ReactComponent as Logo } from '../logo.svg';

class Header extends React.Component {
    render() {
        return (
            <div>
                <Logo />
            </div>
        );
    }
}

export default Header