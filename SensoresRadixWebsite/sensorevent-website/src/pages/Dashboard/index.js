import React,{Component} from 'react';
import LineChart  from '../../components/LineChart';
import Grid from '../../components/Grid'
import './styles.css'

export default class Dasboard extends Component{

    render(){
        return(
        <div className="dashboard-content"> 
        <div className="row">
            <div className="col-md-6">
            <h5 className="h5-header">Real Time Received Events</h5>
                <Grid />
            </div>
  
            <div className="col-md-6">
            <h5 className="h5-header">Real Time Sensors Numeric Values</h5>
                <LineChart/> 
            </div>
          </div>
        </div>
        )
        
    }
}