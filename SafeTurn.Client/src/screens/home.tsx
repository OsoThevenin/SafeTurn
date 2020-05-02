import React, { useEffect, useState } from 'react';
import { StyleSheet, Text, View, Button } from 'react-native';
import * as Font from 'expo-font';
import Splash from '../components/splash';
import AskTurn from '../components/askTurn';
import MyShopsList from '../components/myShopsList';

export default function Home({ navigation }: { navigation: any }) {
    const [fontReady, setFontReady] = useState(false);

    useEffect(() => {
        const loadFont = async () => {
            await Font.loadAsync({
                'OpenSans': require('../../assets/fonts/OpenSans-Regular.ttf')
            });
            setFontReady(true);
        };
        loadFont();
    }, []);

    const pressHandler = () => {
        navigation.navigate('Settings')
    }

    if(!fontReady) {
        return(
            <View>
                <Splash></Splash>
            </View>
        )
    } else {
        return (
            <View style={styles.homeContainer}>
                <AskTurn />
                <MyShopsList />
                <Button title="Change Name" onPress={pressHandler} />
            </View>
        )
    }
}

const styles = StyleSheet.create({
    homeContainer: {
        paddingHorizontal: 20,
        paddingTop: 20,
    },
})
