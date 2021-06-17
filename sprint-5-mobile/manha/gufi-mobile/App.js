import React, { Component } from 'react';
import { Image, StyleSheet, View } from 'react-native';
import { NavigationContainer } from '@react-navigation/native';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';

import Convites from './src/screens/convites';
import Eventos from './src/screens/eventos';
import Perfil from './src/screens/perfil';

const bottomTab = createBottomTabNavigator();

export default class App extends Component {

  render(){
    return (
      <View style={styles.main}>
        <NavigationContainer>
          <bottomTab.Navigator
            initialRouteName= 'Eventos'
            tabBarOptions={{
              showLabel: false,
              showIcon: true,
              activeBackgroundColor: '#B727FF',
              inactiveBackgroundColor: '#DD99FF',
              activeTintColor: '#FFF',
              inactiveTintColor: '#FFF',
              style: { height : 50 }
            }}
            screenOptions={({ route }) => ({
              tabBarIcon: () => {
                if (route.name === 'Convites') {
                  return(
                    <Image 
                      source={require('./assets/img/plane.png')}
                      style={styles.tabBarIcon}
                    />
                  )
                }

                if (route.name === 'Eventos') {
                  return(
                    <Image
                      source={require('./assets/img/calendar.png')}
                      style={styles.tabBarIcon}
                    />
                  )
                }

                if (route.name === 'Perfil') {
                  return(
                    <Image 
                      source={require('./assets/img/profile.png')}
                      style={styles.tabBarIcon}
                    />
                  )
                }
              }
            }) }
          >
            <bottomTab.Screen name="Convites" component={Convites} />
            <bottomTab.Screen name="Eventos" component={Eventos} />
            <bottomTab.Screen name="Perfil" component={Perfil} />
          </bottomTab.Navigator>
        </NavigationContainer>
      </View>
    );
  }
}

const styles = StyleSheet.create({

  main: {
    flex: 1,
    backgroundColor: '#F1F1F1'
  },

  tabBarIcon: {
    width: 22,
    height: 22
  }

});
