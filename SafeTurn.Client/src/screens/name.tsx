import React from 'react';
import { StyleSheet, Text, View, TextInput, Button, Alert } from 'react-native';

export default function Name() {
    return (
        <View>
            <Text>El seu nom</Text>
            <TextInput
                style={styles.input}
            ></TextInput>
            <Button
                title="Guardar"
                onPress={() => Alert.alert('botó clicat', 'has clicat un botó')}
            />
        </View>
    );
}

const styles = StyleSheet.create({
  input: {
    borderWidth: 1,
    height: 30,
    borderColor: 'gray'
  },
});

