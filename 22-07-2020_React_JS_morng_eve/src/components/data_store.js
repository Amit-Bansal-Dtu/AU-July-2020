/*eslint no-unused-vars: 0*/
export const gettodolist = ()=>{
    let todolist = sessionStorage.getItem("todolist");
    if(todolist==null){
        return [];
    }
    else return JSON.parse(todolist);
}

export const addnewtodo = (newtodo)=>{
    let todolist = gettodolist();
    todolist.push(newtodo);
    sessionStorage.setItem("todolist", JSON.stringify(todolist));
}

export const deletetodo = (index)=>{
    let todolist = gettodolist();
    todolist.splice(index, 1);
    sessionStorage.setItem("todolist", JSON.stringify(todolist));
}

export const updatetodo = (index, changedtodo)=>{
    let todolist = gettodolist();
    todolist[index] = changedtodo;
    sessionStorage.setItem("todolist", JSON.stringify(todolist));
}