;
(function ($, window, document, undefined) {
    "use strict";
    var PluginName = "loadJson";
    /* Plugin Initialize
    ------------------------------------------------------------*/
    function Plugin(elem, options) {
        this.self = this;
        this.elem = elem;
        this.$elem = $(elem);
        this.metadata = this.$elem.data("options");
        this.options = $.extend({}, $.fn[PluginName].default, this.metadata, options);
        this.data = [];
        this.firstLoad = [];
    };
    /* Plugin Prototype
    ------------------------------------------------------------*/
    $.extend(Plugin.prototype, {
        inIt: function () {
            var self = this;
            //$('#fountainG').show();
          
            $.ajax({
                method: 'GET',
                url: self.options.url,
                dataType: 'json',
                beforeSend: function () {
                    $(self.options.loadBtn).attr('disabled', 'disable');
                    $(self.options.loadBtn).html("<i class='fa fa-spinner fa-spin'></i> Loading...");
                },
                complete: function () {
                    $(self.options.loadBtn).prop("disabled", false);
                    $(self.options.loadBtn).html("Load more ...");
                },
                success: function (d, msg) {
                    self.data.push(d);
                    if (self.data[0].length <= self.options.limit) {
                        self.Out();
                    } else {
                        self.More();
                      
                    }
                    self.firstLoad.push(self.data[0].splice(0, self.options.limit));
                    self.options.getData(self.elem, self.firstLoad[0]);
                },
                error: function (msg) {
                    alert(msg.statusText);
                }
            });
        },
        More: function () {
           
            var self = this;
            var i = 0;
            $(self.options.loadBtn).click(function() {

                $(self.options.loadBtn).button('loading');
                i += 1;
                if (self.data[0].length) {
                    self.firstLoad.push(self.data[0].splice(0, self.options.loadItem));
                    self.options.getData(self.elem, self.firstLoad[i]);
                }
                if (self.data[0].length == 0) {
                    self.Out();

                }
                setTimeout(function () {
                              $(self.options.loadBtn).button('reset');
                        }, 1000);
            });
        },
        Out: function () {
            var self = this;
            $(self.options.loadBtn).hide();
        }
    });
    /* Function Initialize
    ------------------------------------------------------------*/
    $.fn[PluginName] = function (options) {
        return this.each(function () {
            new Plugin(this, options).inIt();
        })
    };
    /* Plugin Default Options
    ------------------------------------------------------------*/
    $.fn[PluginName].default = {
        url: '',
        limit: 3,
        loadItem: 3,
        loadBtn: '#btn',
        getData: function (elem, data) {
            alert("Please create getData function, data available: " + data.length);
            return false;
        }
    };
}(jQuery, window, document));