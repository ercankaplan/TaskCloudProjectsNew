
function getParameterValue(_key, _action) {
    var result;
    //tarifeAdi = $.ajax({ url: '@Url.Action("GetTaliTarife", "CacheEnum")', data: { key: tarifeID }, async: false }).responseText;
    result = $.ajax({ url: baseCacheEnumURL + '/'+_action , data: { key: _key }, async: false }).responseText;
    return result;
    //debugger;
    //$(this).load('@Url.Action("GetTaliTarife", "CacheEnum")', 'key=' + tarifeID);
    /*$('#testDiv').load('@Url.Action("GetTaliTarife", "CacheEnum")', 'key=' + tarifeID);*/
    /*$.get('@Url.Action("GetTaliTarife", "CacheEnum")', 'key=' + tarifeID, function (data) {
        alert(data);
        tarifeAdi = data;
    });
    //alert(tarifeAdi);
    return tarifeAdi; */
}
