import React, { useEffect, useState } from 'react';
import { StyleSheet, Text, View, Button } from 'react-native';
import * as Font from 'expo-font';
import Splash from '../components/splash';
import AskTurn from '../containers/askTurn';
import MyShopsList from '../containers/myShopsList';
import StorageService from '../services/storage.service';
import { CLIENT_NAME } from '../constants/app-constants';

export default function Home({ navigation }: { navigation: any }) {
    const [fontReady, setFontReady] = useState(false);
    const [userLogged, setUserLogged] = useState(false);

    useEffect(() => {
        const loadFont = async () => {
            await Font.loadAsync({
                'OpenSans': require('../../assets/fonts/OpenSans-Regular.ttf')
            });
            setFontReady(true);
        };
        const checkUserLogged = async () => {
            await loadFont();
            const name = await StorageService.getData(CLIENT_NAME);

            if (name === null) {
                setUserLogged(true);
            } else {
                navigation.navigate('Settings')
            }
        };
        checkUserLogged();
    }, []);

    if(!fontReady && !userLogged) {
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
