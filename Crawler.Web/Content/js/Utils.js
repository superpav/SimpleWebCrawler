var Utils = {};

(function(scope)
{
	scope.onAjaxError = function()
	{
		scope.hideLoader();
		$('#errorModal').modal('show');
	};

	scope.hideLoader = function()
	{
		$('.loader').hide();
	};

	scope.showLoader = function()
	{
		$('.loader').show();
	}
})(Utils);