<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Frame.Master" Inherits="System.Web.Mvc.ViewPage<Dream.EntityBase>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <div class="alert alert-danger">
        您确定要删除此项么？
    </div>
    
    <div class="form-horizontal">
        <% using (Html.BeginForm())
           { %>
        <%: Html.AntiForgeryToken() %>
        <%: Html.ValidationSummary(true) %>


        <% var propertys = Html.Metadata(); %>

        <div class="form-group-separator"></div>

        <%foreach (var property in propertys)
          { %>
        <%if (property.EditMode == Dream.ShowMode.Remove){continue;}%>
        <%:Html.Hidden(property.PropertyName) %>
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
                <input type="submit" class="btn danger" value="删除" /> 
                <%: Html.ActionLink("返回列表", "List", new { }, new { @class="btn default"})%>
            </div>
        </div>


        <% } %>
    </div>

</asp:Content>
