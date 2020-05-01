import { AsyncStorage } from 'react-native';

export default class StorageService {
    static storeData = async (key: string, value: any) => {
        try {
            await AsyncStorage.setItem(key, value)
        } catch (e) {
            // saving error
        }
    }

    static getData = async (key: string) => {
        try {
            const value = await AsyncStorage.getItem(key)
            if(value !== null) {
                // value previously stored
                return value;
            }
        } catch(e) {
        // error reading value
        }
    }
}