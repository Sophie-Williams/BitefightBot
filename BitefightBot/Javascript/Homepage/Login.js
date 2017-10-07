var countySelection = document.getElementById('loginSrv');

countySelection.value = '##SELECTED_COUNTY##';

var usernameBox = $('#loginName');
usernameBox[0].value = '##USERNAME##';

var passwordBox = $('#loginPw');
passwordBox[0].value = '##USERPASS##';

var form = $('#loginForm').attr('action', '##FORM_COUNTY_ACTION_URL##');

$('#loginButton').click();