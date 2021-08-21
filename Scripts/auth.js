
const sign_in_btn = document.querySelector("#sign-in-btn");
const sign_up_btn = document.querySelector("#sign-up-btn");
const container = document.querySelector(".container");

sign_up_btn.addEventListener("click", () => {
    container.classList.add("sign-up-mode");
});

sign_in_btn.addEventListener("click", () => {
    container.classList.remove("sign-up-mode");
});
// vaild
var loading = $(".loader-container");
loading.hide();
var email_err = $(".eamil-err-msg");
var pass_err = $(".pass-err-msg");
var res_email_err = $(".email-res-err-msg");
var res_con_email_err = $(".con-email-res-err-msg");
var res_pass_err = $(".pass-res-err-msg");

$("#btnLogin").click(() => {
    var email = $("#loginEmail").val();
    var password = $("#loginPassword").val();
    checkEmail = vaildEmail(email);
    checkPass = vaildPass(password);
    if (email == "" || password == "") {
        if (email == "") {
            email_err.empty();
            email_err.append("Email không được để trống !");
        }
        if (password == "") {
            pass_err.empty();
            pass_err.append("Mật khẩu không được để trống !");
        }
    }
    else if (!checkEmail) {
        email_err.empty();
        email_err.append("Email không chính xác vui lòng nhập lại!");
    } else if (!checkPass) {
        email_err.empty();
        pass_err.append("Mật khẩu không thể ít hơn 6 ký tự!");
    }

    if (checkEmail && checkPass) {
        checkAjax(email, password, "Login");
    }
})
$("#btnRes").click(() => {
    
    var resEmail = $("#resEmail").val();
    var resConEmail = $("#resConEmail").val();
    var resPassword = $("#resPassword").val();
    var vaild = false;
    checkEmail = vaildEmail(resEmail);
    checkPass = vaildPass(resPassword);
    checkUsedEmail = getEmail(resEmail);
    if (resEmail == "" || resPassword == "" || resConEmail=="") {
        if (resEmail == "") {
            res_email_err.empty();
            res_email_err.append("Email không được để trống!");
        } else if (resPassword == "") {
            res_pass_err.empty();
            res_pass_err.append("Mật khẩu không được để trống!");
        } else {
            res_con_email_err.empty();
            res_con_email_err.append("Email xác nhận không được để trống!")
        }
    }
    if (!checkEmail) {
        res_email_err.empty();
        res_email.err.append("Định dạng email không đúng vui lòng nhập lại!")
    } else {
        if (resEmail != resConEmail) {
            res_con_email_err.empty();
            res_con_email_err.append("Email xác nhận không trùng với email gốc!")
        }
    }
    if (!checkPass) {
        res_pass_err.empty();
        res_pass_err.append("Mật khẩu không thể quá ngắn hoặc quá dài (6-18 ký tự)!")
    }
    //checkEmail
    if (checkUsedEmail) {
        res_email_err.empty();
        res_email_err.append("Email đã được sử dụng !");
    }
    if (checkEmail && checkPass && resEmail == resConEmail && !checkUsedEmail) {
        vaild = true;
        Res(resEmail, resPassword);
    }
})
function getEmail(email) {
    check = true;
    $.ajax({
        url: "getEmail",
        type: "POST",
        async: false,
        data: jQuery.param({ email_: email }),
        success: (data) => {
            if (data) {
                check = false;
                console.log(data)
            }
        }, error: () => {
            console.log("ajax faild")
        }
    })
    console.log(check);
    return check;
}
//dang ky
function Res(email, password) {
    $.ajax({
        url: "Regsiter",
        type: "POST",
        data: jQuery.param({ email_: email, pass_: password }),
        beforeSend: () => {
            loading.show();
        },
        success: (data) => {
            if (data) {
                setTimeout(() => {
                    loading.hide();
                }, 1000)
                setTimeout(() => {
                    container.classList.remove("sign-up-mode");
                }, 1200)
                console.log("Đăng Ký Thành Công!");

            } else {
                console.log("falid")
            }
        },
        error: () => {
            console.log("faild");
        }
    })
}
function checkAjax(email, password,par) {
    $.ajax({
        url: par,
        type: "POST",
        data: jQuery.param({ email_: email, pass_: password }),
        beforeSend: () => {
            loading.show();
        },
        success: (data) => {
            setTimeout(() => {
                if (data != false) {
                    link_ = "https://localhost:44352/";
                    window.location.assign(link_);
                    console.log(data)
                }
                if (!data) {
                    email_err.empty();
                    email_err.append("Tài khoản hoặc mật khẩu không chính xác!");
                }
                        
            }, 1100)
            setTimeout(() => {
                loading.hide()
            }, 1000)
        },
        error: () => {
            alert("get some err")
        }
    })
}

function vaildPass(pass) {
    if (pass.length > 6 && pass.length < 18) {
        return true;
    }
    return false;
}
function vaildEmail(email) {
    let res = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    return res.test(email);
}