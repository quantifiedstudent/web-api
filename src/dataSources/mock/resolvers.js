const resolvers = {
    Query: {
        mockData: async (_, __, { dataSources }) => {
            return dataSources.mockDataAPI.getMockData();
        },
    }
}

module.exports = {
    resolvers
}