(function () {
    var gameHub = $.connection.gameHub; //get a reference to the hub

    angular.module('app').controller('app.views.lobby.createModal', [
        '$scope', '$location', '$modalInstance', 'abp.services.app.mjGame',
        function ($scope, $location, $modalInstance, mjGameService) {
            var vm = this;

            vm.game = {
                isPrivateGame: false,
                roomPassword: '',
                mjRuleId: 1
            };

            vm.createMjGame = function () {
                gameHub.server.createMjGame(vm.game);
                $location.path('/');
                $modalInstance.close();
            };

            vm.cancel = function () {
                $modalInstance.dismiss();
            };
        }
    ]);
})();