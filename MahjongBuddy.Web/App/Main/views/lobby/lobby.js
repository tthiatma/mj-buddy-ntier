﻿(function() {
    var controllerId = 'app.views.lobby';
    var chatHub = $.connection.gameHub; //get a reference to the hub

    chatHub.client.getMessage = function (message) { //register for incoming messages
        console.log('received message: ' + message);
    };

    abp.event.on('abp.signalr.connected', function () { //register for connect event
        chatHub.server.sendMessage("Hi everybody, I'm connected to the chat!"); //send a message to the server
    });
    angular.module('app').controller(controllerId, [
        '$scope', 'abp.services.app.mjGame', function ($scope, mjGameService) {
            var vm = this;
      
            vm.game = {
                isPrivateGame: true,
                gameRoomPassword: 'rawr',
                mjRuleId: 1
            };
            
            vm.getMjGamesInput = {
                Count: 10
            };

            vm.getAllMjGames = function () {
                abp.ui.setBusy(
                    null,
                    mjGameService.getMjGames(
                        vm.getMjGamesInput
                    ).success(function (result) {
                        var test = result;
                    })
                );
            };

            vm.createMjGame = function () {
                abp.ui.setBusy(
                    null,
                    mjGameService.createMjGame(
                        vm.game
                    ).success(function () {
                        abp.notify.info(abp.utils.formatString(localize("GameCreatedMessage")));
                        $location.path('/');
                    })
                );
            };
        }
    ]);
})();