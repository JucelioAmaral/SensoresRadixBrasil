import React,{Component} from 'react';
import {Line} from 'react-chartjs-2'
import api from '../../services/api'

import './styles.css'


export default class LineChart extends Component{

    state={
        data:{}
    };

    componentDidMount(){
        this.loadData();
    }
    
    loadData = async() => {
        const response = await api.get('/GetAllForGraph');
        const{data} = response;        
        this.setState({data:data});        
    }

    render(){        
        const options ={
            title:{
                display:false,
                text:''
            }
        }

       return(<Line data={this.state.data} options={options}/>
    )}
}
