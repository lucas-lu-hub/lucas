import React, { Component } from "react";
import styles from '../common/main.css'
import Hider from './Hider.js'

export default class Menus extends Component
{
    render(){
        return (
            <div className={styles.menusStyle} id='menus'>
                <Hider />
            </div>
        );
    }
}