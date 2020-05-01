const BASE_URL = 'www.prova.com/api';

export default class ApiService {
    getShop(shopCode: string) {

        return fetch(`${BASE_URL}/getShop/${shopCode}`)
            .then((response) => response.json())
            .then((json) => {
                return json.movies;
            })
            .catch((error) => {
                console.error(error);
            });
    }
}