import React, { useEffect, useState } from 'react';
import { StyleSheet, View, Image } from 'react-native';
import StorageService from '../services/storage.service';
import { CLIENT_NAME } from '../constants/app-constants';
import Input from '../components/input';
import PrimaryButton from '../components/primaryButton';

export default function Settings({ navigation }: { navigation: any }) {
    const [inputValue, setInputValue] = useState('');

    const handleInputChange = (text: string) => {
        setInputValue(text);
    }

    const handleButtonOnPress = () => {
        StorageService.storeData(CLIENT_NAME, inputValue)
            .then(() => navigation.navigate('Home'))
            .catch((e) => console.log(e.message));
    }

    return (
        <View style={styles.container}>
            <View style={styles.imageContainer}>
                <Image
                    style={styles.image}
                    source={require('../../assets/change-name/Bitmap.png')}
                />
            </View>
            <View style={styles.inputContainer}>
                <Input title="Nom complet" placeholder="Introdueix el teu nom" textChanged={handleInputChange}></Input>
            </View>
            <View style={styles.buttonContainer}>
                <PrimaryButton active={true} title="Guardar" onPress={handleButtonOnPress} />
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
        width: "90%"
    },
    imageContainer: {
        flex: 2,
        width: 300,
        height: 300,
        backgroundColor: '#27A699',
        borderRadius: 200,
        alignItems: 'center',
        justifyContent: 'center',
        marginTop: 40
    },
    image: {
        flex: 1,
        width: '70%',
        height: '100%'
    }
});