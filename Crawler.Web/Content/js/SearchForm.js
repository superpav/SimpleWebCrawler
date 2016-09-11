(function()
{
	function onFormSuccess(content)
	{
		var $content = $(content);
		var $container = $('.list-group', '.search-results-container');

		Utils.hideLoader();
		$('.list-group').removeClass('disabled');

		$container.empty();
		$container.append($content);
	}

	function onFormSubmit(event)
	{
		event.preventDefault();

		var $target = $(event.target);

		if (!$target.valid())
			return;

		var url = $target.attr('action');

		Utils.showLoader();
		$('.list-group').addClass('disabled');

		$.ajax({
			url: url,
			type: 'POST',
			data: $target.serialize(),
			success: onFormSuccess,
			error: Utils.onAjaxError
		});
	}

	function init()
	{
		var $searchForm = $('form', '.search-form');

		$searchForm.submit(onFormSubmit);
	}

	$(document).ready(init);
})();