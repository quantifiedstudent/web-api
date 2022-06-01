const {MockDataApi} = require('./mock-api');
const {resolvers} = require('./resolvers');
const {typeDef} = require('./typeDef');


module.exports = {
    name: 'MockData',
    dataSource: MockDataApi,
    resolvers,
    typeDef
}