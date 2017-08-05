var data = [];
var fisrtLoad = true;
(function () {
    
    $('.btn-loading-state').click(function () {
        var btn = $(this);
        btn.button('loading');
        setTimeout(function () {
            btn.button('reset');
        }, 1000);
    });
    
    $(window).scroll(function () {
        if (document.body.scrollTop == 0) {
            $(".mheader").css('box-shadow', 'none');

        } else {
            $(".mheader").css('box-shadow', '0 0.2px 0 0 rgba(0, 0, 0, 0.33)');

        }
    });
    $(document).on('click', '.section-header .dropdown-menu', function (e) {
        e.stopPropagation();
    });
   
    if (fisrtLoad) {
       
        var mid = $("#IdGroup").val();
        $('#listactivity').empty();
        $("#listactivity").loadJson({
            url: '/api/activityinfomation/getallbyactivitygroupid?id=' + mid + '',
            loadBtn: '#btn',
            limit: 12,
            loadItem: 12,
            beforeSend: function () {
                loadBtn.button('loading');
            },
            complete: function () {
                loadBtn.button('reset');
            },
            getData: function (elem, data) {
                $.each(data, function (index, value) {
                    var percent = 0;
                    if (value.Promotions.length > 0) {
                        percent = value.Promotions[value.Promotions.length - 1].Percent;
                    }
                    var item = '<div class="item">'
                                                   + '<div class="col-xs-12 col-sm-6 col-md-2">'
                                                   + ' <div class="card mitem ">'
                                                   + '<div class="card-body card-body-2">'
                                                   + '  <div class="image progressive">'
                                                   + '  <img class="progressive__img progressive--is-loaded" data-progressive="' + value['Image'] + '" src="' + value['Image'] + '" />'
                                                   + ' </div>'
                                                   + '  <div class="item-content">'
                                                   + '  <a class="item-name twoLineTitle" href="/Detail/' + value['Title'] + '-' + value['Id'] + '">'
                                                   + ' <h4>' + value['Title'] + '</h4>'
                                                   + ' </a>'
                                                   + ' <span class="price">' + percent + 'đ <span class="pull-right"><i class="fa fa-comment" aria-hidden="true">12</i></span></span>'
                                                   + '</div>'
                                                   + ' <div class="item-activity">'
                                                   + '<div class="rating">'
                                                   + ' <fieldset class="rating">'
                                                   + ' <input type="radio" id="star5" name="rating" value="5" /><label class="full" for="star5" title="Awesome - 5 stars"></label>'
                                                   + '<input type="radio" id="star4half" name="rating" value="4 and a half" /><label class="half" for="star4half" title="Pretty good - 4.5 stars"></label>'
                                                   + '<input type="radio" id="star4" name="rating" value="4" /><label class="full" for="star4" title="Pretty good - 4 stars"></label>'
                                                   + ' <input type="radio" id="star3half" name="rating" value="3 and a half" /><label class="half" for="star3half" title="Meh - 3.5 stars"></label>'
                                                   + '<input type="radio" id="star3" name="rating" value="3" /><label class="full" for="star3" title="Meh - 3 stars"></label>'
                                                   + '<input type="radio" id="star2half" name="rating" value="2 and a half" /><label class="half" for="star2half" title="Kinda bad - 2.5 stars"></label>'
                                                   + '<input type="radio" id="star2" name="rating" value="2" /><label class="full" for="star2" title="Kinda bad - 2 stars"></label>'
                                                   + ' <input type="radio" id="star1half" name="rating" value="1 and a half" /><label class="half" for="star1half" title="Meh - 1.5 stars"></label>'
                                                   + '<input type="radio" id="star1" name="rating" value="1" /><label class="full" for="star1" title="Sucks big time - 1 star"></label>'
                                                   + '<input type="radio" id="starhalf" name="rating" value="half" /><label class="half" for="starhalf" title="Sucks big time - 0.5 stars"></label>'
                                                   + ' </fieldset>'
                                                   + ' </div>'
                                                   + '  </div>'
                                                   + '  </div>'
                                                   + '  </div>'
                                                   + ' </div>';



                    $("#listactivity").append(item);
                });

            }
        });
    }
}());


function onchecking(el) {
    if (!$(el).is(":checked")) {
        data = data.filter(item => item !== $(el).val());
       
    }
    else data.push($(el).val());

    if (data.length == 0) {
        $("#amount").css("display","none");
        $("#amount").text("0");
    } else {
        $("#amount").css("display", "inline-block");
        $("#amount").text(data.length);
    }
}
function _fnApply() {
    fisrtLoad = false;
    $("#section").empty();
    $("#section").append('<div class="section-body" id="listactivity">'
                         +' </div>'
                         +'<div class="row">'
                         +' <div class="col-xs-4"></div>'
                         +'<div class="col-xs-4 text-center">'
                         +'<button type="button" id="btn" class="btn ink-reaction btn-flat btn-primary btn-loading-state" data-loading-text="<i class="fa fa-spinner fa-spin"></i>Loading...">Load more ...</button>'
                         +' </div>'
                         + '<div class="col-xs-4"></div>'
                         + '</div>'
                         ).ready(function () {
                            
                             var mid = $("#IdGroup").val();
                             var mData = data.join`,`;
                             if (data.length == 0) mData = "";
                           
                             //if (data.length > 0) {
                               
                                 $('#listactivity').empty();
                                 $("#listactivity").loadJson({
                                     url: '/api/activityinfomation/getallbymultilactivityid?id=' + mData + '&groupId=' + mid + '',
                                     loadBtn: '#btn',
                                     limit: 12,
                                     loadItem: 12,
                                     beforeSend: function () {
                                         loadBtn.button('loading');
                                     },
                                     complete: function () {
                                         loadBtn.button('reset');
                                     },
                                     getData: function (elem, data) {
                                        
                                         $.each(data, function (index, value) {
                                          var percent = 0;
                                         if (value.Promotions.length > 0) {
                                             percent = value.Promotions[value.Promotions.length - 1].Percent;
                                         }
                                             var item = '<div class="item">'
                                                 + '<div class="col-xs-12 col-sm-6 col-md-2">'
                                                 + ' <div class="card mitem ">'
                                                 + '<div class="card-body card-body-2">'
                                                 + '  <div class="image progressive">'
                                                 + '  <img class="progressive__img progressive--is-loaded" data-progressive="' + value['Image'] + '" src="' + value['Image'] + '" />'
                                                 + ' </div>'
                                                 + '  <div class="item-content">'
                                                 + '  <a class="item-name twoLineTitle" href="/Detail/' + value['Title'] + '-' + value['Id'] + '">'
                                                 + ' <h4>' + value['Title'] + '</h4>'
                                                 + ' </a>'
                                                 + ' <span class="price">'+percent+'đ <span class="pull-right"><i class="fa fa-comment" aria-hidden="true">12</i></span></span>'
                                                 + '</div>'
                                                 + ' <div class="item-activity">'
                                                 + '<div class="rating">'
                                                 + ' <fieldset class="rating">'
                                                 + ' <input type="radio" id="star5" name="rating" value="5" /><label class="full" for="star5" title="Awesome - 5 stars"></label>'
                                                 + '<input type="radio" id="star4half" name="rating" value="4 and a half" /><label class="half" for="star4half" title="Pretty good - 4.5 stars"></label>'
                                                 + '<input type="radio" id="star4" name="rating" value="4" /><label class="full" for="star4" title="Pretty good - 4 stars"></label>'
                                                 + ' <input type="radio" id="star3half" name="rating" value="3 and a half" /><label class="half" for="star3half" title="Meh - 3.5 stars"></label>'
                                                 + '<input type="radio" id="star3" name="rating" value="3" /><label class="full" for="star3" title="Meh - 3 stars"></label>'
                                                 + '<input type="radio" id="star2half" name="rating" value="2 and a half" /><label class="half" for="star2half" title="Kinda bad - 2.5 stars"></label>'
                                                 + '<input type="radio" id="star2" name="rating" value="2" /><label class="full" for="star2" title="Kinda bad - 2 stars"></label>'
                                                 + ' <input type="radio" id="star1half" name="rating" value="1 and a half" /><label class="half" for="star1half" title="Meh - 1.5 stars"></label>'
                                                 + '<input type="radio" id="star1" name="rating" value="1" /><label class="full" for="star1" title="Sucks big time - 1 star"></label>'
                                                 + '<input type="radio" id="starhalf" name="rating" value="half" /><label class="half" for="starhalf" title="Sucks big time - 0.5 stars"></label>'
                                                 + ' </fieldset>'
                                                 + ' </div>'
                                                 + '  </div>'
                                                 + '  </div>'
                                                 + '  </div>'
                                                 + ' </div>';



                                             $("#listactivity").append(item);
                                         });

                                     }
                                 });
                             //}

                         });;
    
    
}
