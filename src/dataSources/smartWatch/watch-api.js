const {RESTDataSource} = require('apollo-datasource-rest');

const StressData = require('./stress-data');
const HeartRateData = require('./heart-rate-data');

class WatchDataApi {
    constructor() {
    }

    getWatchData() {
        return {
            StressData,
            HeartRateData
        }
    }
}

module.exports = {
    WatchDataApi
};