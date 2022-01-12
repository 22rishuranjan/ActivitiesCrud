import React from 'react';
import { Card, Image,Icon, Button, Form, Segment } from 'semantic-ui-react';
import {Activity} from '../../../app/models/Activity';
import ActivityList from '../ActivityList';


export default function ActivityForm(){
    return(
        <Segment clearing>
            <Form>
                <Form.Input placeholder='Title' />
                <Form.TextArea placeholder='Description'/>
                <Form.Input placeholder='Category' />
                <Form.Input placeholder='Date'/>
                <Form.Input placeholder='Title' />
                <Form.Input placeholder='Venue'/>
                <Button floated='right' positive  type='submit' content='Submit' />
                <Button floated='right'  type='button' content='Cancel' />
            </Form>
        </Segment>
    )
}