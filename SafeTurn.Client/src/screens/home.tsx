import React from 'react';
import { StyleSheet, Text, View, Button } from 'react-native';
import AskTurn from '../components/askTurn';
import MyShopsList from '../components/myShopsList';

export default function Home() {
    return (
        <View style={styles.homeContainer}>
            <AskTurn />
            <MyShopsList />
        </View>
    )
}

const styles = StyleSheet.create({
    homeContainer: {
        paddingHorizontal: 20,
        paddingTop: 20,
    },
})