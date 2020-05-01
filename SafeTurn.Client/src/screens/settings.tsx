import React from 'react';
import { StyleSheet, View, Button } from 'react-native';
import StorageService from '../services/storage.service';
import { CLIENT_NAME } from '../constants/app-constants';
import Input from '../components/input';

export default function Settings() {
    return (
        <View style={styles.container}>
            <View style={styles.inputContainer}>
                <Input></Input>
            </View>
            <View style={styles.buttonContainer}>
                <Button
                    title="Guardar"
                    onPress={() => StorageService.storeData(CLIENT_NAME, 'Pere')}
                />
            </View>
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        width: "100%",
        alignItems: 'center',
        justifyContent: 'center'
    },
    inputContainer: {
        flex: 1,
        alignItems: 'center',
        justifyContent: 'flex-end',
        width: "100%"
    },
    buttonContainer: {
        flex: 1,
        justifyContent: 'flex-end',
        marginBottom: 24,
        width: "100%"
    }
});