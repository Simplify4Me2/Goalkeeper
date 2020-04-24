import React from 'react';
import './Footer.css';
import { faEnvelope } from "@fortawesome/free-solid-svg-icons";
import { faTwitter, faFacebookF, faInstagram } from "@fortawesome/free-brands-svg-icons";
// import { face } from "@fortawesome/fontawesome-svg-core";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";



class Footer extends React.Component {
    render() {
        return (
            <section className="social">
                <footer>
                    <ul className="icons">
                        <li><a href="http://localhost:3000/" className="icon brands alt"><FontAwesomeIcon icon={faTwitter} /><span className="label">Twitter</span></a></li>
                        <li><a href="http://localhost:3000/" className="icon brands alt"><FontAwesomeIcon icon={faFacebookF} /><span className="label">Facebook</span></a></li>
                        <li><a href="http://localhost:3000/" className="icon brands alt"><FontAwesomeIcon icon={faInstagram} /><span className="label">Instagram</span></a></li>
                        <li><a href="http://localhost:3000/" className="icon solid alt"><FontAwesomeIcon icon={faEnvelope} /><span className="label">Email</span></a></li>
                    </ul>
                    <ul className="copyright">
                        <li>&copy; Simon</li><li>Design: <a href="http://localhost:3000/">Simon</a></li>
                    </ul>
                </footer>
            </section>
        )
    }
}

export default Footer