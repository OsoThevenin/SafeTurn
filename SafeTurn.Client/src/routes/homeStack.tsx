import { createStackNavigator } from 'react-navigation-stack';
import { createAppContainer } from 'react-navigation';
import Home from '../screens/home';
import PantallaDos from '../screens/pantalla2';

const screens = {
    Home: {
        screen: Home,
    },
    PantallaDos: {
        screen: PantallaDos,
    }
}

const HomeStack = createStackNavigator(screens);

export default createAppContainer(HomeStack);