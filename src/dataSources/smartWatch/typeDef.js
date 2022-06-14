const {gql} = require('apollo-server-express');

const typeDef = gql`
    type GraphData {
        name: String
        valueType: String
        datapoints: [DataPoint]
    }
    
    type DataPoint {
        value: Int
        timestamp: String        
    }
    
    type WatchData {
        HeartRateData: GraphData
        StressData: GraphData
    }
    
    extend type Query {
        WatchData: WatchData
    }
    `;

module.exports = {
    typeDef
}