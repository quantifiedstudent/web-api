const resolvers = {
    Query: {
        CanvasCourses: async (_, __, { dataSources }) => {
            return dataSources.canvasAPI.getCourseData();
        },
    }
}

module.exports = {
    resolvers
}