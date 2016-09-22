(function() {
    var controllerId = 'app.views.game';
    var gameHub = $.connection.gameHub; //get a reference to the hub

    gameHub.client.getMessage = function (message) { //register for incoming messages
        console.log('received message: ' + message);
    };

    abp.event.on('abp.signalr.connected', function () { //register for connect event
        gameHub.server.sendMessage("Hi everybody, I'm connected to the chat!"); //send a message to the server
    });
    angular.module('app').controller(controllerId, [
        '$scope', '$modal', 'abp.services.app.mjGame',
        function ($scope, $modal, mjGameService) {
            var vm = this;

        }
    ]);
})();