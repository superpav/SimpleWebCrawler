(function()
{
	var $resultsContainer;

	function onNextPageLoaded(content)
	{
		var $content = $(content);

		if ($content.length == 0)
			$resultsContainer.data('no-more-elements', true);

		var $container = $('.list-group', '.search-results-container');

		$resultsContainer.data('loading', false);

		$container.append($content);
	}

	function tryLoadNextPage()
	{
		if ($resultsContainer.data('no-more-elements'))
			return;

		if ($resultsContainer.data('loading'))
			return;

		$resultsContainer.data('loading', true);

		var offset = $('.list-group-item', $resultsContainer).last().data('id');

		if (offset == undefined)
			return;

		var $form = $('form', '.search-form');
		var url = $form.attr('action');
		var data = $form.serialize() + "&offset=" + offset;

		$.ajax({
			url: url,
			type: 'POST',
			data: data,
			success: onNextPageLoaded,
			error: Utils.onAjaxError
		});
	}

	function onScroll()
	{
		var $document = $(document);
		var $window = $(window);

		if ($document.height() - $window.scrollTop() - $window.height() > 100)
			return;

		tryLoadNextPage();
	}

	function init()
	{
		$resultsContainer = $('.search-results-container');

		if ($resultsContainer.data('scroll-loader-enabled') == 'False')
			return;

		$(document).scroll(onScroll);
	}

	$(document).ready(init);
})();