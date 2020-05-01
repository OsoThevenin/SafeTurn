import React from 'react';
import { StyleSheet, Text, View, Button, Alert } from 'react-native';
import Header from './src/components/header';
import Navigator from './src/routes/homeStack';

export default function App() {
  return (
    <View style={styles.container}>
      <Header></Header>
      <Navigator />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
  },
});
