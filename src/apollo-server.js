const {gql, ApolloServer} = require("apollo-server-express");
const {ApolloServerPluginDrainHttpServer} = require("apollo-server-core");
const http = require("http");

const MockData = require("./dataSources/mock");
const CanvasData = require("./dataSources/canvas");
const LoggingPlugin = require("./plugins/logging");

const typeDef = gql`
    type Query
`;

const sources = [
    MockData,
    CanvasData
];

const typeDefs = [typeDef];
const resolvers = [];
const dataSources = {};

async function startApolloServer(expressApp) {
    const httpServer = http.createServer(expressApp);
    sources.forEach(source => {
        typeDefs.push(source.typeDef);
        resolvers.push(source.resolvers);
        dataSources[source.name] = new source.dataSource();
    });

    const server = new ApolloServer({
        typeDefs,
        resolvers,
        dataSources: () => {
            return dataSources;
        },
        context: ({req}) => {
            console.log(req.headers)
            return {
                // Add headers to the context, so we can forward them in the resolvers
                Authorization: req.headers.authorization,
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