function post(url,obj) {
    var d = $.Deferred();
    $.post(
        url,
        {
            json: JSON.stringify(obj)
        }
    ).done(function (s) {
        console.log(d);
        d.resolve(s.status);
    }).fail(d.reject);
    return d.promise();
}

function postWithParams(url, paramsObj) {
    var deferred = $.Deferred();
    var xhr = $.ajax({
        type: "POST",
        data: JSON.stringify(paramsObj),
        contentType: 'application/json; charset=utf-8',
        //headers: { 'Content-Type': 'application/json' },
        url: url,
        crossDomain: true,
        headers: { 'Access-Control-Allow-Origin': '*' },
        success: function (data) {
            deferred.resolve(data);
        },
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            //console.log(xmlHttpRequest.responseText);
            //console.log(textStatus);
            //console.log(errorThrown);
        }
    });
    return deferred.promise(xhr);
}