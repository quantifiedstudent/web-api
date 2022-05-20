const resolvers = {
    Query: {
        CanvasCourse: async (_, __, { dataSources }) => {
            return dataSources.canvasAPI.getCourseData();
        },
    }
}

module.exports = {
    resolvers
}