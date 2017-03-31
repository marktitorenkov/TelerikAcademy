function solve() {
	return `
	<div class="tabs-control">
        <ul class="list list-titles">
        {{#titles}}
        	<li class="list-item">
                <label for="{{link}}" class="title">{{text}}</label>
            </li>
        {{/titles}}
        </ul>
        <ul class="list list-contents">
        {{#contents}}
	        <li class="list-item">
	            <input class="tab-content-toggle" id="{{link}}" 
					type="radio" name="tab-toggles" {{#unless @index}}checked="checked"{{/unless}}>
	            <div class="content">{{{text}}}</div>
	        </li>
	    {{/contents}}
	    </ul>
	</div>
	`;
}

if (typeof module !== 'undefined') {
	module.exports = solve
}
