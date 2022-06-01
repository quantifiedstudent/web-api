const resolvers = {
    Query: {
        mockData: async (_, __, { dataSources }) => {
            return dataSources.MockData.getMockData();
        },
    }
}

module.exports = {
    resolvers
}