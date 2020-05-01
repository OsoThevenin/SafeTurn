import React from 'react';
import { StyleSheet, View } from 'react-native';
import Home from './src/screens/home';
import Settings from './src/screens/settings';
import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';

const Stack = createStackNavigator();

export default function App() {
  return (
    <View style={styles.container}>
      <NavigationContainer>
        <Stack.Navigator>
          <Stack.Screen name="Safe Turn" component={Home} />
          <Stack.Screen name="Change Name" component={Settings} />
        </Stack.Navigator>
      </NavigationContainer>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
  },
});
