import React from 'react';
import { StyleSheet, Text, View, TextInput, Button } from 'react-native';
import HourSelector from './hourSelector';
import PrimaryButton from './primaryButton';

export default function AskTurn() {
    const [value, onChangeText] = React.useState('');
    const [displayButtons, setDisplayButtons] = React.useState(false);

    const handleButtonOnPress = () => {
        setDisplayButtons(!displayButtons);
    }

    return (
        <View>
            <Text>Introduce el código del comercio</Text>
            <TextInput
                style={styles.textInput}
                value={value}
                placeholder="Código del comercio"
                onChangeText={text => onChangeText(text)}
            />
            <PrimaryButton title="Pedir Turno" onPress={handleButtonOnPress} />
            <HourSelector displaying={displayButtons} />
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