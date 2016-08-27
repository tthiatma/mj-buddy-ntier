(function() {
    var controllerId = 'app.views.home';
    var chatHub = $.connection.gameHub; //get a reference to the hub

    chatHub.client.getMessage = function (message) { //register for incoming messages
        console.log('received message: ' + message);
    };

    abp.event.on('abp.signalr.connected', function () { //register for connect event
        chatHub.server.sendMessage("Hi everybody, I'm connected to the chat!"); //send a message to the server
    });
    angular.module('app').controller(controllerId, [
        '$scope', function($scope) {
            var vm = this;
            //Home logic...
            
        }
    ]);
})();