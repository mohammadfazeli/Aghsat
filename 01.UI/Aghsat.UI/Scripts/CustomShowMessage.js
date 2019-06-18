function ShowMessage(message,Type) {
    switch (Type) {

    case "Exist":
        NotificationExist(message);
        break;
    case "Info":
        NotificationInfo(message);
        break;

    case "NotExist":
        NotificationNotExist(message);
        break;

    case "Error":
        NotificationError(message);
        break;

    case "Fail":
        NotificationWarning(message);
        break;

    case "Success":
        NotificationSuccess(message);
        break;
    default:
        NotificationDefault();
    }
}

//***********************************************
function NotificationExist(message) {
    if (message!='')
        toastr.warning(message, '');
    else
        toastr.warning('اطلاعات تکراری می باشد', 'توجه');
}


function NotificationNotExist(message) {
    if (message!='')
        toastr.warning(message, '');
    else
        toastr.warning('اطلاعات موجود نمی باشد', 'توجه');
}

function NotificationInfo(message) {
      toastr.info(message, '');
}

function NotificationError(message) {

    if (message!='')
        toastr.error(message, '');

    else
        toastr.error('مشکلی رخ داده است . مجددا اقدام فرمایید', 'خطا');

}

function NotificationWarning(message) {
    if (message!='')
        toastr.warning(message, '');
    else
        toastr.warning('اطلاعات صحیح نمی باشد', 'توجه');

}

function NotificationSuccess(message) {

    if (message!='')
        toastr.success(message, '');

    else
        toastr.success('عملیات با موفقیت انجام شد');

}

function NotificationDefault() {

    toastr.success('عملیات با موفقیت انجام شد');
}
