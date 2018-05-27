<%@ Page Title="" Language="C#" MasterPageFile="~/MyMasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Sport.Home" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
         <div style="width:70%; text-align:center" >
            <table style="width:100%;padding-top:50px">
                <tr>
                    <td style="width:50%; text-align:right; padding-right:20px">
                        Task ID:
                    </td>
                    <td style="width:50%; text-align:left">
                        <asp:Label ID="Lbl_TaskID" runat="server" Text="New"></asp:Label>

                    </td>
                </tr>

                <tr>
                    <td style="width:50%; text-align:right; padding-right:20px">
                        Task Date:
                    </td>
                    <td style="width:50%; text-align:left">
                        <asp:TextBox ID="TxtBox_TaskDate" Enabled="false" runat="server" ></asp:TextBox>
    
                        <asp:ImageButton ID="imgPopup" runat="server" ImageUrl="images/calendar_icon.png" ImageAlign="Bottom" OnClick="show_date" Width="25px" Height="25px" />
                        

                        <asp:Calendar ID="Calendar_TaskDate" runat="server" Visible="false" BackColor="White" SelectedDate="<%# DateTime.Today %>" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px" OnSelectionChanged="Calendar1_SelectionChanged">
                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                            <TodayDayStyle BackColor="#CCCCCC" />
                        </asp:Calendar>
                    </td>
                </tr>
                <tr>
                    <td style="width:50%; text-align:right; padding-right:20px">
                        Task Details:
                    </td>
                    <td style="width:50%; text-align:left">
                        <asp:TextBox ID="TxtBox_TaskDetails" runat="server" Width="100%" Height="75px" MaxLength="50" TextMode="MultiLine" ></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td style="width:50%; text-align:right; padding-right:20px">
                        Set Reminder on:
                    </td>
                    <td style="width:50%; text-align:left">
                        <asp:TextBox ID="TxtBox_Reminder" Enabled="false" runat="server" ></asp:TextBox>
    
                        <asp:ImageButton ID="ImageButton_Reminder" runat="server" ImageUrl="images/calendar_icon.png" ImageAlign="Bottom"  Width="25px" Height="25px" OnClick="ImageButton_Reminder_Click" />
                        

                        <asp:Calendar ID="Calendar_Reminder" runat="server" Visible="false" BackColor="White" SelectedDate="<%# DateTime.Today %>" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px" OnSelectionChanged="Calendar_Reminder_SelectionChanged" >
                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                            <TodayDayStyle BackColor="#CCCCCC" />
                        </asp:Calendar>
                    </td>
                </tr>

                <tr>
                    <td style="width:50%; text-align:right; padding-right:20px">
                        Share Task with:
                    </td>
                    <td style="width:50%; text-align:left">
                        <asp:DropDownList ID="DDL_SharedWith" runat="server" DataSourceID="SqlDataSource2" DataTextField="UserFName" DataValueField="UserID" AppendDataBoundItems="true">
                            <Items>
                                  <asp:ListItem Text="N/A" Value="N/A" />
                            </Items>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:TaskDBConnectionString %>" SelectCommand="SELECT [UserID], [UserFName] FROM [UserInfo] ORDER BY [UserFName]"></asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td style="width:50%;">
                        &nbsp;
                    </td>
                    <td style="width:50%; text-align:left">
                        <asp:Button ID="Btn_Save" runat="server" Text="Save" OnClick="Btn_Save_Click" />
                        <asp:Button ID="Btn_Cancel" runat="server" Text="Cancel" OnClick="Btn_Cancel_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="width:50%; padding-top:50px">
                        &nbsp;
                    </td>
                    <td style="width:50%; text-align:left">
                        <asp:Label ID="Lbl_Task" runat="server" Text=""></asp:Label>
                        
                    </td>
                </tr>
            </table>
        </div>
 

    
<center>

    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" DataSourceID="SqlDataSource1" 
        OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" PageSize="20"
        >
        <Columns>
            <asp:BoundField DataField="TaskID" HeaderText="TaskID" SortExpression="TaskID" InsertVisible="False" ReadOnly="True" />
            <asp:BoundField DataField="TaskDate" HeaderText="Task Date" SortExpression="TaskDate" ReadOnly="True" />
            <asp:BoundField DataField="TaskDetails" HeaderText="Task Details" SortExpression="TaskDetails" />
            <asp:BoundField DataField="CreatedByFname" HeaderText="Created by" SortExpression="CreatedByFname" />
            <asp:BoundField DataField="CreatedOn" HeaderText="Created on" SortExpression="CreatedOn" ReadOnly="True" />
            <asp:BoundField DataField="ReminderOn" HeaderText="Reminder Date" SortExpression="ReminderOn" ReadOnly="True" />
            <asp:BoundField DataField="SharedWithName" HeaderText="Shared with" SortExpression="SharedWithName" />
            <asp:TemplateField>
                  <ItemTemplate>
                    <asp:Button ID="AddButton" runat="server" CommandName="MyEdit" 
                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Edit" />
                  </ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField>
                  <ItemTemplate>
                    <asp:Button ID="Btn_Delete" runat="server" CommandName="MyDelete" 
                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Delete" />
                  </ItemTemplate> 
            </asp:TemplateField> 
        </Columns>
    </asp:GridView>




    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TaskDBConnectionString %>" SelectCommand="SELECT A.TaskID, CONVERT (Varchar, A.TaskDate, 103) AS TaskDate, A.TaskDetails, C.UserFName AS CreatedByFname, CONVERT (varchar, A.CreatedOn, 103) AS CreatedOn, CASE WHEN ([ReminderOn] = '1900-01-01 00:00:00.000') THEN 'N/A' ELSE CONVERT (varchar , [ReminderOn] , 103) END AS ReminderOn, CASE WHEN B.UserFName IS NULL THEN 'N/A' ELSE B.UserFName END AS SharedWithName FROM TaskDetailsInfo AS A LEFT OUTER JOIN UserInfo AS B ON A.SharedWith = B.UserID INNER JOIN UserInfo AS C ON A.CreatedBy = C.UserID WHERE Isdeleted=0 ORDER BY A.TaskID DESC"></asp:SqlDataSource>
    </center>
        


</asp:Content>
