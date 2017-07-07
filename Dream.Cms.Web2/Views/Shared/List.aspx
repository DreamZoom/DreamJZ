<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Frame.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Dream.EntityBase>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    数据列表
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% using (Html.BeginForm())
       { %>
    <%: Html.AntiForgeryToken() %>
    <%: Html.ValidationSummary(true) %>
    <div class="row">
        <div class="col-xs-12">
            <table class="table datatable responsive">
                <thead>
                    <tr>
                        <%:Html.Partial("__th") %>
                        <th>操作</th>
                    </tr>
                </thead>
                <tbody>
                    <% foreach (var item in Model)
                       { %>
                    <tr>

                        <%:Html.Partial("__td",item) %>
                        <td>
                            <%: Html.ActionLink("编辑", "Edit", new { id=item.ID }) %> |
                            <%: Html.ActionLink("详情", "Details", new { id=item.ID }) %> |
                            <%: Html.ActionLink("删除", "Delete", new { id=item.ID }) %>
                        </td>
                    </tr>
                    <% } %>
                </tbody>
            </table>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-6 ">
            <%: Html.ActionLink("新建", "Create", new { }, new { @class="btn blue"})%>
        </div>
        <div class="col-xs-6">
            <%:Html.MvcPager(Model) %>
        </div>
    </div>
    <% } %>

   
</asp:Content>
