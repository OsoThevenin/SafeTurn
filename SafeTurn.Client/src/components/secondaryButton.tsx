import React from 'react';
import { StyleSheet, TouchableOpacity, Text } from 'react-native';

export default function SecondaryButton(props: any) {
    return (
        <TouchableOpacity style={styles.container} onPress={props.onClick}>
            <Text style={styles.text}>{props.title}</Text>
        </TouchableOpacity>
    )
}

const styles = StyleSheet.create({
    container: {
        backgroundColor: '#3DAFA4',
        borderRadius: 15
    },
    text: {
        textAlign: 'center',
        padding: 10,
        color: '#fff',
        fontWeight: 'bold',
    }
})