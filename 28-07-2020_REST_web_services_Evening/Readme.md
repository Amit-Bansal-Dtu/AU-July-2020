#REST_API_ASSIGNMENT

##Initializing Project
```bash
npm init
```

## Installing Express 
```bash
npm install express
```

##Get Request on '/todolist' path
This will bring the entire todo list to you

##Post Request on '/todolist' path
Send a json object like {"ToDo":"Name of your todo"}, 

where "ToDo" is the key and value is your todo name

##Put Request on '/changetodo' path
Send a json object like {"oldtodo":"name of old todo", "newtodo":"name of new todo"}

the ToDo with name as oldtodo will be removed and the newtodo will be added to TodoList

##Delete Request on '/deletetodo' path
Send a json  object like {"deltodo": "name of the todo to be deleted"}

The Todo with the name same as deltodo will be removed from the TodoList

