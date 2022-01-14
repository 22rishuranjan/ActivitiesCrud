import React, { ChangeEvent, useState } from 'react';
import { act } from 'react-dom/test-utils';
import { Card, Image,Icon, Button, Form, Segment, Dropdown, DropdownProps, Message } from 'semantic-ui-react';

import {Activity} from '../../../app/models/Activity';
import ActivityList from '../ActivityList';

interface Props{
    activity:Activity|undefined;
   
    closeForm:()=>void;
    createOrEdit:(activtiy:Activity)=>void;
    submitting:boolean;
}


export default function ActivityForm({activity:selectedActivity,closeForm,createOrEdit,submitting}:Props){

    const initialState = selectedActivity  ?? {
        id :'',
        title:'',
        category:'',
        description:'',
        date:'',
        city:'',
        venue:''
    }


    const options = [
        { key: 1, text: 'personal', value: 'personal' },
        { key: 2, text: 'business', value: 'business' },
        { key: 3, text: 'official', value: 'official'},
        { key: 4, text: 'pleasure', value: 'pleasure' }
      ]
      

    const[activity,setActivity] = useState(initialState);
    const[message,setMessage] = useState('');
    const[errorControl,setErrorControl] = useState<string[]>([]);

    function handleSubmit(){
        setActivity(activity);
        createOrEdit(activity);
    }

    function handleInputChange(event:any){
       
        const {name,value}=event.target;
        validateControl(name,value);
        setActivity({...activity,[name]:value})
    }
    function validateControl(name:string,value:string){
        if (name=='date') return;
        if (value.length>3000 && !errorControl.includes(name)){
                setErrorControl([...errorControl, name]);
               
        }
        else if(value.length<3000  && errorControl.includes(name)){
                let index=errorControl.indexOf(name);
                errorControl.splice(index,1);
                setErrorControl(errorControl);
        }

        if(errorControl.length ==0){
            setMessage('');
        }else{
             setMessage(`${errorControl.join(",")} can't have more than 3000 characters.`);
        }
    }

    function handleDDChange(event:any){
        debugger;
        const value=event.currentTarget.firstElementChild.getInnerHTML()
        setActivity({...activity,'category':value})
    }

    


    return(
        <Segment clearing>
            <Form onSubmit={handleSubmit}  autoComplete='off' id='activityform'>
                {message.length>0 && <Message negative>{message}</Message> }
                <Form.Input placeholder='Title' onChange={handleInputChange} value={activity.title} name='title' />
                <Form.TextArea placeholder='Description'  onChange={handleInputChange} name='description' value={activity.description}/>
                <Form.Input>   <Dropdown clearable options={options} onChange= {handleDDChange} value={activity.category} selection fluid placeholder='category' /> </Form.Input> 
                <Form.Input type='date' placeholder='Date'  onChange={handleInputChange} name='date' value={activity.date}/>
                <Form.Input placeholder='City'  onChange={handleInputChange} name='city' value={activity.city} />
                <Form.Input placeholder='Venue' onChange={handleInputChange} name='venue' value={activity.venue}/>
                <Button loading={submitting}  disabled={!activity.title || !activity.date || message.length>0} floated='right' positive  type='submit' content='Submit' />
                <Button loading={submitting} floated='right' onClick={closeForm}  type='button' content='Cancel' />
            </Form>
        </Segment>
    )
}