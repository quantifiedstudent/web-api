const { ApolloServer, gql } = require('apollo-server-express');

const { ApolloServerPluginDrainHttpServer } = require('apollo-server-core');

const express = require('express');

const http = require('http');

require("dotenv").config();

const MockData = require("./dataSources/mock");
const CanvasData = require("./dataSources/canvas");
const LoggingPlugin = require("./plugins/logging");

const typeDef = gql`
    type Query
`;

async function startApolloServer(typeDefs, resolvers) {
    const app = express();
    const httpServer = http.createServer(app);
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
                authorization: req.headers.authorization,
            }
        },
        plugins: [ApolloServerPluginDrainHttpServer({ httpServer }), LoggingPlugin]
    });

    await server.start();
    server.applyMiddleware({ app });
    await new Promise(resolve => httpServer.listen({ port: 4000 }, resolve));
    console.log(`🚀 Server ready at http://localhost:4000${server.graphqlPath}`);
}

startApolloServer().then(() => {});