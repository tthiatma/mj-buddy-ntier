(function() {
    var controllerId = 'app.views.lobby';
    var chatHub = $.connection.gameHub; //get a reference to the hub

    chatHub.client.getMessage = function (message) { //register for incoming messages
        console.log('received message: ' + message);
    };

    abp.event.on('abp.signalr.connected', function () { //register for connect event
        chatHub.server.sendMessage("Hi everybody, I'm connected to the chat!"); //send a message to the server
    });
    angular.module('app').controller(controllerId, [
        '$scope', '$modal', 'abp.services.app.mjGame',
        function ($scope, $modal, mjGameService) {
            var vm = this;

            vm.games = [];

            vm.getMjGamesInput = {
                Count: 10
            };

            var getAllMjGames = function () {
                mjGameService.getMjGames(
                        vm.getMjGamesInput
                    ).success(function (result) {
                        vm.games = result.items;
                    })
            };

            vm.openGameCreationModal = function () {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/lobby/createModal.cshtml',
                    controller: 'app.views.lobby.createModal as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    getAllMjGames();
                });
            };

            getAllMjGames();         
        }
    ]);
})();