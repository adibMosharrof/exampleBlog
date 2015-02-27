(function () {
    'use strict';

    angular
        .module('blog')
        .factory('breezeSaveChangesFactory', breezeSaveChangesFactory);

    breezeSaveChangesFactory.$inject = ['$http'];

    function breezeSaveChangesFactory($http) {
        var manager = null;
        var service = {
            saveChanges:saveChanges
        };

        return service;

        function saveChanges(currentManager) {
            debugger;
            manager = currentManager;
            var promise = null;
            var saveBatches = prepareSaveBatches();
            saveBatches.forEach(function(batch) {
                if (batch == null || batch.length > 0) {
                    promise = promise ?
                        promise.then(function () { return manager.saveChanges(batch); }) :
                        manager.saveChanges(batch);
                }
            });
            return promise.then(success).catch(failed);

        }

        function prepareSaveBatches() {
            var batches = [];

            batches.push(manager.getEntities(['Post'], [breeze.EntityState.Deleted]));
            batches.push(manager.getEntities(['Post'], [breeze.EntityState.Added]));
            batches.push(null); // empty = save all remaining pending changes
            return batches;

        }

        function success(result) {
            alert('successfully saved ' + result);
        }

        function failed(error) {
            alert('failed to save changes , error : ' + error);
        }
    }
})();