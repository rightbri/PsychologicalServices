import {bindable, inject} from 'aurelia-framework';
//import {jquery} from 'jquery';

@inject(Element)
export class FixedHeaderCustomAttribute {
	@bindable offset = '[uk-navbar]';

	constructor(element) {
		this.element = element;
	}

	attached() {
		create(this.element, this.offset);
		//$(this.element).fixMe();
	}

	detached() {
		destroy(this.element);
		//$(this.element).fixMe('destroy');
	}
	
	offsetChanged(newValue, oldValue) {
		destroy(this.element);
		create(this.element, newValue);
	}
}

function create(element, offset) {
	let args = undefined;
	
	//if (offset) {
		let $offsetEl = $(offset);
		
		let positionTop = $offsetEl.position().top;
		let offsetTop = 0;//$offsetEl.offset().top;
		let outerHeight = $offsetEl.outerHeight(true);
		
		let offsetPx = positionTop + offsetTop + outerHeight;
		
		args = { 'offset': offsetPx };
	//}
	
	$(element).fixMe(args);
}

function destroy(element) {
	$(element).fixMe('destroy');
}

/*
//https://codepen.io/jgx/pen/wiIGc
;(function($, window, undefined) {
   $.fn.fixMe = function() {
	  return this.each(function() {
		 var $this = $(this),
			$t_fixed;
		 function init() {
			$this.wrap('<div class="container-fluid" />');
			$t_fixed = $this.clone();
			$t_fixed.find("tbody").remove().end().addClass("fixed").insertBefore($this);
			resizeFixed();
		 }
		 function resizeFixed() {
			$t_fixed.find("th").each(function(index) {
			   $(this).css("width",$this.find("th").eq(index).outerWidth()+"px");
			});
		 }
		 function scrollFixed() {
			var offset = $(this).scrollTop(),
			tableOffsetTop = $this.offset().top,
			tableOffsetBottom = tableOffsetTop + $this.height() - $this.find("thead").height();
			if(offset < tableOffsetTop || offset > tableOffsetBottom)
			   $t_fixed.hide();
			else if(offset >= tableOffsetTop && offset <= tableOffsetBottom && $t_fixed.is(":hidden"))
			   $t_fixed.show();
		 }
		 $(window).on('resize.fixed-header', resizeFixed);
		 $(window).on('scroll.fixed-header', scrollFixed);
		 init();
	  });
   };
})(jQuery, window, undefined);

$(document).ready(function(){
   $("table").fixMe();
   $(".up").click(function() {
	  $('html, body').animate({
	  scrollTop: 0
   }, 2000);
 });
});
*/


/**
 * A jQuery plugin boilerplate.
 * Author: Jonathan Nicol @f6design
 http://jonathannicol.com/blog/2012/05/06/a-jquery-plugin-boilerplate/
 */
;(function($) {  
  // Change this to your plugin name. 
  var pluginName = 'fixMe';
  
  /**
   * Plugin object constructor.
   * Implements the Revealing Module Pattern.
   */
  function Plugin(element, options) {
    // References to DOM and jQuery versions of element.
    var el = element;
    var $el = $(element);
	var $el_fixed = null;
	
    // Extend default options with those supplied by user.
    options = $.extend({}, $.fn[pluginName].defaults, options);

    /**
     * Initialize plugin.
     */
    function init() {
      // Add any initialization logic here...

		$el.each(function() {
			var el = this;
			var $el = $(this);
			
			$(window).on('resize.fixed-header', resizeFixed);
			$(window).on('scroll.fixed-header', scrollFixed);
			//$el.wrap('<div class="container-fluid" />');
			$el.wrap('<div/>');
			$el_fixed = $el.clone();
			let cssTop = 0;
			if (options.offset) {
				cssTop = options.offset + "px";
			}
			$el_fixed.find("tbody").remove().end().addClass("fixed").css("top",cssTop).insertBefore($el);
			
			setTimeout(function() {
				resizeFixed();
				scrollFixed();
			}, 0);
		});
	  
      hook('onInit');
    }
	
	 function resizeFixed() {
		$el_fixed.find("th").each(function(index) {
		   $(this).css("width",$el.find("th").eq(index).outerWidth()+"px");
		});
	 }
	function scrollFixed() {
		var offset = $(this).scrollTop(),
		tableOffsetTop = $el.offset().top,
		tableOffsetBottom = tableOffsetTop + $el.height() - $el.find("thead").height();
		if(offset < tableOffsetTop || offset > tableOffsetBottom)
		   $el_fixed.hide();
		else if(offset >= tableOffsetTop && offset <= tableOffsetBottom && $el_fixed.is(":hidden"))
		   $el_fixed.show();
	}
	
    /**
     * Example Public Method
     */
    function fooPublic() {
      // Code goes here...
    }

    /**
     * Get/set a plugin option.
     * Get usage: $('#el').demoplugin('option', 'key');
     * Set usage: $('#el').demoplugin('option', 'key', value);
     */
    function option (key, val) {
      if (val) {
        options[key] = val;
      } else {
        return options[key];
      }
    }

    /**
     * Destroy plugin.
     * Usage: $('#el').demoplugin('destroy');
     */
    function destroy() {
      // Iterate over each matching element.
      $el.each(function() {
        var el = this;
        var $el = $(this);

        // Add code to restore the element to its original state...
		$(window).off('resize.fixed-header', resizeFixed);
		$(window).off('scroll.fixed-header', scrollFixed);
		
		$el_fixed.unwrap();
		$el_fixed.remove();
		
		
        hook('onDestroy');
        // Remove Plugin instance from the element.
        $el.removeData('plugin_' + pluginName);
      });
    }

    /**
     * Callback hooks.
     * Usage: In the defaults object specify a callback function:
     * hookName: function() {}
     * Then somewhere in the plugin trigger the callback:
     * hook('hookName');
     */
    function hook(hookName) {
      if (options[hookName] !== undefined) {
        // Call the user defined function.
        // Scope is set to the jQuery element we are operating on.
        options[hookName].call(el);
      }
    }

    // Initialize the plugin instance.
    init();

    // Expose methods of Plugin we wish to be public.
    return {
      //option: option,
      destroy: destroy//,
      //fooPublic: fooPublic
    };
  }

  /**
   * Plugin definition.
   */
  $.fn[pluginName] = function(options) {
    // If the first parameter is a string, treat this as a call to
    // a public method.
    if (typeof arguments[0] === 'string') {
      var methodName = arguments[0];
      var args = Array.prototype.slice.call(arguments, 1);
      var returnVal;
      this.each(function() {
        // Check that the element has a plugin instance, and that
        // the requested public method exists.
        if ($.data(this, 'plugin_' + pluginName) && typeof $.data(this, 'plugin_' + pluginName)[methodName] === 'function') {
          // Call the method of the Plugin instance, and Pass it
          // the supplied arguments.
          returnVal = $.data(this, 'plugin_' + pluginName)[methodName].apply(this, args);
        } else {
          throw new Error('Method ' +  methodName + ' does not exist on jQuery.' + pluginName);
        }
      });
      if (returnVal !== undefined){
        // If the method returned a value, return the value.
        return returnVal;
      } else {
        // Otherwise, returning 'this' preserves chainability.
        return this;
      }
    // If the first parameter is an object (options), or was omitted,
    // instantiate a new instance of the plugin.
    } else if (typeof options === "object" || !options) {
      return this.each(function() {
        // Only allow the plugin to be instantiated once.
        if (!$.data(this, 'plugin_' + pluginName)) {
          // Pass options to Plugin constructor, and store Plugin
          // instance in the elements jQuery data object.
          $.data(this, 'plugin_' + pluginName, new Plugin(this, options));
        }
      });
    }
  };

  // Default plugin options.
  // Options can be overwritten when initializing plugin, by
  // passing an object literal, or after initialization:
  // $('#el').demoplugin('option', 'key', value);
  $.fn[pluginName].defaults = {
    onInit: function() {},
    onDestroy: function() {}
  };

})(jQuery);