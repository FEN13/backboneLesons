var Router = Backbone.Router.extend({
    routes: {
        '': 'home',// имя функции в которой обрабатывается запрос при навигации ""
        'new': 'editUser',
        'edit/:id': 'editUser'
    },

    home: function () {
        userlist.render();
    },
    
    editUser: function(id) {
        editUser.render(id);
    }
});
var router = new Router();

//router.on('route:home', function() { //верный вариант
//    console.log("yep yep yep on");
//});

Backbone.history.start();

