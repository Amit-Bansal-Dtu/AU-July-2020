import React, {useState, useEffect, useCallback} from 'react';
import {updatetodo, deletetodo, gettodolist} from './data_store';
import { Button, ButtonGroup, ListGroupItem, ListGroup } from 'reactstrap';

const Edit_Delete = (props)=>{
    const [idx, setidx] = useState(0);
    const [newtodo, setnewtodo] = useState("");

    const del = useCallback(()=>{
        deletetodo(idx);
        window.location.reload(false);
    },[idx])

    useEffect(()=>{
        setidx(idx=>props.idx);
    },[])

    const upd = useCallback(()=>{
         updatetodo(idx, newtodo);
         window.location.reload(false);
    },[idx, newtodo])

    return(
        <ListGroupItem key={props.val}>{props.val}
            <span style={{position: "absolute",right: "0px"}}>
            <input  type="text" placeholder="Enter Changed Todo..." onChange={(val)=>setnewtodo(val.target.value)} required></input>
            <ButtonGroup>
            <Button color="primary" onClick={upd} value="update">Edit</Button>
            <Button color="danger" onClick={del} value="delete">Delete</Button>
            </ButtonGroup>
            </span>
        </ListGroupItem>
    );
}

export default Edit_Delete;