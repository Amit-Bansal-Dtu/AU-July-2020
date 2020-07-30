import React, {useState, useEffect} from "react"
import { Alert,View,Text,TouchableOpacity,TextInput,StyleSheet,AsyncStorage, Button} from "react-native";


const Logout=(props)=>{
    return (
        <TouchableOpacity style={Styles.logout} onPress={props.out}><Text style={Styles.text}>LogOut</Text></TouchableOpacity > 
    )  
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

export default Logout;