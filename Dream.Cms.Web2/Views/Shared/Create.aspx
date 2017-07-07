<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Frame.Master" Inherits="System.Web.Mvc.ViewPage<Dream.EntityBase>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-horizontal">
        <% using (Html.BeginForm())
           { %>
        <%: Html.AntiForgeryToken() %>
        <%: Html.ValidationSummary(true) %>


        <% var propertys = Html.Metadata(); %>
        <div class="form-body">
            <%foreach (var property in propertys)
              { %>

            <%if (property.IsIdentity) continue; %>
            <%if(property.CreateMode== Dream.ShowMode.Show) {%>
            <div class="form-group">
                <label class="col-sm-2 control-label" for="<%:property.PropertyName %>"><%:Html.DisplayName(property.PropertyName) %></label>

                <div class="col-sm-10">
                    <span><%:Html.Editor(property.PropertyName) %></span>

                    <span class="help-block"><%:Html.ValidationMessage(property.PropertyName) %></span>
                </div>
            </div>
            <%}
              else if (property.CreateMode == Dream.ShowMode.Hidden)
              {%>
               <%:Html.Hidden(property.PropertyName) %>
            <%}else{} %>

            <%} %>
        </div>
        <div class="form-actions">
            <div class="row">
                <div class="col-md-offset-2 col-md-10">
                    <input type="submit" value="保存" class="btn blue " />
                    <%: Html.ActionLink("返回列表", "List", new { }, new { @class="btn default"})%>
                </div>
            </div>
        </div>

        <% } %>
    </div>

</asp:Content>
