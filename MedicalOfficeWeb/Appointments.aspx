<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeBehind="Appointments.aspx.cs" Inherits="MedicalOfficeWeb.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <br/>

    <div class="container p-3 mx-auto" style="background-color: white">

        <div>
            <br/>
            <div>
                <asp:Label runat="server" Text="Search by Date :  from  "></asp:Label>
                <asp:TextBox ID="tb_searchStartDate" CssClass="p-2" runat="server" Width="188px" TextMode="Number"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;to&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tb_searchEndDate" CssClass="p-2" runat="server" Width="188px" TextMode="Number"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp; |&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label runat="server" Text="Search by name : "></asp:Label>
                <asp:TextBox ID="tb_searchName" CssClass="p-2" runat="server"></asp:TextBox>
                &nbsp;&nbsp;<br />
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button runat="server" CssClass="btn btn-outline-primary" OnClick="bt_search_OnClick" Text="Search" Width="833px"/>


                <br />


            </div>

            <br />

            <asp:GridView ID="gv_appointments" runat="server" CaptionAlign="Left" OnSelectedIndexChanged="gv_patients_OnSelectedIndexChanged" CssClass="mx-auto table table-borderless" AlternatingRowStyle-BackColor="#003366" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">

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
            <asp:HiddenField ID="hf_appointmentID" runat="server"/>
            <br />
            <asp:Label runat="server" Text="Lastname : " Enabled="false"></asp:Label>
            <asp:TextBox ID="tb_lastname"  CssClass="p-2" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label runat="server" Text="Firstname : " Enabled="false"></asp:Label>
            <asp:TextBox ID="tb_firstname" CssClass="p-2" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label runat="server" Text="Address : " Enabled="false"></asp:Label>
            <asp:TextBox ID="tb_address"  CssClass="p-2" runat="server" TextMode="MultiLine"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label runat="server" Text="Email : " Enabled="false"></asp:Label>
            <asp:TextBox ID="tb_email" CssClass="p-2" runat="server" TextMode="Email"></asp:TextBox>
            <br />
            <br />
            <asp:Label runat="server" Text="Appointment Date : "></asp:Label>
            <asp:TextBox ID="tb_date" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label runat="server" Text="Patient :  "></asp:Label>
            <asp:DropDownList ID="ddl_patients" runat="server"></asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label runat="server" Text="Status: "></asp:Label>
            <asp:DropDownList ID="ddl_status" runat="server">
                <asp:ListItem>Attended</asp:ListItem>
                <asp:ListItem>Missed</asp:ListItem>
                <asp:ListItem>NONE</asp:ListItem>
            </asp:DropDownList>
            
            <br />
            <br />
            <div class="my-lg-2 btn-group justify-content-center align-content-center d-flex">
                
                <asp:Button runat="server" ID="bt_add" CssClass="btn btn-info mx-1 "   Text="Add" OnClick="bt_add_Click" Width="133px"  />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button runat="server" ID="bt_del" CssClass="btn btn-danger mx-1"  Text="Delete" OnClick="bt_del_Click" Width="133px"/>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button runat="server" ID="bt_mod" CssClass="btn btn-primary mx-1" Text="Modify" OnClick="bt_mod_Click" Width="133px" />

            </div>
        </div>
    </div>





    </asp:Content>
