import React, { Component } from 'react';
import {Table} from 'react-bootstrap'
import 'bootstrap/dist/css/bootstrap.min.css';
import api from '../../services/api'
import Moment from 'react-moment';
import * as signalR from "@microsoft/signalr";

import './styles.css'

export default class Grid extends Component{
    
    state={
        events:[]        
    };

    componentDidMount(){
        this.LoadEvents();

        
        var connection = new signalR.HubConnectionBuilder().withUrl("http://localhost:5000/DashboardHub").build();

        connection.on("updateListEvent", (event) => 
        {""
            var events = this.state.events;
            events.push(event);
            this.setState({events:events});            
            
        });

        connection.start().catch(function (err) {
            return console.error(err.toString());
        });
    }

    LoadEvents = async() => {

        const response = await api.get('/SensorEvents');
        const{data} = response;        
        this.setState({events:data});     
    }

    render() {

        const events = this.state.events;  
        
        const sensorRegex = new RegExp('\\.([^.]+$)');
        const distinctSensors=[]
        events.map(item => {                                  
            var findItem = distinctSensors.find(x => x === item.tag);        
            if (!findItem)        
            distinctSensors.push(item.tag);        
        }); 
        
        const regionRegex = new RegExp('\\.([^\\.]+)\\.');
        const distinctRegions = [];                
        distinctSensors.map(item => {                                  
            var findItem = distinctRegions.find(x => x === item.match(regionRegex)[1]);        
            if (!findItem)        
            distinctRegions.push(item.match(regionRegex)[1]);        
        });              
        console.log(events)
        return(
            <div>
              <div className="row event-list">           
                {distinctRegions.map(region => (
                    <div key={region} className="col-md-3">
                          <strong>{region}: {events.filter(x=>x.tag.match(regionRegex)[1] === region).length}</strong>                             
                          {distinctSensors.filter(x=>x.match(regionRegex)[1] === region).map(sensor=>(
                              <p key={sensor}><span className={(events.filter(x=>x.tag === sensor).pop().valor === "")?"status-circle n-ok":"status-circle ok" }  ></span>{sensor.match(sensorRegex)[1]}: {events.filter(x=>x.tag === sensor).length}</p>
                          ))}
                    </div>                    
                ))}    
                </div>
                            

             <div>
                <Table  table striped bordered hover>
                 <thead>
                       <tr>
                        <th>Date</th>
                        <th>Sensor</th>                     
                        <th>Value</th>
                       </tr>
                   </thead>
                   <tbody>
                       {events.map(event=>
                        
                        <tr key={event.id}>
                        <td><Moment format="YYYY/MM/DD HH:mm:ss" unix>{event.timestamp}</Moment></td>
                        <td>{event.tag}</td>                 
                        <td>{event.valor}</td>                 
                        </tr>                    
       
                       )}
                   </tbody>
       
                  </Table>
                  
              </div>
            </div>
        )
    };
};

