import React, { Component } from 'react';
import './Header.css';
// import { ReactComponent as Logo } from '../logo.svg';
import * as THREE from 'three';

class Header extends Component {

    componentDidMount() {
        // Our Javascript will go here.
        var scene = new THREE.Scene();
        var camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);

        var renderer = new THREE.WebGLRenderer({ alpha: true });
        renderer.setSize(450, 450);
        // document.body.appendChild(renderer.domElement);
        this.mount.appendChild( renderer.domElement );

        var geometry = new THREE.BoxGeometry();
        var material = new THREE.MeshBasicMaterial({ color: 0xffffff });
        var cube = new THREE.Mesh(geometry, material);
        scene.add(cube);

        camera.position.z = 5;

        var animate = function () {
            requestAnimationFrame(animate);

            cube.rotation.x += 0.01;
            cube.rotation.y += 0.01;

            renderer.render(scene, camera);
        };

        animate();
    }

    render() {
        return (
            <div>
                <div className="cube" ref={ref => (this.mount = ref)} />
                {/* <Logo /> */}
            </div>
        );
    }
}

export default Header