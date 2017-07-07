<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Dream.EntityBase>" %>


<% var propertys = Html.Metadata(); %>

<%foreach(var property in propertys){ %>
<%if (property.ListMode != Dream.ShowMode.Show) continue;%>
<td><%:Html.Display(property.PropertyName) %></td>    
<%} %>