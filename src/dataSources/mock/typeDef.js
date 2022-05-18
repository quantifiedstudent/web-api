const {gql} = require('apollo-server');

const typeDef = gql`
    type Company {
      name: String
      catchPhrase: String
      bs: String
    }
    
    type Geo {
      lat: String
      lng: String
    }
    
    type Address {
      street: String
      suite: String
      city: String
      zipcode: String
      geo: Geo
    }
    
    type MockData {
      id: Int
      name: String
      username: String
      email: String
      phone: String
      website: String
      company: Company
      address: Address
    }
    
    extend type Query {
        mockData: [MockData]
    }
    `;

module.exports = {
    typeDef
}