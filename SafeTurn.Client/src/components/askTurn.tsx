import React, { useState, useEffect } from 'react';
import { StyleSheet, Text, View, TextInput, Button } from 'react-native';
import HourSelector from './hourSelector';
import PrimaryButton from './primaryButton';
import { ApiService } from '../services/api.service';

export default function AskTurn() {
    const [text, onChangeText] = useState('');
    const [displayButtons, setDisplayButtons] = useState(false);
    const [buttonActive, setButtonActive] = useState(false);
    const [shopName, setShopName] = useState('');

    const handleButtonOnPress = () => {
        setDisplayButtons(!displayButtons);
        fetch(`http://itequia-covid19hack-dev.azurewebsites.net/shops?code=${text}`)
            .then((response) => response.json())
            .then((json) => setShopName(json.name))
            .catch((error) => console.error(error));
    }

    const handleOnChangeText = (text: string) => {
        onChangeText(text);
        if (text.length >= 5) {
            console.log("hi");
            setButtonActive(true);
        } else {
            setButtonActive(false);
        }
    }

    return (
        <View>
            <Text>Introduce el código del comercio</Text>
            <TextInput
                style={styles.textInput}
                value={text}
                placeholder="Código del comercio"
                onChangeText={text => handleOnChangeText(text)}
            />
            <PrimaryButton active={buttonActive} title="Pedir Turno" onPress={handleButtonOnPress} />
            <HourSelector shopName={shopName} displaying={displayButtons} />
        </View>
    )
}

const styles = StyleSheet.create({
    textInput: {
        height: 40,
        borderColor: 'gray',
        borderBottomWidth: 1,
        marginBottom: 10,
    },
})