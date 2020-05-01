import React from 'react';
import { StyleSheet, Text, View, Button } from 'react-native';

export default function Home({ navigation }: { navigation: any }) {
    const pressHandler = () => {
        navigation.navigate('Change Name')
    }

    return (
        <View>
            <Text>Home</Text>
            <Button title="Change Name" onPress={pressHandler} />
        </View>
    )


}