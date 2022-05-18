const {RESTDataSource} = require('apollo-datasource-rest');

class MockDataApi extends RESTDataSource {
    constructor() {
        super();
        this.baseURL = 'https://jsonplaceholder.typicode.com/';
    }

    async getMockData() {
        return this.get('users');
    }
}

module.exports = {
    MockDataApi
};