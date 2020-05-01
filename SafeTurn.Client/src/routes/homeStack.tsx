import { createStackNavigator } from 'react-navigation-stack';
import { createAppContainer } from 'react-navigation';
import Home from '../screens/home';
import PantallaDos from '../screens/pantalla2';
import Name from '../screens/name';

const screens = {
    // Home: {
    //     screen: Home,
    // },
    // PantallaDos: {
    //     screen: PantallaDos,
    // },
    Name: {
        screen: Name,
    }
}

const HomeStack = createStackNavigator(screens);

export default createAppContainer(HomeStack);