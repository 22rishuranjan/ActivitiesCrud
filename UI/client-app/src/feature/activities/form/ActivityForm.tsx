import React, { ChangeEvent, useState } from 'react';
import { act } from 'react-dom/test-utils';
import { Card, Image,Icon, Button, Form, Segment } from 'semantic-ui-react';
import {Activity} from '../../../app/models/Activity';
import ActivityList from '../ActivityList';

interface Props{
    activity:Activity|undefined;
   
    closeForm:()=>void;
    createOrEdit:(activtiy:Activity)=>void;
}


export default function ActivityForm({activity:selectedActivity,closeForm,createOrEdit}:Props){

    const initialState = selectedActivity  ?? {
        id :'',
        title:'',
        category:'',
        description:'',
        date:'',
        city:'',
        venue:''
    }

    const[activity,setActivity] = useState(initialState);

    function handleSubmit(){
        console.log(activity);
        createOrEdit(activity);
    }

    function handleInputChange(event:ChangeEvent<HTMLInputElement|HTMLTextAreaElement>){
        const {name,value}=event.target;
        setActivity({...activity,[name]:value})
    }



    return(
        <Segment clearing>
            <Form onSubmit={handleSubmit} autoComplete='off'>
                <Form.Input placeholder='Title' onChange={handleInputChange} value={activity.title} name='title' />
                <Form.TextArea placeholder='Description'  onChange={handleInputChange} name='description' value={activity.description}/>
                <Form.Input placeholder='Category'  onChange={handleInputChange} name='category' value={activity.category} />
                <Form.Input placeholder='Date'  onChange={handleInputChange} name='date' value={activity.date}/>
                <Form.Input placeholder='City'  onChange={handleInputChange} name='city' value={activity.city} />
                <Form.Input placeholder='Venue' onChange={handleInputChange} name='venue' value={activity.venue}/>
                <Button floated='right' positive  type='submit' content='Submit' />
                <Button floated='right' onClick={closeForm}  type='button' content='Cancel' />
            </Form>
        </Segment>
    )
}