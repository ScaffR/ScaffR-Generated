/// <reference path="lib/jquery-ui/jquery-ui-1.8.24.js" />
    // draggable blocks //
    $( ".sortableContent .column" ).sortable({
            connectWith: ".sortableContent .column",
            items: "> .widget",
            handle: ".head",
            placeholder: "sortablePlaceholder",
            start: function(event,ui){
                $(".sortablePlaceholder").height(ui.item.height());
            },
            stop: function(event, ui){                                
                var sorted = '';
                $( ".sortableContent .column" ).each(function() {
                    sorted += $(this).index() + ': ';
                    $(this).find('.widget').each(function(){
                        sorted += '#'+$(this).attr('id')+', ';
                    });
                    sorted += ';<br/>';
                });                
            }
            
        }).disableSelection();    