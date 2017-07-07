<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Dream.Config.MenuNode>" %>

<%if (Model.Group)
  {
      var iscurrent = Model.IsCurrent(Html.ViewContext.RequestContext);
%>
<li class="nav-item start <%:(iscurrent?"open active":"") %>">

    <a href="#" class="nav-link nav-toggle">
        <%--<i class="linecons-cog"></i>--%>
        <span class="title"><%:Model.Name %></span>
        <%if (iscurrent)
          {%>
        <span class="selected"></span>
        <span class="arrow open"></span>
        <%}else{ %>
        <span class="arrow"></span>
        <%} %>
    </a>

    <ul class="sub-menu">
        <% foreach (var menu in Model.Menus)
           {
               if (menu.ShowMode == 2) continue;%>
        <%:Html.Partial("__menu",menu) %>
        <%} %>
    </ul>
</li>

<%}
  else
  {%>
<li class="nav-item <%:(Model.IsCurrent(Html.ViewContext.RequestContext)?"active":"") %>">
    <a href="<%:Url.Action(Model.ActionName,Model.ControllerName,Model.getParams()) %>" class="nav-link ">
        <%--<i class="linecons-cog"></i>--%>
        <span class="title"><%:Model.Name %></span>
    </a>
</li>

<%} %>