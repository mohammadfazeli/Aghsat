$(document).ready(function () {
   // $('#dtCategory').dataTable({
   $('table.data-Table').dataTable({
        retrieve: true,
        dom: 'Bfrtip',
        buttons: [
            'copy', 'csv', 'excel', 'print'
        ],

        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Persian.json"
        }
    });
});

function ShowModal() {
    UIkit.modal("#modal-sections").show();
}
function Hide() {
    UIkit.modal("#modal-sections").hide();
}




//$('#date2').MdPersianDateTimePicker({
//    targetTextSelector: '#inputDate2',
//    selectedDate: new Date('2018/9/30'),
//    isGregorian: true,

//});

//$('#date3').MdPersianDateTimePicker({
//    targetTextSelector: '#inputDate3',
//    monthsToShow: [1, 1],
//});
//$('#date3-1').MdPersianDateTimePicker({
//    targetTextSelector: '#inputDate3-1',
//    monthsToShow: [1, 1],
//    rangeSelector: true
//});

//$('#date4').MdPersianDateTimePicker({
//    targetTextSelector: '#inputDate4',
//    fromDate: true,
//    groupId: 'rangeSelector1'
//});
//$('#date5').MdPersianDateTimePicker({
//    targetTextSelector: '#inputDate5',
//    toDate: true,
//    groupId: 'rangeSelector1',
//    placement: 'top'
//});
//$('#date6').MdPersianDateTimePicker({
//    targetTextSelector: '#inputDate6',
//    targetDateSelector: '#inputDate7',
//    inLine: true,
//    rangeSelector: false,
//    enableTimePicker: true
//});
