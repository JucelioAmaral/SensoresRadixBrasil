import React from 'react';
import {BrowserRouter,Switch,Route} from 'react-router-dom';
import Dashboard from './pages/Dashboard'


const Routes=()=>(

<BrowserRouter>
    <Switch>
        <Route exact path='/' component={Dashboard}></Route>
    </Switch>
</BrowserRouter>

)
export default Routes;