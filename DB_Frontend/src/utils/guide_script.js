function toggleAnswer(index, name) {
    var answer = document.getElementById(`${name}-` + index);
    answer.style.display = (answer.style.display === "block") ? "none" : "block";
}

// 负责打开左侧展开栏的函数，defaultname为默认展开栏的名称,如车票打开时默认选中车票种类
function toggleMenu(menuId, defaultIdName, defaultSubtitleName) {
    var menu = document.getElementById(menuId);
    menu.style.display = (menu.style.display === "block") ? "none" : "block";
    OLDIDNAME = defaultIdName;
    OLDSUBTITLENAME = defaultSubtitleName;
}

// 设置字体反显，如果有active字样，则清除；没有则添加
function toggleSubtitle(subtitle, name) {
    var currentSubtitle = document.querySelector(`.${name}.active`);
    if (currentSubtitle) {
        currentSubtitle.classList.remove('active');
    }
    subtitle.classList.toggle('active');
}

// function showRealNameInfo(name) {
//     document.getElementById("ticket-info").style.display = "none"; // 隐藏车票种类信息
//     document.getElementById("real-name-info").style.display = "block"; // 显示实名制车票信息
//     toggleSubtitle(document.querySelector(`.${name}.active`), name); // 清除当前激活状态
// }

// function showTicketInfo(name) {
//     document.getElementById("ticket-info").style.display = "block"; // 显示车票种类信息
//     document.getElementById("real-name-info").style.display = "none"; // 隐藏实名制车票信息
//     toggleSubtitle(document.querySelector(`.${name}.active`), name); // 清除当前激活状态
// }

// 如 subtitle-1
var OLDSUBTITLENAME = "";
// 如 ticket-info
var OLDIDNAME = "";

// e.g. changeSubtitleInfo(this, 'subtitle-1', 'ticket-info')
function changeSubtitleInfo(subtitle, name, idName) {
    var currentSubtitle = document.querySelector(`.${name}.active`);
    // 如果自身被选中，则保持不变
    if (currentSubtitle === subtitle) {
        OLDIDNAME = idName;
        OLDSUBTITLENAME = name;
        return;
    }
    // 如果自身没有被选中，则切换到自己显示
    else {
        document.getElementById(OLDIDNAME).style.display = "none";
        document.getElementById(idName).style.display = "block";
        OLDIDNAME = idName;
        OLDSUBTITLENAME = name;
    }
}