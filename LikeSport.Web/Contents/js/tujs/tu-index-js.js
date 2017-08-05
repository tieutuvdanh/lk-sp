// js index

//function UserViewModel() {
//    var self = this;
//    self.ListActivityGroup = ko.observableArray([]);

//    //$("#sbd").loadJson({
//    //    url: '/api/activitygroup/getall',
//    //    loadBtn: '#btn',
//    //    getData: function (elem, data) {

//       $("#sbd").loadJson({
//            url: '/api/activitygroup/getall',
//                loadBtn: '#btn',
//                getData: function (elem, data) {
//                    var l = self.ListActivityGroup($.map(data, function (item) {
//                        //$(elem).append(new ActivityGroupModel(item));
//                        return new ActivityGroupModel(item);
//                    }));
//                    //alert(l)
//                    $(elem).append("kk");
//                }


//        });



//    //self.GetActivityGroup();
//}
//function ActivityGroupModel(data) {
//    var self = this;
//    self.Name = ko.observable(data.ActivityGroupName);
//    //self.UserName = ko.observable(data.username);
//}
var data = [];
var fisrtLoad = true;
(function () {
    // get all group and load activityfrom group

    //ko.applyBindings(new UserViewModel());

    //  $('.btn-loading-state').click(function () {
    //    var btn = $(this);
    //    btn.button('loading');
    //    setTimeout(function () {
    //        btn.button('reset');
    //    }, 3000);
    //});

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
    $("#sbd").loadJson({
        url: '/api/activitygroup/getall',
        loadBtn: '#btn',
        beforeSend: function () {
            loadBtn.button('loading');

        },

        complete: function () {
            loadBtn.button('reset');
        },
        getData: function (elem, data) {
            $.each(data, function (index, value) {

                var el = value['ActivityGroupName'].trim().replace(/ /g, "-");
                //var str = "";
                //$.ajax({
                //    url: '/Home/ReName?str=' + value['ActivityGroupName'] + '',
                //}).done(function (data) {
                //    str = data;
                //});



                $.ajax({
                    url: '/api/activityinfomation/getallbyactivitygroupid?id=' + value['Id'] + '',
                    type: 'GET',
                    success: function (data) {
                        if (data.length != 0) {
                            $(elem).append('<div class="row">'
                               + '<div class="col-md-12 title-column">'
                               + '<span class="text-lg text-bold text-primary">' + value['ActivityGroupName'] + '</span>'
                               + '<a class="pull-right" href="/View-all-activity/' + el + '-' + value['Id'] + '">See all <i class="fa fa-chevron-right" aria-hidden="true"></i></a>'
                               + '</div>'
                               + '</div>'
                               + '<div class="col-md-12">'
                               + '<div class="carousel carousel-showmanymoveone slide new" data-ride="carousel" data-type="multi" data-interval="3000" id="' + el + '">'
                               + '<div class="carousel-inner ' + el + '">'
                               + '</div>'
                               + '<a class="left carousel-control" href="#' + el + '" data-slide="prev"><i class="glyphicon glyphicon-chevron-left"></i></a>'
                               + '<a class="right carousel-control" href="#' + el + '" data-slide="next"><i class="glyphicon glyphicon-chevron-right"></i></a>'
                               + '</div>'
                               + '</div>');
                            $.each(data, function (index2, value2) {
                                var percent = 0;
                                if (value2.Promotions.length > 0) {
                                    percent = value2.Promotions[value2.Promotions.length - 1].Percent;
                                }


                                if (index2 === 0) {
                                    $("." + el).append('<div class="item active">'
                                        + '<div class="col-xs-12 col-sm-6 col-md-2">'
                                        + ' <div class="card mitem ">'
                                        + '<div class="card-body card-body-2">'
                                        + '<div class="image progressive">'
                                        + '<img class="progressive__img progressive--not-loaded" data-progressive="' + value2['Image'] + '" src="' + value2['Image'] + '" />'
                                        + '</div>'
                                        + '<div class="item-content">'
                                        + '<a class="item-name twoLineTitle" href="/Detail/' + value2['Title'] + '-' + value2['Id'] + '">'
                                        + '<h4>' + value2['Title'] + '</h4>'
                                        + '</a>'
                                        + '<span class="price">' + percent + '<span class="pull-right"><i class="fa fa-comment" aria-hidden="true">12</i></span></span>'
                                        + '</div>'
                                        + '<div class="item-activity">'
                                        + '<div class="rating">'
                                        + '<fieldset class="rating">'
                                        + '<input type="radio" id="star5" name="rating" value="5" /><label class="full" for="star5" title="Awesome - 5 stars"></label>'
                                        + '<input type="radio" id="star4half" name="rating" value="4 and a half" /><label class="half" for="star4half" title="Pretty good - 4.5 stars"></label>'
                                        + '<input type="radio" id="star4" name="rating" value="4" /><label class="full" for="star4" title="Pretty good - 4 stars"></label>'
                                        + '<input type="radio" id="star3half" name="rating" value="3 and a half" /><label class="half" for="star3half" title="Meh - 3.5 stars"></label>'
                                        + '<input type="radio" id="star3" name="rating" value="3" /><label class="full" for="star3" title="Meh - 3 stars"></label>'
                                        + '<input type="radio" id="star2half" name="rating" value="2 and a half" /><label class="half" for="star2half" title="Kinda bad - 2.5 stars"></label>'
                                        + '<input type="radio" id="star2" name="rating" value="2" /><label class="full" for="star2" title="Kinda bad - 2 stars"></label>'
                                        + '<input type="radio" id="star1half" name="rating" value="1 and a half" /><label class="half" for="star1half" title="Meh - 1.5 stars"></label>'
                                        + '<input type="radio" id="star1" name="rating" value="1" /><label class="full" for="star1" title="Sucks big time - 1 star"></label>'
                                        + '<input type="radio" id="starhalf" name="rating" value="half" /><label class="half" for="starhalf" title="Sucks big time - 0.5 stars"></label>'
                                        + ' </fieldset>'
                                        + ' </div>'
                                        + '  </div>'
                                        + '  </div>'
                                        + '  </div>'
                                        + ' </div>'
                                        + ' </div>');
                                } else {
                                    $("." + el).append(
                                         '<div class="item">'
                                         + '<div class="col-xs-12 col-sm-6 col-md-2">'
                                         + ' <div class="card mitem ">'
                                         + '<div class="card-body card-body-2">'
                                         + '  <div class="image progressive">'
                                         + '  <img class="progressive__img progressive--not-loaded" data-progressive="' + value2['Image'] + '" src="' + value2['Image'] + '" />'
                                         + ' </div>'
                                         + '  <div class="item-content">'
                                        + '<a class="item-name twoLineTitle" href="/Detail/' + value2['Title'] + '-' + value2['Id'] + '">'
                                        + '<h4>' + value2['Title'] + '</h4>'
                                         + ' </a>'
                                          + '<span class="price">' + percent + '<span class="pull-right"><i class="fa fa-comment" aria-hidden="true">12</i></span></span>'
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
                                         + ' </div>'
                                         + ' </div>');

                                }

                            });
                            ReLoad();
                        }

                    },
                    error: function (data) {

                    }

                });


            });
            ReLoad();
        }
    });

}());
function ReLoad() {

    $('.carousel').carousel({
        wrap: false,
        interval: false
    }).on('slid.bs.carousel', function (ev) {

        //progressively.render();

    });
    $('.carousel[data-type="multi"].new  .item').each(function () {

        var next = $(this).next();
        if (!next.length) {
            next = $(this).siblings(':first');

        }
        next.children(':first-child').clone().appendTo($(this));

        for (var i = 0; i < 4; i++) {
            next = next.next();
            if (!next.length) {
                next = $(this).siblings(':first');
            }

            next.children(':first-child').clone().appendTo($(this));
            var el = $(this).find("img");
            $(this).find("img").removeClass('progressive--not-loaded');
            $(this).find("img").addClass('progressive--is-loaded');

            if (el.attr('class').indexOf('progressive__bg') > -1) {
                // Load image as css-background-image
                el.style['background-image'] = 'url("' + this.src + '")';
            } else {
                el.src = this.src;
            }
        }
        $(".new").removeClass("new");
    });
}

function onchecking(el) {
    if (!$(el).is(":checked")) {
        data = data.filter(item => item !== $(el).val());

    }
    else data.push($(el).val());

    if (data.length == 0) {
        $("#amount").css("display", "none");
        $("#amount").text("0");
    } else {
        $("#amount").css("display", "inline-block");
        $("#amount").text(data.length);
    }
}

function _fnApply() {
    var mData = data.join`,`;
    if (data.length == 0) mData = "";
    $("#section").empty();
    $("#section").append('<div class="section-body" id="sbd">'
                         + ' </div>'
                         + '<div class="row">'
                         + ' <div class="col-xs-4"></div>'
                         + '<div class="col-xs-4 text-center">'
                         + '<button type="button" id="btn" class="btn ink-reaction btn-flat btn-primary btn-loading-state" data-loading-text="<i class="fa fa-spinner fa-spin"></i>Loading...">Load more ...</button>'
                         + ' </div>'
                         + '<div class="col-xs-4"></div>'
                         + '</div>'
                         ).ready(function () {


                             $("#sbd").loadJson({
                                 url: '/api/activitygroup/getallbymulti?id=' + mData + '',
                                 loadBtn: '#btn',
                                 beforeSend: function () {
                                     loadBtn.button('loading');

                                 },

                                 complete: function () {
                                     loadBtn.button('reset');
                                 },
                                 getData: function (elem, data) {
                                     $.each(data, function (index, value) {

                                         var el = value['ActivityGroupName'].trim().replace(/ /g, "-");
                                         $.ajax({
                                             url: '/api/activityinfomation/getallbyactivitygroupid?id=' + value['Id'] + '',
                                             type: 'GET',
                                             success: function (data) {
                                                 if (data.length != 0) {
                                                     $(elem).append('<div class="row">'
                                                        + '<div class="col-md-12 title-column">'
                                                        + '<span class="text-lg text-bold text-primary">' + value['ActivityGroupName'] + '</span>'
                                                        + '<a class="pull-right" href="/View-all-activity/' + el + '-' + value['Id'] + '">See all <i class="fa fa-chevron-right" aria-hidden="true"></i></a>'
                                                        + '</div>'
                                                        + '</div>'
                                                        + '<div class="col-md-12">'
                                                        + '<div class="carousel carousel-showmanymoveone slide new" data-ride="carousel" data-type="multi" data-interval="3000" id="' + el + '">'
                                                        + '<div class="carousel-inner ' + el + '">'
                                                        + '</div>'
                                                        + '<a class="left carousel-control" href="#' + el + '" data-slide="prev"><i class="glyphicon glyphicon-chevron-left"></i></a>'
                                                        + '<a class="right carousel-control" href="#' + el + '" data-slide="next"><i class="glyphicon glyphicon-chevron-right"></i></a>'
                                                        + '</div>'
                                                        + '</div>');
                                                     $.each(data, function (index2, value2) {
                                                         var percent = 0;
                                                         if (value2.Promotions.length > 0) {
                                                             percent = value2.Promotions[value2.Promotions.length - 1].Percent;
                                                         }


                                                         if (index2 === 0) {
                                                             $("." + el).append('<div class="item active">'
                                                                 + '<div class="col-xs-12 col-sm-6 col-md-2">'
                                                                 + ' <div class="card mitem ">'
                                                                 + '<div class="card-body card-body-2">'
                                                                 + '<div class="image progressive">'
                                                                 + '<img class="progressive__img progressive--not-loaded" data-progressive="' + value2['Image'] + '" src="' + value2['Image'] + '" />'
                                                                 + '</div>'
                                                                 + '<div class="item-content">'
                                                                 + '<a class="item-name twoLineTitle" href="/Detail/' + value2['Title'] + '-' + value2['Id'] + '">'
                                                                 + '<h4>' + value2['Title'] + '</h4>'
                                                                 + '</a>'
                                                                 + '<span class="price">' + percent + '<span class="pull-right"><i class="fa fa-comment" aria-hidden="true">12</i></span></span>'
                                                                 + '</div>'
                                                                 + '<div class="item-activity">'
                                                                 + '<div class="rating">'
                                                                 + '<fieldset class="rating">'
                                                                 + '<input type="radio" id="star5" name="rating" value="5" /><label class="full" for="star5" title="Awesome - 5 stars"></label>'
                                                                 + '<input type="radio" id="star4half" name="rating" value="4 and a half" /><label class="half" for="star4half" title="Pretty good - 4.5 stars"></label>'
                                                                 + '<input type="radio" id="star4" name="rating" value="4" /><label class="full" for="star4" title="Pretty good - 4 stars"></label>'
                                                                 + '<input type="radio" id="star3half" name="rating" value="3 and a half" /><label class="half" for="star3half" title="Meh - 3.5 stars"></label>'
                                                                 + '<input type="radio" id="star3" name="rating" value="3" /><label class="full" for="star3" title="Meh - 3 stars"></label>'
                                                                 + '<input type="radio" id="star2half" name="rating" value="2 and a half" /><label class="half" for="star2half" title="Kinda bad - 2.5 stars"></label>'
                                                                 + '<input type="radio" id="star2" name="rating" value="2" /><label class="full" for="star2" title="Kinda bad - 2 stars"></label>'
                                                                 + '<input type="radio" id="star1half" name="rating" value="1 and a half" /><label class="half" for="star1half" title="Meh - 1.5 stars"></label>'
                                                                 + '<input type="radio" id="star1" name="rating" value="1" /><label class="full" for="star1" title="Sucks big time - 1 star"></label>'
                                                                 + '<input type="radio" id="starhalf" name="rating" value="half" /><label class="half" for="starhalf" title="Sucks big time - 0.5 stars"></label>'
                                                                 + ' </fieldset>'
                                                                 + ' </div>'
                                                                 + '  </div>'
                                                                 + '  </div>'
                                                                 + '  </div>'
                                                                 + ' </div>'
                                                                 + ' </div>');
                                                         } else {
                                                             $("." + el).append(
                                                                  '<div class="item">'
                                                                  + '<div class="col-xs-12 col-sm-6 col-md-2">'
                                                                  + ' <div class="card mitem ">'
                                                                  + '<div class="card-body card-body-2">'
                                                                  + '  <div class="image progressive">'
                                                                  + '  <img class="progressive__img progressive--not-loaded" data-progressive="' + value2['Image'] + '" src="' + value2['Image'] + '" />'
                                                                  + ' </div>'
                                                                  + '  <div class="item-content">'
                                                                 + '<a class="item-name twoLineTitle" href="/Detail/' + value2['Title'] + '-' + value2['Id'] + '">'
                                                                 + '<h4>' + value2['Title'] + '</h4>'
                                                                  + ' </a>'
                                                                   + '<span class="price">' + percent + '<span class="pull-right"><i class="fa fa-comment" aria-hidden="true">12</i></span></span>'
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
                                                                  + ' </div>'
                                                                  + ' </div>');

                                                         }

                                                     });
                                                     ReLoad();
                                                 }

                                             },
                                             error: function (data) {

                                             }

                                         });


                                     });
                                     ReLoad();
                                 }
                             });

                         });;


}
