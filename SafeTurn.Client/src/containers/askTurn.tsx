import React, { useState, useEffect } from 'react';
import { StyleSheet, Text, View, TextInput, Button } from 'react-native';
import HourSelector from '../components/hourSelector';
import PrimaryButton from '../components/primaryButton';
import { ApiService } from '../services/api.service';
import Input from '../components/input';

export default function AskTurn() {
    const [text, onChangeText] = useState('');
    const [displayButtons, setDisplayButtons] = useState(false);
    const [buttonActive, setButtonActive] = useState(false);
    const [shopName, setShopName] = useState('');
    const [hours, setHours] = useState('');

    const setShopData = (json: any) => {
        setShopName(json.shopName);
        setHours(json.hours);
    }
    const handleButtonOnPress = () => {
        fetch(`http://itequia-covid19hack-dev.azurewebsites.net/shops?code=${text}`)
            .then((response) => response.json())
            .then((json) => setShopData(json))
            .catch((error) => console.error(error));
        setDisplayButtons(!displayButtons);
    }

    const handleInputChange = (text: string) => {
        onChangeText(text);
        if (text.length >= 4) {
            console.log("hi");
            setButtonActive(true);
        } else {
            setButtonActive(false);
            setDisplayButtons(false);
        }
    }

    return (
        <View>
            <Input
                title="Introduce el código del comercio"
                placeholder="Código del comercio"
                textChanged={handleInputChange}>
            </Input>
            <View style={styles.buttonContainer}>
                <PrimaryButton active={buttonActive} title="Pedir Turno" onPress={handleButtonOnPress} />
            </View>
            <HourSelector hours={hours} shopName={shopName} displaying={displayButtons} />
        </View>
    )
}

const styles = StyleSheet.create({
    buttonContainer: {
        marginTop: 10,
    }
})