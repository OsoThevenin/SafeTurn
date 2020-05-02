import React, { useState, useEffect } from 'react';
import { StyleSheet, Text, View, Button } from 'react-native';
import SecondaryButton from './secondaryButton';

export default function HourSelector(props: any) {
    const [hourNames, setHourNames] = useState(['Ahora', 'En 15 minutos', 'En 30 minutos', 'En 1 hora', 'En 2 horas', 'En 4 horas']);
    const [availableHours, setAvailableHours] = useState([true, false, false, true, false, false]);
    const [offers, setOffers] = useState(['', '', '', '', '', '']);

    const handleButtonClick = () => {
        console.log(props.hours[0].range);
    }

    useEffect(() => {
        var hours: boolean[] = [];
        for (var i = 0; i < props.hours.length; i++) {
            console.log("hora");
            hours[props.hours[i].range] = true;
        }
        setAvailableHours(hours);
    }, []);

    if (props.displaying) {
        return (
            <View style={styles.container}>
                <Text>Pedir turno en <Text style={styles.shopName}>{props.shopName}</Text></Text>
                <View style={styles.buttonContainer}>
                    <View style={styles.buttonL}>
                        <SecondaryButton
                            active={availableHours[0]}
                            title={hourNames[0]}
                            onPress={handleButtonClick}
                        />
                    </View>
                    <View style={styles.buttonR}>
                        <SecondaryButton
                            active={availableHours[3]}
                            title={hourNames[3]}
                            onPress={handleButtonClick}
                        />
                    </View>
                </View>

                <View style={styles.buttonContainer}>
                    <View style={styles.buttonL}>
                        <SecondaryButton
                            active={availableHours[1]}
                            title={hourNames[1]}
                            onPress={handleButtonClick}
                        />
                    </View>
                    <View style={styles.buttonR}>
                        <SecondaryButton
                            active={availableHours[4]}
                            title={hourNames[4]}
                            onPress={handleButtonClick}
                        />
                    </View>
                </View>

                <View style={styles.buttonContainer}>
                    <View style={styles.buttonL}>
                        <SecondaryButton
                            active={availableHours[2]}
                            title={hourNames[2]}
                            onPress={handleButtonClick}
                        />
                    </View>
                    <View style={styles.buttonR}>
                        <SecondaryButton
                            active={availableHours[5]}
                            title={hourNames[5]}
                            onPress={handleButtonClick}
                        />
                    </View>
                </View>
            </View>
        )
    } else {
        return (<View />);
    }

}

const styles = StyleSheet.create({
    container: {
        marginTop: 10,
    },
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
    },
    shopName: {
        fontWeight: 'bold',
    }
})