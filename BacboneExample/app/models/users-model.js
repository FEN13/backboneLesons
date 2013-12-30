var User = Backbone.Model.extend({
    urlRoot: '/api/users'
});

var Users = Backbone.Collection.extend({
    url: '/api/users',
    
    sortAttribute: 'FName',
    sortDirection: 1,

    sortUsers: function (attr) {
        this.sortAttribute = attr;
        this.sort();
    },

    comparator: function (a, b) {
        var a = a.get(this.sortAttribute);
        var b = b.get(this.sortAttribute);

        if (a == b) return 0;

        if (this.sortDirection == 1) {
            return a > b ? 1 : -1;
        } else {
            return a < b ? 1 : -1;
        }
    },
});

