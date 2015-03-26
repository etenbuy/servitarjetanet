/*
Decimals V 1.0

Author: Jorge Santana Rojas

Usage:
simple:
$('#example').decimal();
Options:
dec (Int) -> number of decimals you want, default 2
$('#example').decimal({dec:5});
comma(Boolean) -> put commas on miles, default false
$('#example').decimal({comma:true});
*/
(function format($) {
    $.fn.setCursorPosition = function(pos) {
        this.each(function(index, elem) {
            if (elem.setSelectionRange) {
                elem.setSelectionRange(pos, pos);
            } else if (elem.createTextRange) {
                var range = elem.createTextRange();
                range.collapse(true);
                range.moveEnd('character', pos);
                range.moveStart('character', pos);
                range.select();
            }
        });
        return this;
    };

    $.fn.getCursorPosition = function() {
        var pos = 0;
        var input = $(this).get(0);
        // IE Support
        if (document.selection) {
            input.focus();
            var sel = document.selection.createRange();
            var selLen = document.selection.createRange().text.length;
            sel.moveStart('character', -input.value.length);
            pos = sel.text.length - selLen;
        }
        // Firefox support
        else if (input.selectionStart || input.selectionStart == '0')
            pos = input.selectionStart;

        return pos;
    }
    $.fn.decimal = function(optionals) {
        var evento = function(e) {
            var p = (e.type == "keydown" ? e.fromElement : e.toElement) || e.relatedTarget;
            while (p && p != this) { try { p = p.parentNode; } catch (e) { p = this; } }
            if (p == this) { return false; }

            var opts = { decimals: 2, comma: false };

            function put_comma(number) {

                if (number < 1000 || !opts.comma) {
                    return number;
                }
                else {
                    var num = number / 1000;
                    num = num.toString();
                    var parts = num.split('.');
                    return put_comma(parts[0].toString()).toString() + ',' + parts[1].toString();
                }
            }

            if (optionals) {
                if (optionals.dec) {
                    opts.decimals = optionals.dec;
                }
                if (optionals.comma) {
                    opts.comma = optionals.comma;
                }
            }
            var ob = this;

            var functionkeys = [9, 8, 13, 46, 37, 38, 39, 40, 45, 36, 33, 34, 35, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 144, 20, 16, 17, 91, 18, 17, 92, 93];

            switch (e.type) {
                case "keydown":

                    var value = $(this).val();

                    if (e.keyCode == 110 || e.keyCode == 190) {
                        if (value.indexOf('.') >= 0) {//1 dot in the number
                            e.preventDefault();
                        }
                    } else {
                        if (e.keyCode < 95) {
                            if (e.keyCode < 48 || e.keyCode > 57) {
                                if ($.inArray(e.keyCode, functionkeys) == -1) {
                                    e.preventDefault();
                                }
                            }
                        } else {
                            if (e.keyCode < 96 || e.keyCode > 105) {
                                if ($.inArray(e.keyCode, functionkeys) == -1) {
                                    e.preventDefault();
                                }
                            }
                        }
                    }
                    break;
                case "keyup":
                    var current = $(this).getCursorPosition();
                    var value = $(this).val();
                    var current_length = value.length;
                    while (value.indexOf(',') > 0) {
                        value = value.replace(',', '');
                    }

                    if (value.indexOf('.') >= 0) {//2 decimals					 
                        var parts = value.split('.');
                        if (parts[1].length > opts.decimals) {
                            if ($.inArray(e.keyCode, functionkeys) == -1) {
                                var temp_dec = parts[1].substr(0, (parts[1].length - 1));
                                $(this).val(put_comma(parts[0]) + '.' + temp_dec);
                            }
                        } else {
                            if ($.inArray(e.keyCode, functionkeys) == -1) {
                                $(this).val(put_comma(parts[0]) + '.' + parts[1]);
                            }
                        }
                    } else {
                        if ($.inArray(e.keyCode, functionkeys) == -1) {
                            $(this).val(put_comma(value));

                        }

                    }
                    var after_proc = $(this).val();
                    var after_length = after_proc.length - current_length;
                    $(this).setCursorPosition(current + after_length);

                    break;
                default:
                    break;
            }
        };
        return $(this).keydown(evento).keyup(evento);

    };
});
