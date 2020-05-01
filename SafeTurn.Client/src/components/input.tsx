import React from 'react';
import { StyleSheet, Text, TextInput, View } from 'react-native';


export default function Input() {
    return (
        <View style={styles.content}>
            <Text style={styles.nameLabel}>NOM COMPLET</Text>
            <View>
                <TextInput
                    style={styles.input}
                ></TextInput>
            </View>
        </View>
    )
}

const styles = StyleSheet.create({
    content: {
        width: "80%",
    },
    input: {
        borderWidth: 2,
        borderBottomColor: '#BFC5D2',
        height: 30,
        width: 80,
        marginTop: 20,
    },
    nameLabel: {
        height: 20,
        color: '#69707F',
        fontFamily: 'OpenSans',
        fontSize: 15,
        fontWeight: 'bold',
        letterSpacing: 0.19,
        lineHeight: 20
    }
})