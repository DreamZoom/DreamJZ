<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Dream.EntityBase>>" %>

<% var propertys = Html.Metadata(); %>

<%foreach(var property in propertys){ %>
<%if (property.ListMode != Dream.ShowMode.Show) continue;%>
<th><%:property.DisplayName %></th>    
<%} %>
