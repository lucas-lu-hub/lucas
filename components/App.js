import React,{Component} from 'react';
import Header from './Header'
import Menus from './Menus'
import Contents from './Contents'
import styles from '../common/main.css'

class Bodys extends Component
{
  render(){
    return (
      <div className={styles.bodyStyle}>
        <Menus />
        <Contents />
      </div>
    )
  }
}

export default class extends Component{

  render(){
    return(
      <div className={styles.rootContainer}>
        <Header />
        <Bodys />
      </div>
    )
  }
}
