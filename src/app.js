const { ApolloServer, gql } = require('apollo-server');

const MockData = require("./dataSources/mock");
const CanvasData = require("./dataSources/canvas");
const {CanvasAPI} = require("./dataSources/canvas/canvas-api");

const typeDef = gql`
  type Query
`;

// The ApolloServer constructor requires two parameters: your schema
// definition and your set of resolvers.
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
    }
    // csrfPrevention: true,
});

// The `listen` method launches a web server.
server.listen().then(({ url }) => {
    console.log(`🚀  Server ready at ${url}`);
});