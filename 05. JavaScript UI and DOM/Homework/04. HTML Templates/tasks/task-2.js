function solve() {

	return function(selector) {
		var DEFAULT_URL = 'http://cdn.playbuzz.com/cdn/3170bee8-985c-47bc-bbb5-2bcb41e85fe9/d8aa4750-deef-44ac-83a1-f2b5e6ee029a.jpg';

		var template = `
		<div class="container">
			<h1>Animals</h1>
			<ul class="animals-list">
			{{#each animals}}
				<li>
				{{#if this.url}}
					<a href="{{this.url}}">See a {{this.name}}</a>
				{{else}}
					<a href="${DEFAULT_URL}">No link for {{this.name}}, here is Batman!</a>
				{{/if}}
				</li>
		  {{/each}}
			</ul>
		</div>`;

		$(selector).html(template);
	};
}

module.exports = solve;
