function GetItemTextValue(_key, _action) {
    var result;
   
    result = $.ajax({ url: cachebaseURL +'/' + _action, data: { key: _key }, async: false }).responseText;
    return result;
   
}
