const {CanvasAPI} = require('./canvas-api');
const {resolvers} = require('./resolvers');
const {typeDef} = require('./typeDef');


module.exports = {
    name: 'CanvasData',
    dataSource: CanvasAPI,
    resolvers,
    typeDef
}