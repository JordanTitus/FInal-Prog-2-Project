<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Farmer.aspx.cs" Inherits="FInal_Prog_2_Project.Farmer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form>
        <div class="form-group">
            <label for="txtProductName">Product Name</label>
            <input type="text" class="form-control" id="txtProductName" placeholder="Daniels Potatos" runat="server">
        </div>
        
        <div class="form-group">
            <label for="SelectProduct">Product Type</label>
            <select class="form-control" id="SelectProduct" runat="server">
                <option>Potato</option>
                <option>Onion</option>
                <option>Carrot</option>
                <option>Grapes</option>
                <option>Lettuce</option>
            </select>
        </div>

        <div class="form-group">
            <label for="txtProductQuantiity">Product Quantity</label>
            <input type="text" class="form-control" id="txtProductQuantiity" placeholder="100" runat="server">
        </div>

        <div class="form-group">
            <label for="txtProductPrice">Product Price Per Unit (R)</label>
            <input type="text" class="form-control" id="txtProductPrice" placeholder="350" runat="server">
        </div>
    </form>

    <button id="btnSubmitProduct" OnClick="btnSubmitProd_Click" type="submit" class="btn btn-primary" runat="server">Submit</button>

</asp:Content>
