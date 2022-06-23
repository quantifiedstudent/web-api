const express = require('express');
const {startApolloServer} = require('./apollo-server');

const expressApp = express();
startApolloServer(expressApp).then(() => {});