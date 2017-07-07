<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Frame.Master" Inherits="System.Web.Mvc.ViewPage<Dream.Cms.Content>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Test
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Test</h2>
    <form class="form-horizontal">
       
        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
                <button type="submit" class="btn btn-default">Sign in</button>
            </div>
        </div>
    </form>
</asp:Content>
