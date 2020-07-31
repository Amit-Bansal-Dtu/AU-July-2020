const express = require('express')
const ToDoapp = express()
var bodyParser = require('body-parser')

const port = 2000;

ToDoapp.use(bodyParser.urlencoded({extended:false})) 
ToDoapp.use(bodyParser.json()) 

var TodoList = ["Rest_API_Assignment"];

//Get Request
ToDoapp.get('/todolist', (req, res) => res.json(TodoList))

//Post Request
ToDoapp.post('/todolist', (req, res) => {
    TodoList.push(req.body.ToDo);
    res.send(req.body);
})

//Put Request
ToDoapp.put('/changetodo', (req, res) => { 
    let todo_old = req.body.oldtodo;
    var idx = TodoList.indexOf(todo_old);
    if(idx == -1){
        res.send("There is no such todo, that you want to update");
    }
    else{
        TodoList.splice(idx,1,req.body.newtodo);
        res.send("oldtodo is updated to newtodo"); 
    }
    
  }) 


//Delete Request
ToDoapp.delete('/deletetodo',(req,res) =>{
    var del_todo = req.body.deltodo;
    var idx = TodoList.indexOf(del_todo);
    if(idx == -1){
        res.send("todo to be deleted doesn't exist");
    }
    else{
        TodoList.splice(idx,1);
        res.send("todo is deleted!!"); 
    }
})




ToDoapp.listen(port, () => console.log(`ToDoList app is starting at http://localhost:${port}`))