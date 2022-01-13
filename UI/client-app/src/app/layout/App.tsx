import React, {Fragment, useEffect,useState} from 'react';
import axios from 'axios';
import {Activity} from '../models/Activity';
import { Container, Header, List } from 'semantic-ui-react';
import NavBar from './navbar';
import ActivityDashboard from '../../feature/activities/dashboard/ActivityDashboard';



function App() {
   const [activities, setActivities]= useState<Activity[]>([]);
   const [selectedActivity,setSelectedActivity] = useState<Activity | undefined>(undefined);
   const [editMode,setEditMode] = useState(false);

 
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

    function handleFormOpen(id?:string){
      id?handleSelectActivity(id):handleCancelSelectActivity();
      setEditMode(true);
    }

    function handleFormClose(){
      setEditMode(false);
    }

    function handleDeleteActivity(id:string){
      setActivities([...activities.filter(x=>x.id !== id)]);
    }

    function handleCreateorEditActivity(activity:Activity){
      debugger;
     
        var { v4: uuidv4 } = require('uuid');

      //const uuidv1 = require('uuid/v1');
      activity.id
       ? setActivities([...activities.filter(x=>x.id !== activity.id),activity])
       : setActivities([...activities,{...activity,id:uuidv4()}]);
       
    }

  return (
    <Fragment>
      <NavBar openForm={handleFormOpen}/>
      <Container style={{marginTop:'80px'}}>
             <ActivityDashboard 
                  activities={activities}
                  selectedActivity={selectedActivity}
                  selectActivity={handleSelectActivity}
                  cancelSelectActivity={handleCancelSelectActivity}
                  editMode = {editMode}
                  openForm={handleFormOpen}
                  closeForm={handleFormClose}
                  createOrEdit={handleCreateorEditActivity}
                  deleteActivity={handleDeleteActivity}
                  
                  />
          </Container>
    </Fragment>
  );
}

export default App;
