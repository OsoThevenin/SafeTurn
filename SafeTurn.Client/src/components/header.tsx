import React from 'react';
import { StyleSheet, Text, View } from 'react-native';

export default function Header() {
    return (
        <View>
            <View style={styles.topBar}></View>
            <View style={styles.titleContainer}>
                <Text>SafeTurn App</Text>
            </View>
        </View>
    )
}

const styles = StyleSheet.create({
    topBar: {
        backgroundColor: '#fff',
        height: 25,
        paddingTop: 20,
    },
    titleContainer: {
        backgroundColor: '#aaa',
        height: 40,
        padding: 10,
    },
})