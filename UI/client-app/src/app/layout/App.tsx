import React, {Fragment, useEffect,useState} from 'react';
import {Activity} from '../models/Activity';
import { Container } from 'semantic-ui-react';
import NavBar from './navbar';
import ActivityDashboard from '../../feature/activities/dashboard/ActivityDashboard';
import agent from '../api/crud';
import LoadingComponent from './LoadingComponent';



function App() {
   const [activities, setActivities]= useState<Activity[]>([]);
   const [selectedActivity,setSelectedActivity] = useState<Activity | undefined>(undefined);
   const [editMode,setEditMode] = useState(false);
   const [loading,setLoading]=useState(true);
   const [submitting,setSubmitting]=useState(false);

 
    useEffect(()=>{
      // axios.get<Activity[]>('http://localhost:5642/api/Activity')
      agent.Activities.list().then((response:any)=>{debugger;
        let activities:Activity[] =[];
              response.data.forEach((activity:any) =>{
                  activity.date=activity.date.split('T')[0];
                  activities.push(activity);
              })
              setActivities(response.data);   
              setLoading(false);  
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
      setSubmitting(true);
      agent.Activities.delete(id).then((response)=>{
         setActivities([...activities.filter(x=>x.id !== id)]);
         setSubmitting(false);
      })
     
    }

    function handleCreateorEditActivity(activity:Activity){
    setSubmitting(true);
    if(activity.id){
      agent.Activities.update(activity)
            .then((response)=> {
                let { v4: uuidv4 } = require('uuid');
                setActivities([...activities.filter(x=>x.id !== activity.id),activity]);
                setSubmitting(false);
            })
 
    }else{
      let { v4: uuidv4 } = require('uuid');
      activity.id=uuidv4();
      agent.Activities.create(activity).then(()=>{
        setActivities([...activities,activity]);

        setSelectedActivity(activity);
                setEditMode(false);
                setSubmitting(false);
      })

    }
  }

  if(loading) return <LoadingComponent content='Loading app' />

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
                  submitting={submitting}
                  />
          </Container>
    </Fragment>
  );
}

export default App;
