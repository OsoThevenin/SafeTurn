import AsyncStorage from '@react-native-community/async-storage';

export default class StorageService {
    storeData = async (key: string, value: any) => {
        try {
            await AsyncStorage.setItem(key, value)
        } catch (e) {
            // saving error
        }
    }

    getData = async (key: string) => {
        try {
            const value = await AsyncStorage.getItem(key)
            if(value !== null) {
                // value previously stored
                
            }
        } catch(e) {
        // error reading value
        }
    }
}