<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeBehind="Visits.aspx.cs" Inherits="MedicalOfficeWeb.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <br/>

    <div class="container p-3 mx-auto" style="background-color: white">

        <div>
            <br/>
            <div>
                <asp:Label runat="server" Text="Search by ID : "></asp:Label>
                <asp:TextBox ID="tb_searchID" CssClass="p-2" runat="server" Width="188px" TextMode="Number"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; |&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                <asp:Label runat="server" Text="Search by name : "></asp:Label>
                <asp:TextBox ID="tb_searchName" CssClass="p-2" runat="server"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;<br />
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button runat="server" CssClass="btn btn-outline-primary" OnClick="bt_search_OnClick" Text="Search" Width="487px"/>


                <br />


            </div>

            <br />

            <asp:GridView ID="gv_visits" runat="server" CaptionAlign="Left"
                     OnSelectedIndexChanged="gv_patients_OnSelectedIndexChanged"    CssClass="mx-auto table table-borderless" AlternatingRowStyle-BackColor="#003366" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">

                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:ButtonField CommandName="Select" Text="Show" />
                </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />

            </asp:GridView>
            <hr/>
        </div>
        <div class="d-inline mx-auto container" style="height: 193px">
            <asp:HiddenField ID="hf_visitID" runat="server"/>
            <br />
            <asp:Label runat="server" Enabled="true" ID="lbl_newPatient" Text="New Visit's patient : "></asp:Label>
            <asp:DropDownList runat="server" Enabled="true" ID="ddl_patients"></asp:DropDownList>
            
            <br />
            <br />
            
            <asp:Label runat="server" Text="Lastname : "></asp:Label>
            <asp:TextBox ID="tb_lastname"  CssClass="p-2" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label runat="server" Text="Firstname : "></asp:Label>
            <asp:TextBox ID="tb_firstname" CssClass="p-2" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label runat="server" Text="Date : "></asp:Label>
            <asp:TextBox ID="tb_date" CssClass="p-2" runat="server" TextMode="Email"></asp:TextBox>
            
            <br />
            <br />
            
            <asp:Label runat="server" Text="Record : "></asp:Label>
            &nbsp;<br />
            <asp:TextBox ID="tb_record"  CssClass="p-2" runat="server" TextMode="MultiLine" Height="312px" Width="722px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <div class="my-lg-2 btn-group justify-content-center align-content-center d-flex">
                
                <asp:Button runat="server" ID="bt_add" CssClass="btn btn-info mx-1"   Text="Add" OnClick="bt_add_Click" Width="133px"  />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button runat="server" ID="bt_del" CssClass="btn btn-danger mx-1"  Text="Delete" OnClick="bt_del_Click" Width="133px"/>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button runat="server" ID="bt_mod" CssClass="btn btn-primary mx-1" Text="Modify" OnClick="bt_mod_Click" Width="133px" />

            </div>
        </div>
    </div>
</asp:Content>
