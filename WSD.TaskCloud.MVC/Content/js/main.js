function onCloseContentWND()
{
    $("#freezingBack").hide();
    $('#contentWNDDiv').html("");
}
function onOpenContentWND() {
    $("#freezingBack").show();
    $('#freezingBack').css('height', $(window).height());
}

function SelectedFile() {
    $("#imgDiv").html("");
}

function RemovedFile() {
    $("#imgDiv").html("<img src=\"/Content/img/no-avatar.jpg\" width=\"50\" style=\"padding-left:110px;\" />");
}
function showrightBottom(msg) {
    toastr.info(msg);
}
function taskAdd(msg) {
    toastr.warning(msg);
}