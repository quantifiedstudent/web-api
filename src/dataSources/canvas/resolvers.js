const resolvers = {
    Query: {
        CanvasCourses: async (_, __, { dataSources }) => {
            return dataSources.CanvasData.getCourseData();
        },
    }
}

module.exports = {
    resolvers
}