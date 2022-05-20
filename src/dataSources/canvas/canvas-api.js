const {RESTDataSource} = require('apollo-datasource-rest');

class CanvasAPI extends RESTDataSource {
    willSendRequest(request) {
        request.headers.set('Authorization', `Bearer ${this.context.authorization}`);
    }

    willSendResponse(response) {
        console.log(response.headers)
    }

    constructor() {
        super();
        this.baseURL = 'https://fhict.instructure.com/api/v1';
    }

    async getCourseData() {
        return this.get('courses');
    }
}

module.exports = {
    CanvasAPI
};