const {WatchDataApi} = require('./watch-api');
const {resolvers} = require('./resolvers');
const {typeDef} = require('./typeDef');


module.exports = {
    name: 'WatchData',
    dataSource: WatchDataApi,
    resolvers,
    typeDef
}