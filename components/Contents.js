import React, { Component } from "react";
import styles from '../common/main.css'
import Products from "./Products.js"

export default class Contents extends Component
{
    render(){
        return (
            <div className={styles.contentsContainer} id="contentContainer">
                <Products />
                <div className={styles.contents}></div>
            </div>
        );
    }
}