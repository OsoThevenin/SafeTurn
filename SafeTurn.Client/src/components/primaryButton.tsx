import React from 'react';
import { StyleSheet, TouchableOpacity, Text } from 'react-native';

export default function PrimaryButton(props: any) {
    const handleOnPress = () => {
        if (props.active) {
            props.onPress();
        }
    }

    return (
        <TouchableOpacity style={props.active ? styles.activeButton : styles.nonActiveButton} onPress={handleOnPress}>
            <Text style={styles.text}>{props.title}</Text>
        </TouchableOpacity>
    )
}

const styles = StyleSheet.create({
    activeButton: {
        backgroundColor: '#FA5A5E',
        borderRadius: 20
    },
    nonActiveButton: {
        backgroundColor: '#FA5A5E50',
        borderRadius: 20,
    },
    text: {
        textAlign: 'center',
        padding: 20,
        color: '#fff',
        fontWeight: 'bold',
    }
})