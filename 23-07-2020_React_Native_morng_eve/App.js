import { StatusBar } from 'expo-status-bar';
import React from 'react';
import { StyleSheet, Text, View } from 'react-native';

import Login from './src/Component/Login_Page';
import ToDo  from './src/Component/Add_ToDo_List';
import Show  from './src/Component/show';
import Logout from './src/Component/Logout';
import Delete_ToDo from './src/Component/Delete_ToDo_List';

import {NavigationContainer} from '@react-navigation/native';
import {createStackNavigator} from '@react-navigation/stack';

const Stack = createStackNavigator();

export default function App() {
  return (
    <NavigationContainer>
      <Stack.Navigator>
        <Stack.Screen name="Login Page" component={Login} />
        <Stack.Screen name="To-Do List" component={ToDo} />  
        <Stack.Screen name="Show To-Do" component={Show} />
        <Stack.Screen name="LogOut" component={Logout}/>
        <Stack.Screen name="Delete To-Do" component={Delete_ToDo}/>
      </Stack.Navigator>
    </NavigationContainer> 
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
