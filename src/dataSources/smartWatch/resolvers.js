const resolvers = {
    Query: {
        WatchData: async (_, __, { dataSources }) => {
            return dataSources.WatchData.getWatchData();
        }
    }
}

module.exports = {
    resolvers
}