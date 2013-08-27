var urlRoot = urlRoot || '/';

(function ($) {

    $(function () {

        $('[data-click-outside-behavior]').bind('click', function (e) {
            if (e.target.nodeName != "A" && e.target.nodeName != "INPUT") {
                e.stopPropagation();
            }
        });

        $(document).delegate('html', 'click', function (e) {

            $('[data-click-outside-behavior=close]').each(function () {
                $(this).closest('[data-click-outside-container=true]').removeClass('open');
            });

        });
    });




    var init = function () {
        // normalize all select lists
        $('select').each(function () {
            $(this).find('option').each(function () {
                var a = $(this).attr('value');
                if (!a) {
                    $(this).attr('value', '');
                    $(this).removeAttr('selected');
                }
            });
        });

        // any dropdown listener
        $('[data-dropdownlistener]').each(function (idx, value) {

            var parent, callback;

            parent = $(this).attr('data-dropdownlistener-parent');
            callback = $(this).attr('data-dropdownlistener-callback');

            $('#' + parent).bind('change', function () {
                window[callback].apply(this, [parent]);
            });

        });

        $('[data-dropdownlistenerwithspecificvalue]').each(function (idx, value) {

            var parent, match, callback;

            parent = $(this).attr('data-dropdownlistenerwithspecificvalue-parent');
            match = $(this).attr('data-dropdownlistenerwithspecificvalue-match');
            callback = $(this).attr('data-dropdownlistenerwithspecificvalue-callback');

            $('#' + parent).bind('change', function () {
                if ($(this).val() == match) {
                    window[callback].apply(this, [parent, match]);
                }
            });
        });
        
        $('[data-enum]').each(function (idx, value) {

            var message, $this;

            message = $(this).data('message');
            $this = this;

            var factory = function (msg) {

                // here is where you decide
                var x;
                if ($this.tagName == 'DIV') {
                    x = picklist.call($this, msg);
                } else {
                    x = dropdown.call($this, msg);
                }

                return {
                    buildValueSet: function (list) {
                        return x.buildValueSet.call($this, list);
                    },
                    setEmpty: function () {
                        return x.setEmpty.call($this);
                    },
                    disable: function () {
                        return x.disable.call($this);
                    },
                    enable: function () {
                        return x.enable.call($this);
                    }
                };
            }(message);

        });

        // any cascading dropdown
        $('[data-cascading-parent]').each(function (idx, value) {

            var parentId, method, message, heirarchy, $parent, $this;

            parentId = $(this).data('cascading-parent');
            method = $(this).data('method');
            message = $(this).data('message');
            heirarchy = $(this).data('heirarchy');
            $this = this;
            $parent = $('[name="' + parentId + '"]');

            var factory = function (msg) {

                // here is where you decide if it's a picklist or select list
                var x;
                if ($this.tagName == 'DIV') {
                    x = picklist.call($this, msg);
                } else
                    x = dropdown.call($this, msg);

                return {
                    buildValueSet: function (list) {
                        return x.buildValueSet.call($this, list);
                    },
                    setEmpty: function () {
                        return x.setEmpty.call($this);
                    },
                    disable: function () {
                        return x.disable.call($this);
                    },
                    enable: function () {
                        return x.enable.call($this);
                    }
                };
            }(message);

            var getVal = function () {
                if (heirarchy == 'True') {

                    var data = [];

                    var parentData = function (p) {
                        data.push(p.val());
                        if (p.data('parent')) {
                            var q = $('#' + p.data('parent'));
                            parentData(q);
                        }
                    };
                    parentData($parent);
                    var a = data.reverse().join('|');
                    return a;
                } else {
                    return $parent.val();
                }
            };

            var reload = function () {
                factory.disable();
                $.ajax({
                    url: urlRoot + 'dropdown/getdropdownfor',
                    cache: true,
                    data: {
                        method: method,
                        parameter: getVal()
                    },
                    success: function (data) {
                        factory.buildValueSet(data);
                        factory.enable();
                        $(value).trigger('reloaded');

                    }
                });
            };

            $parent.bind('change', function () {

                // parent is not selected (or empty.. which should never happen)
                if (!$parent.val() || $parent.val() == "~")
                    factory.setEmpty();
                else
                    reload();
            });

            // child of a cascading dropdown..
            $parent.bind('reloaded', function () {
                factory.setEmpty();
            });

            if (!$parent.val()) {
                if (parentId !== "SelectedWidgetId")
                    factory.setEmpty();
            }
        });

        $('.picklist-header').bind('click', function (e) {

            $(this).backgroundColor = '';
            e.stopPropagation();
            if ($(this).siblings().children('.picklist-inner').attr('enabled') == "enabled")
                $(this).closest('[data-dropdown=picklist]').toggleClass('open');
        });

    };

   
    // cascading dropdown control
    var dropdown = function (msg) {

        return {
            buildValueSet: function (list) {
                $(this).empty();
                var html = "";
                if (list.length == 0)
                    html = '<option value="">' + msg + '</option>';
                if (!$(this).find('[data-multiselect]').context.multiple)
                    $(this).append(html);
                $(this).removeAttr('disabled');
                for (var i = 0; i < list.length; i++) {
                    if (list[i].Value) {
                        html = '<option value=' + list[i].Value + '>' + list[i].Text + '</option>';
                        $(this).append(html);
                    }
                }
            },
            setEmpty: function () {
                $(this).empty();
                $(this).append('<option value="">' + msg + '</option>');
                $(this).attr('disabled', 'disabled');
                $(this).trigger('reloaded');
            },
            disable: function() {
                $(this).prop("disabled", true);
            },
            enable: function() {
                $(this).removeProp("disabled");
            }
        };
    };

    // picklist control
    var picklist = function (msg) {

        var $selectall = $(this).find('[data-dropdown-selectall]');
        var $filter = $(this).find('[data-dropdown-filter]');
        var $inner = $(this).find('.picklist-inner');
        var propertyName = $(this).attr('data-dropdown-property');
        var friendlyName = $(this).attr('data-dropdown-friendlyname');
        var $name = $(this).find('.picklist-header span');
        var pageHeight = $(window).height(); //Catch the height of page

        $inner.css("overflow", "auto");//Define a scrollbar
        $inner.css("max-height", pageHeight / 3 + "px"); //Define the height for the picklist

        $selectall.bind('click', function(e) {

            var checked = $selectall.is(':checked');

            $inner.children().each(function(i, v) {
                var chk = $(this).find('input');

                if (i > 0) {
                    if (checked) {
                        chk.attr('checked', checked);
                    } else {
                        chk.removeAttr('checked');
                    }
                }
            });
        });

        $inner.find('input').on('click', function(e) {
            var numero = 0;
            var allChecked = true;
            e.stopPropagation();
            $inner.children().each(function(i) {
                if (i > 0) {
                    if ($(this).find('input').is(':checked'))
                        numero += 1;
                    else
                        allChecked = false;
                }
            });

            if (numero > 0)
                $name.text(friendlyName + ' (' + numero + ' selected)');
            else
                $name.text("Select " + friendlyName);

            if (allChecked)
                $selectall.attr('checked', true);
            else
                $selectall.removeAttr('checked');
        });

        $filter.bind('click', function(e) {
            e.stopPropagation();
        });

        $filter.bind('keyup', function(e) {

            var val = $filter.val().toLowerCase();

            $inner.children().each(function(i, v) {
                if (i > 0) {
                    var txt = $(this).text().toLowerCase();
                    if (txt.indexOf(val) == -1)
                        $(this).hide();
                    else
                        $(this).show();
                }
            });
        });

        var enable = function () {
            $inner.attr('enabled', 'enabled');
        };

        enable();

        return {
            buildValueSet: function (list) {
                var first = $inner.children().first().detach();

                $inner.empty().append(first);

                $name.text("Select " + friendlyName);

                for (var i = 0; i < list.length; i++) {
                    var checked = $selectall.is(':checked');
                    var html = $('<div><input name="' + propertyName + '" type="checkbox" value="' + list[i].Value + '">' + list[i].Text + '</input></div>');

                    var chk = html.find('input');

                    if (checked) {
                        chk.attr('disabled', 'disabled');
                        chk.attr('checked', true);
                    } else {
                        chk.removeAttr('disabled');
                    }

                    $inner.append(html);
                }

            },
            setEmpty: function () {
                var first = $inner.children().first().detach();
                $inner.empty().append(first);
            },
            disable: function () {
                $inner.removeAttr('enabled');
            },
            enable: function () {
                enable();
            }
        };
    };

    $(document).ready(init);

})(jQuery);