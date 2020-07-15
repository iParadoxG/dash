var patt = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
var patt2 = /[0-9]{10}/;
var patt3 = /(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}/
var flag = 0
var flag2 = 0
var flag3 = 0
var flag4 = 0
function emailtest() {
    var mail = document.getElementById("emailll").value;
    var fname = document.getElementById("fname").value;
    var lname = document.getElementById("lname").value;
    var pwdj = document.getElementById("pwd").value;
    var pwd2j = document.getElementById("pwd2").value;
    var phone = document.getElementById("phone").value;
  if(patt.test(mail)) {
    flag = 1
  } else {
    alert("Please enter a valid email address")
    document.theForm.emailll.focus()
    flag = 0
  }
  if(patt2.test(phone)) {
    flag3 = 1
  } else {
    alert("Please enter a valid phone number")
    document.theForm.phone.focus()
    flag3 = 0  
  }
  if(patt3.test(pwdj)) {
    flag4 = 1
    if(pwd2j == pwdj) {
      flag2 = 1
    } else {
      alert("Passwords don't match")
      document.theForm.pwd.focus()
      flag2 = 0
    }
  } else {
    alert("Please enter a valid password")
    document.theForm.pwd.focus()
    flag4 = 0
  }
  if(flag==1 && flag2==1 && flag3==1 && flag4==1) {
    alert("Hello " + fname + " " + lname + "! Welcome to Somepage!") 
    document.theForm.submit();
  }

};

