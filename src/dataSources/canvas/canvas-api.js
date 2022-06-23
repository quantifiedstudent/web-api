const {RESTDataSource} = require('apollo-datasource-rest');

class CanvasAPI extends RESTDataSource {
    willSendRequest(request) {
        console.log(this.context.Authorization)
        request.headers.set('Authorization', `Bearer ${this.context.Authorization}`);
    }

    willSendResponse(response) {
        // console.log(response.headers)
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