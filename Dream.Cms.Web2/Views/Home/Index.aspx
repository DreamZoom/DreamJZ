<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Frame.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        
        var Count = ViewBag.Count as Dictionary<string, int>;
     %>
    <!-- BEGIN DASHBOARD STATS 1-->
    <%--<div class="row">
        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
            <div class="dashboard-stat blue">
                <div class="visual">
                    <i class="fa fa-comments"></i>
                </div>
                <div class="details">
                    <div class="number">
                        <span data-counter="counterup" data-value="1349"><%: Count["channelCount"]%></span>
                    </div>
                    <div class="desc">频道 </div>
                </div>
                <a class="more" href="<%:Url.Action("List","Channel") %>">更多频道
                                   
                    <i class="m-icon-swapright m-icon-white"></i>
                </a>
            </div>
        </div>
        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
            <div class="dashboard-stat red">
                <div class="visual">
                    <i class="fa fa-bar-chart-o"></i>
                </div>
                <div class="details">
                    <div class="number">
                        <span data-counter="counterup" data-value="12,5"><%: Count["categoryCount"]%></span>
                    </div>
                    <div class="desc">类别 </div>
                </div>
                <a class="more" href="<%:Url.Action("List","Category") %>">更多类别
                                   
                    <i class="m-icon-swapright m-icon-white"></i>
                </a>
            </div>
        </div>
        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
            <div class="dashboard-stat green">
                <div class="visual">
                    <i class="fa fa-shopping-cart"></i>
                </div>
                <div class="details">
                    <div class="number">
                        <span data-counter="counterup" data-value="549"><%: Count["articleCount"]%></span>
                    </div>
                    <div class="desc">文章内容 </div>
                </div>
                <a class="more" href="<%:Url.Action("List","Article") %>">更多文章
                                   
                    <i class="m-icon-swapright m-icon-white"></i>
                </a>
            </div>
        </div>
        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
            <div class="dashboard-stat purple">
                <div class="visual">
                    <i class="fa fa-globe"></i>
                </div>
                <div class="details">
                    <div class="number">
                                 
                        <span data-counter="counterup" data-value="89"><%: Count["friendlinkCount"]%></span>
                    </div>
                    <div class="desc">友情链接 </div>
                </div>
                <a class="more" href="<%:Url.Action("List","FriendLink") %>">更多链接
                                   
                    <i class="m-icon-swapright m-icon-white"></i>
                </a>
            </div>
        </div>
    </div>--%>
    <div class="clearfix"></div>
    <!-- END DASHBOARD STATS 1-->
 
</asp:Content>
