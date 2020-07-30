import React, {useState, useEffect} from "react"

import { Alert,View,Text,TouchableOpacity,TextInput,StyleSheet,AsyncStorage, Button} from "react-native";

const Login=({navigation})=>{

    const [username, setUserName] = useState(null);

      useEffect(() => {
        Authorize()
      }, [])

    const Authorize= async () => {
        const userName = await AsyncStorage.getItem("username");
        if (userName) {
            navigation.navigate('To-Do List');
        }
        return;
    }

    const onLogin=async()=>{
        if(username)
        {
            await AsyncStorage.setItem("username", username);
            navigation.navigate('To-Do List');
        }
        else
        {
        Alert.alert("",
            "Please Enter your username"
        );
        }


    }
    return(
          <View style={Styles.container}>
                <TextInput style={Styles.textInputStyle} placeholder="Enter UserName to Login" onChangeText={(text)=>setUserName(text)}></TextInput>
                <TouchableOpacity style={Styles.loginButton} onPress={onLogin}><Text style={Styles.text}>Press to Login</Text></TouchableOpacity>   
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
    
    loginButton: {
        borderWidth: 1,
        borderRadius: 15,
        justifyContent: "center",
        backgroundColor: "#4ad4d1",
        width: 400,
        height: 50
    },
    text:{
        fontSize: 15,
        fontWeight: "bold",
        textAlign: "center",
    },
    textInputStyle: {
        borderWidth: 1,
        borderRadius: 15,
        fontSize: 20,
        padding: 10,
        marginBottom: 20,
        width: 400,
    }
})


export default Login;