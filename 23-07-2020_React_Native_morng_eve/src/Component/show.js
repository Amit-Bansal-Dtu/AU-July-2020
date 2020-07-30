import React, {useState, useEffect} from "react"

import { Alert,View,Text,TouchableOpacity,TextInput,StyleSheet,AsyncStorage, Button} from "react-native";
import { FlatList } from "react-native-gesture-handler";
import Logout from './Logout'

const Show=({navigation})=>{

    const [ToDoList, setToDoList] = useState(null);
    const [key, setkey] = useState("");

    useEffect(() => {
        populateToDo();
    }, [])

    useEffect(() => {
        const unsubscribe = navigation.addListener('focus', () => {
         
          populateToDo();
        });
      return unsubscribe;
    }, [navigation]);
    
    const CreateNewTodo=()=>{
        navigation.navigate('To-Do List');
    }

    const populateToDo = async () => {
        var a = await AsyncStorage.getItem('ToDoList');
        var arr=JSON.parse(a);
        if (arr) {
            setToDoList(arr);
        }
    }    

    const Delete=async()=>{
        navigation.navigate('Delete To-Do');
    }

    const LogOut=async()=>{
        await AsyncStorage.removeItem("username");
        await AsyncStorage.removeItem("ToDoList");
        navigation.navigate('Login Page');
    }

    return(
        <View style={Styles.container}>
        <View  style={{flex:1}}>
            <FlatList data={ToDoList} keyExtractor={item => item} renderItem={({item})=>{return <TouchableOpacity style={Styles.Todo} onPress={()=>setkey(item)}><Text style={Styles.text}>{item}</Text></TouchableOpacity>}}/>
            <TouchableOpacity style={Styles.create} onPress={Delete}><Text style={Styles.text}>Delete To Do</Text></TouchableOpacity>
            <TouchableOpacity style={Styles.create} onPress={CreateNewTodo}><Text style={Styles.text}>Add New To Do</Text></TouchableOpacity>    
        </View>      
        <View  style={{flex:1}}>
            <Logout out={LogOut}/>
        </View>
        </View>
    );
}
    
const Styles = StyleSheet.create({
    container: {
        flex: 3,
        justifyContent: "center",
        backgroundColor:"white",
        borderRadius:15,
        elevation:5,
        margin:"1.5%"
    },
    Todo: {
        borderWidth: 1,
        borderRadius: 15,
        justifyContent: "center",
        backgroundColor: "#ffb587",
        width: 400,
        height: 50
    },
    create:{
        borderWidth: 1,
        borderRadius: 15,
        justifyContent: "center",
        backgroundColor: "#4ef5af",
        width: 400,
        height: 50
    },
    text:{
        fontSize: 15,
        fontWeight: "bold",
        textAlign: "center",
    },
    delete:{
        borderWidth: 1,
        borderRadius: 15,
        justifyContent: "center",
        backgroundColor: "#c94269",
        width: 400,
        height: 50
    }
})
    
    
    export default Show;