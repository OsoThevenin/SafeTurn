import React, { useState, useEffect } from 'react';
import { StyleSheet, Text, View, Button } from 'react-native';
import SecondaryButton from './secondaryButton';

export default function HourSelector(props: any) {
    const [availableHours, setAvailableHours] = useState([false, false, false, true, false, false]);

    const handleButtonClick = () => {
        console.log(props.hours);
    }

    useEffect(() => {

    }, []);

    if (props.displaying) {
        return (
            <View >
                <Text>Pedir turno en {props.shopName}</Text>
                <View style={styles.buttonContainer}>
                    <View style={styles.buttonL}>
                        <SecondaryButton title="Ahora" onPress={handleButtonClick} />
                    </View>
                    <View style={styles.buttonR}>
                        <SecondaryButton title="En 1 hora" onPress={handleButtonClick} />
                    </View>
                </View>

                <View style={styles.buttonContainer}>
                    <View style={styles.buttonL}>
                        <SecondaryButton title="En 15 minutos" onPress={handleButtonClick} />
                    </View>
                    <View style={styles.buttonR}>
                        <SecondaryButton title="En 2 horas" onPress={handleButtonClick} />
                    </View>
                </View>

                <View style={styles.buttonContainer}>
                    <View style={styles.buttonL}>
                        <SecondaryButton title="En 30 minutos" onPress={handleButtonClick} />
                    </View>
                    <View style={styles.buttonR}>
                        <SecondaryButton title="En 4 horas" onPress={handleButtonClick} />
                    </View>
                </View>
            </View>
        )
    } else {
        return (<View />);
    }

}

const styles = StyleSheet.create({
    buttonContainer: {
        marginTop: 10,
        flexDirection: 'row',
    },
    buttonL: {
        alignSelf: "stretch",
        flex: 1,
    },
    buttonR: {
        alignSelf: "stretch",
        flex: 1,
        marginLeft: 10,
    }
})