const { report } = require("node:process");

var coll = document.getElementsByClassName("collapsible");
var i;

for (i = 0; i < coll.length; i++) {
    coll[i].addEventListener("click", function () {
        this.classList.toggle("active");
        var content = this.nextElementSibling;
        if (content.style.display === "block") {
            content.style.display = "none";
        } else {
            content.style.display = "block";
        }
    });
}

function myFunction() {
    var x = document.getElementById("myDIV");
    if (x.style.display === "none") {
        x.style.display = "block";
    } else {
        x.style.display = "none";
    }
}

function myFunction2() {
    var x = document.getElementById("myDIV2");
    if (x.style.display === "none") {
        x.style.display = "block";
    } else {
        x.style.display = "none";
    }
}



function formatState(opt) {
    if (!opt.id) {
        return opt.text.toUpperCase();
    }
    var optimage = jQuery(opt.element).attr('data-image');
    if (!optimage) {
        return opt.text.toUpperCase();
    } else {
        var $opt = jQuery(
            '<span><img src="' + optimage + '"/></span>'
        );
        return $opt;
    }
};

function formatStateDropdown(opt) {
    if (!opt.id) {
        return opt.text.toUpperCase();
    }
    var optimage = jQuery(opt.element).attr('data-image');
    if (!optimage) {
        return opt.text.toUpperCase();
    } else {
        var $opt = jQuery(
            '<span><img src="' + optimage + '" /> ' + opt.text + '</span>'
        );
        return $opt;
    }
};

// equal height

function equalHeight() {
    jQuery.fn.extend({
        equalHeight: function () {
            var top = 0;
            var row = [];
            var classname = ('equalHeight' + Math.random()).replace('.', '');
            jQuery(this).each(function () {
                var thistop = jQuery(this).offset().top;
                if (thistop > top) {
                    jQuery('.' + classname).removeClass(classname);
                    top = thistop;
                }
                jQuery(this).addClass(classname);
                jQuery(this).height('auto');
                var h = (Math.max.apply(null, jQuery('.' + classname).map(function () {
                    return jQuery(this).outerHeight();
                }).get()));
                jQuery('.' + classname).height(h);
            }).removeClass(classname);
        }
    });
    jQuery('.why-helperhand .helperhand-wrapper h3').equalHeight();

}
function fixed_header() {
    if (jQuery(window).scrollTop() > 0) {
        jQuery('header').addClass('fixed');
    }
    else {
        jQuery('header').removeClass('fixed');
    }
}
jQuery(document).ready(function () {
    equalHeight();
    fixed_header();
    jQuery('.custom-dropdown').each(function () {
        var _this = jQuery(this);
        jQuery(this).find("select").select2({
            templateResult: formatStateDropdown,
            templateSelection: formatState,
            dropdownParent: _this,
            minimumResultsForSearch: Infinity,


        });
    });
    jQuery('.scroll-link').click(function (e) {
        e.preventDefault();
        jQuery('html,body').animate({
            scrollTop: jQuery('.scroll-section').offset().top - jQuery('.site-header').outerHeight()
        }, 1000);
    });
    jQuery('.scroll-top').click(function (e) {
        e.preventDefault();
        jQuery('html,body').animate({
            scrollTop: 0
        }, 1000);
    });
    jQuery('.ok-btn').click(function (e) {
        e.preventDefault();
        var _this = jQuery(this);
        _this.closest('.footer-bottom').slideUp();

    })


});
jQuery(window).resize(function () {
    equalHeight();
});
jQuery(window).on('load', function () {
    setTimeout(function () {
        equalHeight();
    }, 500)
});
jQuery(window).scroll(function () {
    fixed_header();
});

function myFunctionnav() {
    var x = document.getElementById("myTopnav");
    if (x.className === "topnav") {
        x.className += " responsive";
    } else {
        x.className = "topnav";
    }
}

function myFunctionnav2() {
    var x = document.getElementById("myTopnav2");
    if (x.className === "topnav2") {
        x.className += " responsive";
    } else {
        x.className = "topnav2";
    }
}

function Tab1Click() {
    $("#tab1").addClass("active-tab");
    $("#tab2").removeClass("active-tab");
    $("#tab3").removeClass("active-tab");
    $("#tab4").removeClass("active-tab");


    $('#tabContent1').removeClass("fornonedisplay").addClass("fordisplay");
    $('#tabContent2').removeClass("fordisplay").addClass("fornonedisplay");
    $('#tabContent3').removeClass("fordisplay").addClass("fornonedisplay");
    $('#tabContent4').removeClass("fordisplay").addClass("fornonedisplay");
}

function Tab2Click() {
    $("#tab2").addClass("active-tab");
    $("#tab1").removeClass("active-tab");
    $("#tab3").removeClass("active-tab");
    $("#tab4").removeClass("active-tab");

    $('#tabContent2').removeClass("fornonedisplay").addClass("fordisplay");
    $('#tabContent1').removeClass("fordisplay").addClass("fornonedisplay");
    $('#tabContent3').removeClass("fordisplay").addClass("fornonedisplay");
    $('#tabContent4').removeClass("fordisplay").addClass("fornonedisplay");

}

function Tab3Click() {
    $("#tab3").addClass("active-tab");
    $("#tab2").removeClass("active-tab");
    $("#tab1").removeClass("active-tab");
    $("#tab4").removeClass("active-tab");

    $('#tabContent3').removeClass("fornonedisplay").addClass("fordisplay");
    $('#tabContent2').removeClass("fordisplay").addClass("fornonedisplay");
    $('#tabContent1').removeClass("fordisplay").addClass("fornonedisplay");
    $('#tabContent4').removeClass("fordisplay").addClass("fornonedisplay");
    $('#tabContent3').html("Loding Address")
        .load("/BookService/GetAddress");
}

function Tab4Click() {
    $("#tab4").addClass("active-tab");
    $("#tab2").removeClass("active-tab");
    $("#tab3").removeClass("active-tab");
    $("#tab1").removeClass("active-tab");

    $('#tabContent4').removeClass("fornonedisplay").addClass("fordisplay");
    $('#tabContent2').removeClass("fordisplay").addClass("fornonedisplay");
    $('#tabContent3').removeClass("fordisplay").addClass("fornonedisplay");
    $('#tabContent1').removeClass("fordisplay").addClass("fornonedisplay");

}

function addAddress() {
    $("#test").removeClass("fornonedisplay").addClass("fordisplay");
    $("#addnewadd").addClass("fornonedisplay").addClass("addnewaddtab");
}


function Tab2CustClick() {
    $("#tab2").addClass("active-tab");
    $("#tab1").removeClass("active-tab");
    $("#tab3").removeClass("active-tab");

    $('#tabContent2').removeClass("fornonedisplay").addClass("fordisplay");
    $('#tabContent1').removeClass("fordisplay").addClass("fornonedisplay");
    $('#tabContent3').removeClass("fordisplay").addClass("fornonedisplay");
    $('#tabContent2').html("Loding Address")
        .load("/Customer/GetAddressCust");

}

function Tab3CustClick() {
    $("#tab3").addClass("active-tab");
    $("#tab2").removeClass("active-tab");
    $("#tab1").removeClass("active-tab");

    $('#tabContent3').removeClass("fornonedisplay").addClass("fordisplay");
    $('#tabContent2').removeClass("fordisplay").addClass("fornonedisplay");
    $('#tabContent1').removeClass("fordisplay").addClass("fornonedisplay");
    $('#tabContent3').html("Loding")
        .load("/Customer/ChangePassword");
}

