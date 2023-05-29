<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="FInal_Prog_2_Project.Employee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <form>
        <div class="form-group">
            <label for="exampleInputEmail1">Search Products</label>
            <input type="text" class="form-control" id="txtSearch" aria-describedby="emailHelp" placeholder="Search for...">
            <small id="emailHelp" class="form-text text-muted">Search for products by entering farmer ID .</small>
        </div>
        <button type="submit" class="btn btn-primary">Search</button>
    </form>
    <table class="table">
        <thead>
            <tr>
                <th scope="col">#</th>
                <th scope="col">First</th>
                <th scope="col">Last</th>
                <th scope="col">Handle</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <th scope="row">1</th>
                <td>Mark</td>
                <td>Otto</td>
                <td>@mdo</td>
            </tr>
            <tr>
                <th scope="row">2</th>
                <td>Jacob</td>
                <td>Thornton</td>
                <td>@fat</td>
            </tr>
            <tr>
                <th scope="row">3</th>
                <td>Larry</td>
                <td>the Bird</td>
                <td>@twitter</td>
            </tr>
        </tbody>
    </table>

</asp:Content>
