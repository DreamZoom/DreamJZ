<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Frame.Master" Inherits="System.Web.Mvc.ViewPage<Dream.EntityBase>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-horizontal">
        <% using (Html.BeginForm())
           { %>
        <%: Html.AntiForgeryToken() %>
        <%: Html.ValidationSummary(true) %>


        <% var propertys = Html.Metadata(); %>

        <%foreach (var property in propertys)
          { %>
        <%if (property.EditMode == Dream.ShowMode.Remove){continue;}%>
        <div class="form-group">
            <label class="col-sm-2 control-label" for="<%:property.PropertyName %>"><%:Html.DisplayName(property.PropertyName) %></label>

            <div class="col-sm-10">
                <%:Html.Display(property.PropertyName) %>
            </div>
        </div>

        <div class="form-group-separator"></div>
        <%} %>

        <div class="form-group">
            <label class="col-sm-2 control-label" for="field-1"></label>

            <div class="col-sm-10">
                <%: Html.ActionLink("编辑", "Edit", new { id=Model.ID }, new { @class="btn blue"}) %> 
                <%: Html.ActionLink("返回列表", "List", new { }, new { @class="btn default"})%>
            </div>
        </div>


        <% } %>
    </div>
    

</asp:Content>
