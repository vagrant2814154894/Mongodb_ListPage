function PageList() { }
var totalPage;
var totalRecords;
var pageSize = 10;
var pageIndex = 1;
PageList.prototype = {
    getPageList: function () {
        Sub(1);
    }
}
//查询
function Sub(index) {
    if (index == 1) {
        selectPage(1, pageSize, $("#Id").val(), true);
    } else {
        selectPage(pageIndex, pageSize, $("#Id").val(), true);
    }

}
function selectPage(PageIndex, PageSize, Id, first) {
    first = first == undefined ? true : first;
    jQuery.ajax({
        async: false,
        url: "/Vehicle/Post",
        type: "POST",
        dataType: "json",
        data: { pageIndex: PageIndex, pageSize: PageSize },
        success: function (result) {
            var html = "";
            if (result.Code == 0) {
                log(result.Data.TotalData, first);
                var da = result.Data;
                for (var i = 0; i < da.PageData.length; i++) {
                    html += "<tr>";
                    html += "<td>" + da.PageData[i].VehicleId + "</td>";
                    html += "<td>" + da.PageData[i].Citycode + "</td>";
                    html += "<td>" + da.PageData[i].Lng + "</td>";
                    html += "<td>" + da.PageData[i].Lat + "</td>";
                    html += "<td>" + da.PageData[i].Speed + "</td>";
                    html += "<td>" + da.PageData[i].Direction + "</td>";

                    //html += "<td>" + ConvertTimeSpan2(da.Data[i].dTime) + "</td>";
                    switch (da.PageData[i].VType) {
                        case 11:
                            {
                                html += "<td>" + "省际客运班车" + "</td>";
                                break;
                            }
                        case 12:
                            {
                                html += "<td>" + "市际客运班车" + "</td>";
                                break;
                            }
                        case 13:
                            {
                                html += "<td>" + "旅游客运车辆" + "</td>";
                                break;
                            }
                        case 14:
                            {
                                html += "<td>" + "县际客运班车" + "</td>";
                                break;
                            }
                        case 15:
                            {
                                html += "<td>" + "县内客车" + "</td>";
                                break;
                            }
                        case 20:
                            {
                                html += "<td>" + "危险货物运输车辆" + "</td>";
                                break;
                            }
                        case 31:
                            {
                                html += "<td>" + "重型载货汽车" + "</td>";
                                break;
                            }
                        case 32:
                            {
                                html += "<td>" + "半挂牵引车" + "</td>";
                                break;
                            }
                        case 33:
                            {
                                html += "<td>" + "普通货车" + "</td>";
                                break;
                            }
                        case 41:
                            {
                                html += "<td>" + "出租汽车" + "</td>";
                                break;
                            }
                        case 43:
                            {
                                html += "<td>" + "公交车" + "</td>";
                                break;
                            }
                        case 51:
                            {
                                html += "<td>" + "警车" + "</td>";
                                break;
                            }
                        case 53:
                            {
                                html += "<td>" + "船" + "</td>";
                                break;
                            }

                        case 99:
                            {
                                html += "<td>" + "其他" + "</td>";
                                break;
                            }
                        default:
                            {
                                html += "<td>" + "其他" + "</td>";
                                break;
                            }
                    }
                    //html += "<td>" + da.Data[i].vType + "</td>";

                    html += "</tr>";
                }
                $("#tables").html(html);
            }
            else {
                log(0, first);
                $("#tables").html("");
            }
        }
    });
}
function log(TotalCount, first) {
    if (TotalCount >= 0) {
        totalRecords = TotalCount;
        totalPage = Math.ceil(totalRecords / pageSize);
        var pageNo = pageIndex;
        if (!pageNo) {
            pageNo = 1;
        }
        //生成分页
        //有些参数是可选的，比如lang，若不传有默认值
        kkpager.generPageHtml({
            pno: pageNo,
            //总页码
            total: totalPage,
            //总数据条数
            totalRecords: totalRecords,
            mode: 'click',//默认值是link，可选link或者click
            click: function (n) {
                pageIndex = n;
                selectPage(n, pageSize, $("#Id").val(), true);
                return false;
            }

            , lang: {
                firstPageText: '首页',
                firstPageTipText: '首页',
                lastPageText: '尾页',
                lastPageTipText: '尾页',
                prePageText: '上一页',
                prePageTipText: '上一页',
                nextPageText: '下一页',
                nextPageTipText: '下一页',
                totalPageBeforeText: '共',
                totalPageAfterText: '页',
                currPageBeforeText: '当前第',
                currPageAfterText: '页',
                totalInfoSplitStr: '/',
                totalRecordsBeforeText: '共',
                totalRecordsAfterText: '条数据',
                gopageBeforeText: '&nbsp;转到',
                gopageButtonOkText: '确定',
                gopageAfterText: '页',
                buttonTipBeforeText: '第',
                buttonTipAfterText: '页'
            }
        }, first);
    }
}
function GetParameter(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}
var Vehicle = new PageList();