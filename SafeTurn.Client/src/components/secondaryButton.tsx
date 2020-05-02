import React from 'react';
import { StyleSheet, TouchableOpacity, Text } from 'react-native';

export default function SecondaryButton(props: any) {
    return (
        <TouchableOpacity style={props.active ? styles.activeButton : styles.nonActiveButton} onPress={props.onPress}>
            <Text style={styles.text}>{props.title}</Text>
        </TouchableOpacity>
    )
}

const styles = StyleSheet.create({
    activeButton: {
        backgroundColor: '#3DAFA4',
        borderRadius: 15
    },
    nonActiveButton: {
        backgroundColor: '#3DAFA450',
        borderRadius: 15
    },
    text: {
        textAlign: 'center',
        padding: 10,
        color: '#fff',
        fontWeight: 'bold',
    }
})