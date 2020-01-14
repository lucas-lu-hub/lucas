import React, { Component } from "react";
import styles from "../common/main.css"

class Hider extends Component
{
    constructor(){
        super();
        this.state = {isHide: false}
        this.HiderClick = this.HiderClick.bind(this);
    }

    HiderClick(){
        let content = document.getElementById('contentContainer');
        content.classList.add(styles.extensionContent);
        let menus = document.getElementById('menus');
        menus.classList.add(styles.hideMenus);
    }

    render(){
        return (
            <div className={styles.hiderButton} onClick={this.HiderClick}></div>
        )
    }

}

export default Hider;