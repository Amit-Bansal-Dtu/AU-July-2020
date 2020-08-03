import React, {useState, useEffect} from 'react';
import {addnewtodo,gettodolist} from './data_store';
import Edit_Delete from './edit_delete';
import { Button, ListGroup } from 'reactstrap';

const Addtodo = ()=>{
    const [list, setlist] = useState([]);
    const [newtodo, setnewtodo] = useState("");

    useEffect(()=>{
        let l = gettodolist();
        setlist(list=>l);
    },[])

    const putnewtodo = (e)=>{
        e.preventDefault();
        addnewtodo(e.target[0].value);
        setlist(list=>[...list, newtodo])
    }

    return (
        <div>
            <div>
                Todolist
                <ListGroup>
                    {list.map((item, index) => <Edit_Delete val={item} idx={index}/>)}
                </ListGroup>
            </div>
            <div>
                <form onSubmit={putnewtodo}>
                    <input placeholder="Enter new Todo..." value={newtodo} onChange={(val)=>setnewtodo(val.target.value)} required></input>
                    <Button color="success" type="submit" value="Add">Add Todo</Button>
                </form>
            </div>
        </div>
      );
} 

export default Addtodo;