//Tests for app.js

describe('App', function () {
    beforeEach(module('SensibleApp'));

    it('should have a dummy test', inject(function () {
        expect(true).toBeTruthy();
    }));
});

