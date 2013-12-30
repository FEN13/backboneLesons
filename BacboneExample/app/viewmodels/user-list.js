$.fn.serializeObject = function () {
    var o = {};
    var a = this.serializeArray();
    $.each(a, function () {
        if (o[this.name] !== undefined) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
};

var UserList = Backbone.View.extend({
    el: ".page-content",

    render: function () {
        var self = this;
        self.users = new Users();
        self.users.fetch({
            success: function (data) {
                var template = _.template($('#user-list-template').html(), { users: data.models });
                self.$el.html(template);
            }
        });
    },
    events: {
        'click .delete': 'deleteUser'
    },
    deleteUser: function (ev) {
        var self = this;
        var id = $(ev.currentTarget).attr("userId");
        var usr = new User({ id: id });
        usr.fetch({
            success: function (data) {
                if (confirm("Are you shure you want to delete " + usr.get('Fname') + " " + usr.get('LName') + " user?")) {
                    usr.destroy({
                        success: function (data) {
                            $(ev.currentTarget).closest("tr").fadeOut();
                             var model = self.users.get(id);
                             self.users.remove(model);
                        }
                    });
                }
            }
        });
    }
});

var EditUser = Backbone.View.extend({
    el: ".page-content",
    render: function (id) {
        var self = this;
        var template;
        if (id) {
            self.curUser = new User({ id: id });
            self.curUser.fetch({
                success: function (userItem) {
                    template = _.template($('#edit-user-template').html(), { user: userItem });
                    self.$el.html(template);
                }
            });
        } else {
            template = _.template($('#edit-user-template').html(), { user: null });
            self.$el.html(template);
        }
    },
    events: {
        'submit .edit-user-form': 'saveUser',
        'click .delete': 'deleteUser'
    },
    saveUser: function (ev) {
        var userInfo = $(ev.currentTarget).serializeObject();
        var user = new User();
        user.save(userInfo, {
            success: function (data) {
                router.navigate('', { trigger: true });
            }
        });
        return false;
    },
    deleteUser: function (ev) {
        this.curUser.destroy({
            success: function (data) {
                router.navigate('', { trigger: true });
            }
        });
        return false;
    }
});

var userlist = new UserList();
var editUser = new EditUser();