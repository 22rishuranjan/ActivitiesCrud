import React from 'react';
import { Card, Image, Button } from 'semantic-ui-react';
import {Activity} from '../../../app/models/Activity';
import ActivityList from '../ActivityList';

interface Props{
    activity:Activity;
    cancelSelectActivity:()=>void;
    openForm:(id:string)=>void;
}

export default function ActivityDetails({activity,cancelSelectActivity,openForm}:Props){

 return(
    <Card fluid>
    <Image src={`/assets/categoryImages/culture.jpg`} wrapped ui={false} />
    <Card.Content>
      <Card.Header>{activity.title}</Card.Header>
      <Card.Meta>
        <span className='date'>Joined in {new Date(activity.date).getFullYear()}</span>
      </Card.Meta>
      <Card.Description>
        {activity.description}
      </Card.Description>
    </Card.Content>
    <Card.Content extra>
      {/* <Button.Group width='2'> */}
          <Button onClick={()=>openForm(activity.id)} floated="right" basic color='blue' content='Edit' />
          <Button onClick={cancelSelectActivity}floated="right" basic color='grey' content='Cancel' />
      {/* </Button.Group> */}
    </Card.Content>
  </Card>
 )



}