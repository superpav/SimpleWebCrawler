(function()
{
	function onFormSuccess(content)
	{
		var $content = $(content);
		var $container = $('.list-group', '.search-results-container');

		$('.loader').hide();

		$container.empty();
		$container.append($content);
	}

	function onFormError()
	{
	}

	function onFormSubmit(event)
	{
		event.preventDefault();

		var $target = $(event.target);
		var url = $target.attr('action');

		$('.loader').show();

		console.log($target.serialize());

		$.post({
			url: url,
			data: $target.serialize(),
			success: onFormSuccess,
			error: onFormError
		});
	}

	function init()
	{
		var $searchForm = $('form', '.search-form');

		$searchForm.submit(onFormSubmit);
	}

	$(document).ready(init);
})();