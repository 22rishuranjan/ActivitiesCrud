import React, {Fragment, useEffect,useState} from 'react';
import axios from 'axios';
import {Activity} from '../models/Activity';
import { Container, Header, List } from 'semantic-ui-react';
import NavBar from './navbar';
import ActivityDashboard from '../../feature/activities/dashboard/ActivityDashboard';

function App() {
   const [activities, setActivities]= useState<Activity[]>([]);
   const [selectedActivity,setSelectedActivity] = useState<Activity | undefined>(undefined);

 
    useEffect(()=>{

      axios.get<Activity[]>('http://localhost:5642/api/Activity')
           .then((response:any)=>{debugger;
         
                   setActivities(response.data?.data);     
           })

    },[])

    function handleSelectActivity(id:string){
      setSelectedActivity(activities.find(x=>x.id === id));
    }

    function handleCancelSelectActivity(){
      setSelectedActivity(undefined);
    }



  return (
    <Fragment>
      <NavBar/>
      <Container style={{marginTop:'80px'}}>
             <ActivityDashboard 
                  activities={activities}
                  selectedActivity={selectedActivity}
                  selectActivity={handleSelectActivity}
                  cancelSelectActivity={handleCancelSelectActivity}
                  
                  
                  />
          </Container>
    </Fragment>
  );
}

export default App;
