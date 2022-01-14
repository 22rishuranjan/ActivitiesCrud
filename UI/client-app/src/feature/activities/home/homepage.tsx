import React from "react";
import { Container, List,Image} from "semantic-ui-react";

export default function HomePage(){
    return(
        <Container style={{marginTop:'80px'}}>
            <h1>Home page</h1>
            <h3>Welcome to Krone Tech Code Challenge</h3>

            <List>
                <List.Item>
                <Image avatar src='https://react.semantic-ui.com/images/avatar/large/christian.jpg' />
                <List.Content>
                    <List.Header as='a'>Rishu Ranjan</List.Header>
                    <List.Description>
                    Available for new projects. Last project {' '}
                    <a>
                        <b>Activities</b>
                    </a>{' '}
                    just now.
                    </List.Description>
                </List.Content>
                </List.Item>
            </List>

            <h4>Technologies used</h4>
            <List style={{marginLeft:'20px'}}>
                <List.Item>
                <List.Header>UI</List.Header>
                    React Js, TypeScript, Axios
                </List.Item>
                <List.Item>
                    <List.Header>Backend</List.Header>
                     .NET Core , EF Core
                </List.Item>
            </List>        
    </Container>
    )
}