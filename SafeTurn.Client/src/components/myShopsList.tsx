import React from 'react';
import { StyleSheet, Text, View, TextInput, Button } from 'react-native';

export default function MyShopsList() {

    return (
        <View style={styles.myShopsContainer}>
            <Text>Comercios</Text>
        </View>
    )
}

const styles = StyleSheet.create({
    myShopsContainer: {
        marginTop: 10,
    }
})