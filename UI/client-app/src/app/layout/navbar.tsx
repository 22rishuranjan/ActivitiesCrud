import React from 'react';
import { Link, NavLink } from 'react-router-dom';

import {Button, Container, Menu} from 'semantic-ui-react';

interface Props{
    openForm:()=>void;
}


export default function NavBar({openForm}:Props){

    return(
        <Menu inverted fixed='top'>
            <Container>
                <Menu.Item header >
                    <img src="/assets/logo.png" alt="logo" style={{marginRight:'10px'}}/>
                    Krone Tech
                </Menu.Item>
                <Menu.Item as={NavLink} to='/' name='Home' />
                <Menu.Item as={NavLink} to='/activities' name='Activities' />
                <Menu.Item>
                    <Button onClick = {openForm} positive content='Create Activity'/>
                </Menu.Item>
            </Container>
        </Menu>
    )
}