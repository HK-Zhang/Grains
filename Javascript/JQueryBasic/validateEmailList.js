function validateEmailList(emails) {
    var myRegExp = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
    var result = false;
    var emailList = emails.trim().split(';');
    for (var key in emailList) {
        if (emailList[key].trim().length == 0)
            continue;
        result = myRegExp.test(emailList[key]);
        if (result == false)
            return result;
    }
    return result;

}

console.log(validateEmailList(';He.ke.henry.zhang@dnvgl.com;  ,;He.ke.henry.zhang@dnvgl.com;He.ke.henry.zhang@dnvgl.com;He.ke.henry.zhang@dnvgl.com;'));
