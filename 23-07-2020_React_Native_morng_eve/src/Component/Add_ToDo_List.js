import React, {useState, useEffect} from "react"

import { Alert,View,Text,TouchableOpacity,TextInput,StyleSheet,AsyncStorage, Button} from "react-native";


import Logout from './Logout'

const ToDo=({navigation})=>{
        const [ToDo, setToDo] = useState("");
        const [ToDoList, setToDoList] = useState(null);

        useEffect(() => {
            populateToDo();
        }, [])
        
        useEffect(() => {
            const unsubscribe = navigation.addListener('focus', () => {
             
              populateToDo();
            });
          return unsubscribe;
          }, [navigation]);

        const populateToDo = async () => {
                var a = await AsyncStorage.getItem('ToDoList');
                var arr=JSON.parse(a);
                if (arr) {
                    setToDoList(arr);
                }
        }    

        const Add_ToDo=async()=>{
            let array = await AsyncStorage.getItem("ToDoList");

            if(array==null)
            {
                let new_arr = [];
                new_arr.push(ToDo);
                await AsyncStorage.setItem("ToDoList", JSON.stringify(new_arr));
            }
            else
            {
                let new_arr = JSON.parse(array);
                new_arr.push(ToDo);
                await AsyncStorage.setItem("ToDoList", JSON.stringify(new_arr));
            }
        }

        const seeTodo=()=>{
            navigation.navigate("Show To-Do")
        }

        const LogOut=async()=>{
            await AsyncStorage.removeItem("username");
            await AsyncStorage.removeItem("ToDoList");
            navigation.navigate('Login Page');
        }


        return(
            <View style={Styles.container}>
                <TouchableOpacity style={Styles.mainButton} onPress={seeTodo}><Text style={Styles.text}>See To-Do's</Text></TouchableOpacity >
                <View style={{flex:1}}>
                    <TextInput style={Styles.textInputStyle} placeholder="Enter work to be added..." onChangeText={(str)=>setToDo(str)}></TextInput>            
                    <TouchableOpacity style={Styles.mainButton} onPress={Add_ToDo}><Text style={Styles.text}>Add Work</Text></TouchableOpacity>
                    <Logout out={LogOut}/>        
                </View>
            </View>
        );
    
    }
    
    const Styles = StyleSheet.create({
        todocontain:{
            justifyContent: "center",
        },
        container: {
            flex: 3,
            justifyContent: "center",
            backgroundColor:"white",
            borderRadius:15,
            elevation:5,
            margin:"1.5%"
        },
        
        mainButton: {
            borderWidth: 1,
            borderRadius: 15,
            justifyContent: "center",
            backgroundColor: "#4ef5af",
            width: 400,
            height: 50
        },
        logout:{
            borderWidth: 1,
            borderRadius: 15,
            justifyContent: "center",
            backgroundColor: "#f54242",
            width: 400,
            height: 50
        },

        textInputStyle: {
            borderWidth: 1,
            borderRadius: 15,
            fontSize: 20,
            padding: 10,
            marginBottom: 20,
            width: 400,
        },
        text:{
            fontSize: 15,
            fontWeight: "bold",
            textAlign: "center",
        }
    })
    
    
    export default ToDo;