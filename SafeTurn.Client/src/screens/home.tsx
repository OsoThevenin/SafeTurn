import React, { useEffect, useState } from 'react';
import { StyleSheet, Text, View, Button } from 'react-native';
import { AppLoading } from 'expo';
import * as Font from 'expo-font';
import Splash from '../components/splash';

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
        navigation.navigate('Change Name')
    }

    if(!fontReady) {
        return(
            <View>
                <Splash></Splash>
            </View>
        )
    } else {
        return (
            <View>
                <Text>Home</Text>
                <Button title="Change Name" onPress={pressHandler} />
            </View>
        )
    }
}