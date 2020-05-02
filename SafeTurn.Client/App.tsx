import React from 'react';
import { StyleSheet, View } from 'react-native';
import Home from './src/screens/home';
import Settings from './src/screens/settings';
import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';

const Stack = createStackNavigator();

export default function App({ navigation }: { navigation: any }) {
  return (
    <View style={styles.container}>
      <NavigationContainer>
        <Stack.Navigator>
          <Stack.Screen
            name="Home"
            component={Home}
            options={{
              title: 'Safeturn',
              headerStyle: styles.header,
              headerTitleStyle: styles.headerTitle,
            }}

          />
          <Stack.Screen
            name="Settings"
            component={Settings}
            options={{
              title: 'Change Name',
            }}
          />
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
  header: {
    backgroundColor: '#27A699',
  },
  headerTitle: {
  }
});