/*
 * jQuery MultiSelect UI Widget 1.6
 * Copyright (c) 2010 Eric Hynds
 *
 * http://www.erichynds.com/jquery/jquery-ui-multiselect-widget/
 *
 * Depends:
 *   - jQuery 1.4.2+
 *   - jQuery UI 1.8 widget factory
 *
 * Optional:
 *   - jQuery UI effects
 *   - jQuery UI position utility
 *
 * Dual licensed under the MIT and GPL licenses:
 *   http://www.opensource.org/licenses/mit-license.php
 *   http://www.gnu.org/licenses/gpl.html
 *
*/
(function($){

var multiselectID = 0;

$.widget("ech.multiselect", {
	
	// default options
	options: {
		header: true,
		height: 175, // height of the checkbox container (scroll) in pixels
		minWidth: 225, // min width of the entire widget in pixels. setting to 'auto' will disable
		classes: '', // additional class(es) to apply to the button & menu
		checkAllText: 'Todas',
		uncheckAllText: 'Todas',
		noneSelectedText: 'Selecciones',
		selectedText: '# seleccionada',
		selectedList: 2,
		show: '',
		hide: '',
		autoOpen: false,
		multiple: true,
		position: {}
	},

	_create: function(){
		var self = this,
			el = this.element,
			o = this.options,
			html = [],
			optgroups = [], 
			title = el.attr('title'),
			id = el.attr('id') || multiselectID++; // unique ID for the label & option tags
		
		this.speed = $.fx.speeds._default; // default speed for effects
		this._isOpen = false; // assume no
	
		// the actual button
		html.push('<button type="button" class="ui-multiselect ui-widget ui-state-default ui-corner-all');
		if( o.classes.length ){
			html.push(' ' + o.classes);
		}
		html.push('"');
		if( title.length ){
			html.push(' title="'+title+'"');
		}
		html.push('><span class="ui-icon ui-icon-triangle-2-n-s"></span><span>'+ o.noneSelectedText +'</span></button>');
		
		// start menu container
		html.push('<div class="ui-multiselect-menu ui-widget ui-widget-content ui-corner-all ' +(o.classes.length ? o.classes : '')+ '">');
	
		// header
		html.push('<div class="ui-widget-header ui-corner-all ui-multiselect-header ui-helper-clearfix">');
		html.push('<ul class="ui-helper-reset">');
		if(o.header === true && o.multiple ){
			html.push('<li><a class="ui-multiselect-all" href="#"><span class="ui-icon ui-icon-check"></span><span>' + o.checkAllText + '</span></a></li>');
			html.push('<li><a class="ui-multiselect-none" href="#"><span class="ui-icon ui-icon-closethick"></span><span>' + o.uncheckAllText + '</span></a></li>');
		} else if(typeof o.header === "string"){
			html.push('<li>'+o.header+'</li>');
		}
		html.push('<li class="ui-multiselect-close"><a href="#" class="ui-multiselect-close"><span class="ui-icon ui-icon-circle-close"></span></a></li>');
		html.push('</ul>');
		html.push('</div>');

		// checkboxes
		html.push('<ul class="ui-multiselect-checkboxes ui-helper-reset">');
		
		// loop through each option tag
		el.find('option').each(function(i){
			var $this = $(this), 
				title = $this.html(),
				value = this.value, 
				inputID = this.id || "ui-multiselect-"+id+"-option-"+i, 
				$parent = $this.parent(), 
				isDisabled = $this.is(':disabled'), 
				labelClasses = ['ui-corner-all'];
			
			if( $parent.is('optgroup') ){
				var label = $parent.attr('label');
				
				if( $.inArray(label,optgroups) === -1 ){
					html.push('<li class="ui-multiselect-optgroup-label"><a href="#">' + label + '</a></li>');
					optgroups.push(label);
				}
			}
		
			if( value.length > 0 ){
				if( isDisabled ){
					labelClasses.push('ui-state-disabled');
				}
				
				html.push('<li class="'+(isDisabled ? 'ui-multiselect-disabled' : '')+'">');
				html.push('<label for="'+inputID+'" class="'+labelClasses.join(' ')+ '"><input id="'+inputID+'" name="multiselect_'+id+'" type="'+(o.multiple ? "checkbox" : "radio")+'" value="'+value+'" title="'+title+'"');
				if( $this.is(':selected') ){
					html.push(' checked="checked"');
				}
				if( isDisabled ){
					html.push(' disabled="disabled"');
				}
				html.push(' />'+title+'</label></li>');
			}
		});
		
		// close everything off
		html.push('</ul></div>');
		
		// cache elements
		this.button = el.hide().after( html.join('') ).next('button');
		this.menu = this.button.next('div.ui-multiselect-menu');
		this.labels = this.menu.find('label');
		this.buttonlabel = this.button.find('span').eq(-1);

		// set widths
		this._setButtonWidth();
		this._setMenuWidth();
		
		// perform event bindings
		this._bindEvents();
		
		this.button[0].defaultValue = this.update();
	},
	
	_init: function(){
		if( !this.options.header ){
			this.menu.find('div.ui-multiselect-header').hide();
		}
		if( this.options.autoOpen ){
			this.open();
		}
		if( this.element.is(':disabled') ){
			this.disable();
		}
	},
	
	// binds events
	_bindEvents: function(){
		var self = this, button = this.button;
		
		function clickHandler( e ){
			self[ self._isOpen ? 'close' : 'open' ]();
			return false;
		}
		
		// webkit doesn't like it when you click on the span :(
		button.find('span').bind('click.multiselect', clickHandler);
		
		// button events
		button.bind({
			click: clickHandler,
			keypress: function(e){
				switch(e.keyCode){
					case 27: // esc
					case 38: // up
					case 37: // left
						self.close();
						break;
					case 39: // right
					case 40: // down
						self.open();
						break;
				}
			},
			mouseenter: function(){
				if(!button.hasClass('ui-state-disabled')){
					$(this).addClass('ui-state-hover');
				}
			},
			mouseleave: function(){
				$(this).removeClass('ui-state-hover');
			},
			focus: function(){
				if(!button.hasClass('ui-state-disabled')){
					$(this).addClass('ui-state-focus');
				}
			},
			blur: function(){
				$(this).removeClass('ui-state-focus');
			}
		});

		// header links
		this.menu.find('div.ui-multiselect-header a').bind('click.multiselect', function(e){
	
			// close link
			if( $(this).hasClass('ui-multiselect-close') ){
				self.close();
		
			// check all / uncheck all
			} else {
				self[ $(this).hasClass('ui-multiselect-all') ? 'checkAll' : 'uncheckAll' ]();
			}
		
			e.preventDefault();
		})
		
		// optgroup label toggle support
		.end()
		.find('li.ui-multiselect-optgroup-label a').bind('click.multiselect', function(e){
			var $this = $(this),
				$inputs = $this.parent().nextUntil('li.ui-multiselect-optgroup-label').find('input:visible');
				
			self._toggleChecked( $inputs.filter(':checked').length !== $inputs.length, $inputs );
			self._trigger('optgrouptoggle', e, {
				inputs: $inputs.get(),
				label: $this.parent().text(),
				checked: $inputs[0].checked
			});
			
			e.preventDefault();
		})
		
		// labels/checkbox events
		.end()
		.delegate('label', 'mouseenter', function(){
			if( !$(this).hasClass('ui-state-disabled') ){
				self.labels.removeClass('ui-state-hover');
				$(this).addClass('ui-state-hover').find('input').focus();
			}
		})
		.delegate('label', 'keydown', function(e){
			switch(e.keyCode){
				case 9: // tab
				case 27: // esc
					self.close();
					break;
				case 38: // up
				case 40: // down
				case 37: // left
				case 39: // right
					self._traverse(e.keyCode, this);
					e.preventDefault();
					break;
				case 13: // enter
					e.preventDefault();
					$(this).find('input').trigger('click');
					break;
			}
		})
		.delegate(':checkbox, :radio', 'click', function(e){
			var $this = $(this),
				val = this.value,
				checked = this.checked,
				tags = self.element.find('option');
			
			// bail if this input is disabled or the event is cancelled
			if( $this.is(':disabled') || self._trigger('click', e, { value:val, text:this.title, checked:checked }) === false ){
				e.preventDefault();
				return;
			}
			
			// make sure the original option tags are unselected first 
			// in a single select
			if( !self.options.multiple ){
				tags.not(function(){
					return this.value === val;
				}).removeAttr('selected');
			}
			
			// set the original option tag to selected
			tags.filter(function(){
				return this.value === val;
			}).attr('selected', (checked ? 'selected' : ''));
			
			// issue 14: if this event is natively fired, the box will be checked
			// before running the update.  using trigger(), the events fire BEFORE
			// the box is checked. http://dev.jquery.com/ticket/3827
			self.update( !e.originalEvent ? checked ? -1 : 1 : 0 );
		});
		
		// close each widget when clicking on any other element/anywhere else on the page
		$(document).bind('click.multiselect', function(e){
			var $target = $(e.target);
			
			if(self._isOpen && !$target.closest('div.ui-multiselect-menu').length && !$target.is('button.ui-multiselect')){
				self.close();
			}
		});
		
		// deal with form resets.  the problem here is that buttons aren't
		// restored to their defaultValue prop on form reset, and the reset
		// handler fires before the form is actually reset.  delaying it a bit
		// gives the form inputs time to clear.
		this.element.closest('form').bind('reset', function(){
			setTimeout($.proxy(self, 'update'), 1);
		});
	},

	// set button width
	_setButtonWidth: function(){
		var width = this.element.outerWidth(),
			o = this.options;
			
		if( /\d/.test(o.minWidth) && width < o.minWidth){
			width = o.minWidth;
		}
		
		// set widths
		this.button.width( width );
	},
	
	// set menu width
	_setMenuWidth: function(){
		var m = this.menu,
			width = this.button.outerWidth()
				-parseInt(m.css('padding-left'),10)
				-parseInt(m.css('padding-right'),10)
				-parseInt(m.css('border-right-width'),10)
				-parseInt(m.css('border-left-width'),10);
				
		m.width( width || this.button.outerWidth() );
	},
	
	// move up or down within the menu
	_traverse: function(keycode, start){
		var $start = $(start),
			moveToLast = (keycode === 38 || keycode === 37) ? true : false,
			
			// select the first li that isn't an optgroup label / disabled
			$next = $start.parent()[moveToLast ? 'prevAll' : 'nextAll']('li:not(.ui-multiselect-disabled, .ui-multiselect-optgroup-label)')[ moveToLast ? 'last' : 'first']();
		
		// if at the first/last element
		if( !$next.length ){
			var $container = this.menu.find('ul:last');
			
			// move to the first/last
			this.menu.find('label')[ moveToLast ? 'last' : 'first' ]().trigger('mouseover');
			
			// set scroll position
			$container.scrollTop( moveToLast ? $container.height() : 0 );
			
		} else {
			$next.find('label').trigger('mouseover');
		}
	},

	_toggleChecked: function(flag, group){
		var $inputs = (group && group.length) 
			? group
			: this.labels.find('input');

		// toggle state on inputs
		$inputs.not(':disabled').attr('checked', (flag ? 'checked' : '')); 
		
		this.update();
		
		// toggle state on original option tags
		this.element.find('option').not(':disabled').attr('selected', (flag ? 'selected' : ''));
	},

	_toggleDisabled: function(flag){
		this.button.attr('disabled', (flag ? 'disabled' : ''))[ flag ? 'addClass' : 'removeClass' ]('ui-state-disabled');
		this.menu.find('input').attr('disabled', (flag ? 'disabled' : '')).parent()[ flag ? 'addClass' : 'removeClass' ]('ui-state-disabled');
		this.element.attr('disabled', (flag ? 'disabled' : ''));
	},

	// updates the number of selected items in the button
	update: function( offset ){
		var o = this.options,
			$inputs = this.labels.find('input'),
			$checked = $inputs.filter(':checked'),
			numChecked = $checked.length,
			value;
		
		if( numChecked === 0 ){
			value = o.noneSelectedText;
		} else {
			if($.isFunction(o.selectedText)){
				value = o.selectedText.call(this, numChecked, $inputs.length, $checked.get());
			} else if( /\d/.test(o.selectedList) && o.selectedList > 0 && numChecked <= o.selectedList){
				value = $checked.map(function(){ return this.title; }).get().join(', ');
			} else {
				value = o.selectedText.replace('#', numChecked).replace('#', $inputs.length);
			}
		}
		
		this.buttonlabel.html( value );
		return value;
	},
	
	// open the menu
	open: function(e){
		var self = this,
			button = this.button,
			menu = this.menu,
			speed = this.speed,
			o = this.options;
	
		// bail if the multiselectopen event returns false, this widget is disabled, or is already open 
		if( this._trigger('beforeopen') === false || button.hasClass('ui-state-disabled') || this._isOpen ){
			return;
		}
		
		// close other instances
		$(':ech-multiselect').not(this.element).each(function(){
			var $this = $(this);
			
			if( $this.multiselect('isOpen') ){
				$this.multiselect('close');
			}
		});

		var $container = menu.find('ul:last'),
			effect = o.show,
			pos = button.position();
		
		// figure out opening effects/speeds
		if( $.isArray(o.show) ){
			effect = o.show[0];
			speed = o.show[1] || self.speed;
		}
		
		// set the scroll of the checkbox container
		$container.scrollTop(0).height(o.height);
		
		// position and show menu
		if( $.ui.position && !$.isEmptyObject(o.position) ){
			o.position.of = o.position.of || button;
			
			menu
				.show()
				.position( o.position )
				.hide()
				.show( effect, speed );
		
		// if position utility is not available...
		} else {
			menu.css({ 
				top: pos.top+button.outerHeight(),
				left: pos.left
			}).show( effect, speed );
		}
		
		// select the first option
		// triggering both mouseover and mouseover because 1.4.2+ has a bug where triggering mouseover
		// will actually trigger mouseenter.  the mouseenter trigger is there for when it's eventually fixed
		this.labels.eq(0).trigger('mouseover').trigger('mouseenter').find('input').trigger('focus');
		
		button.addClass('ui-state-active');
		this._isOpen = true;
		this._trigger('open');
	},
	
	// close the menu
	close: function(){
		if(this._trigger('beforeclose') === false){
			return;
		}
	
		var self = this, o = this.options, effect = o.hide, speed = this.speed;
		
		// figure out opening effects/speeds
		if( $.isArray(o.hide) ){
			effect = o.hide[0];
			speed = o.hide[1] || this.speed;
		}
	
		this.menu.hide(effect, speed);
		this.button.removeClass('ui-state-active').trigger('blur').trigger('mouseleave');
		this._trigger('close');
		this._isOpen = false;
	},

	enable: function(){
		this._toggleDisabled(false);
	},
	
	disable: function(){
		this._toggleDisabled(true);
	},
	
	checkAll: function(e){
		this._toggleChecked(true);
		this._trigger('checkAll');
	},
	
	uncheckAll: function(){
		this._toggleChecked(false);
		this._trigger('uncheckAll');
	},
	
	getChecked: function(){
		return this.menu.find('input').filter(':checked');
	},
	
	destroy: function(){
		// remove classes + data
		$.Widget.prototype.destroy.call( this );
		
		this.button.remove();
		this.menu.remove();
		this.element.show();
		
		return this;
	},
	
	isOpen: function(){
		return this._isOpen;
	},
	
	widget: function(){
		return this.menu;
	},
	
	// react to option changes after initialization
	_setOption: function( key, value ){
		var menu = this.menu;
		
		switch(key){
			case "header":
				menu.find('div.ui-multiselect-header')[ value ? 'show' : 'hide' ]();
				break;
			case "checkAllText":
				menu.find('a.ui-multiselect-all span').eq(-1).text(value);
				break;
			case "uncheckAllText":
				menu.find('a.ui-multiselect-none span').eq(-1).text(value);
				break;
			case "height":
				menu.find('ul:last').height( parseInt(value,10) );
				break;
			case "minWidth":
				this.options[ key ] = parseInt(value,10);
				this._setButtonWidth();
				this._setMenuWidth();
				break;
			case "selectedText":
			case "selectedList":
			case "noneSelectedText":
				this.options[key] = value; // these all needs to update immediately for the update() call
				this.update();
				break;
			case "classes":
				menu.add(this.button).removeClass(this.options.classes).addClass(value);
				break;
		}
		
		$.Widget.prototype._setOption.apply( this, arguments );
	}
});

})(jQuery);
