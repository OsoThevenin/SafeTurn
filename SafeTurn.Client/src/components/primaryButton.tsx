import React from 'react';
import { StyleSheet, TouchableOpacity, Text } from 'react-native';

export default function PrimaryButton(props: any) {
    const handleOnPress = () => {
        if (props.active) {
            props.onPress();
        }
    }

    return (
        <TouchableOpacity style={styles.container} onPress={handleOnPress}>
            <Text style={styles.text}>{props.title}</Text>
        </TouchableOpacity>
    )
}

const styles = StyleSheet.create({
    container: {
        backgroundColor: '#FA5A5E',
        borderRadius: 20
    },
    text: {
        textAlign: 'center',
        padding: 20,
        color: '#fff',
        fontWeight: 'bold',
    }
})