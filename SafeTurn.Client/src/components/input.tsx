import React from 'react';
import { StyleSheet, Text, TextInput, View } from 'react-native';


export default function Input(props: any) {
    return (
        <View style={styles.content}>
            <Text style={styles.nameLabel}>{props.title}</Text>
            <View style={styles.inputView}>
                <TextInput
                    style={styles.input}
                    placeholder={props.placeholder}
                    placeholderTextColor="#BFC5D2"
                    onChangeText={text => props.textChanged(text)}
                ></TextInput>
            </View>
        </View>
    )
}

const styles = StyleSheet.create({
    content: {
        width: "100%",
    },
    inputView: {
        width: "100%",
        height: 34,
        justifyContent: 'center',
        borderBottomColor: '#BFC5D2',
        borderBottomWidth: 2,
        marginTop: 20,
    },
    input: {
        height: 30,
        fontFamily: 'OpenSans',
        fontSize: 18,
        letterSpacing: 0.23,
        lineHeight: 24,
    },
    nameLabel: {
        height: 20,
        color: '#69707F',
        fontFamily: 'OpenSans',
        fontSize: 15,
        fontWeight: 'bold',
        letterSpacing: 0.19,
        lineHeight: 20,
        textTransform: 'uppercase'
    }
})