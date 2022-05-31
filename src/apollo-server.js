const {gql, ApolloServer} = require("apollo-server-express");
const {ApolloServerPluginDrainHttpServer} = require("apollo-server-core");
const http = require("http");

const MockData = require("./dataSources/mock");
const CanvasData = require("./dataSources/canvas");
const LoggingPlugin = require("./plugins/logging");

const typeDef = gql`
    type Query
`;

async function startApolloServer(expressApp) {
    const httpServer = http.createServer(expressApp);
    const server = new ApolloServer({
        typeDefs: [typeDef, MockData.typeDef, CanvasData.typeDef],
        resolvers: [MockData.resolvers, CanvasData.resolvers ],
        dataSources: () => {
            return {
                mockDataAPI: new MockData.MockDataApi(),
                canvasAPI: new CanvasData.CanvasAPI()
            }
        },
        context: ({req}) => {
            return {
                // Add headers to the context, so we can forward them in the resolvers
                Authorization: req.headers.Authorization,
            }
        },
        plugins: [ApolloServerPluginDrainHttpServer({ httpServer }), LoggingPlugin]
    });

    await server.start();
    server.applyMiddleware({ app: expressApp });
    await new Promise(resolve => httpServer.listen({ port: 4000 }, resolve));
    console.log(`🚀 Server ready at http://localhost:4000${server.graphqlPath}`);
}

module.exports = {
    startApolloServer
};