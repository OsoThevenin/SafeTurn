import React from 'react';
import { StyleSheet, View, Image } from 'react-native';

export default function Splash() {
    return(
        <View style={styles.container}>
            <Image
                style={styles.image}
                source={require('../../assets/logo.png')}
            />
        </View>
    )
}

const styles = StyleSheet.create({
    image: {
        width: 212,
        height: 64
    },
    container: {
        flex: 1,
        backgroundColor: '#27A699'
    }
});