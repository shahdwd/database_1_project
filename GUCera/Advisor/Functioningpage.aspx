<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Functioningpage.aspx.cs" Inherits="GUCera.Functioningpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

   
</head>
    <style>
        body {
            margin: 0;
            padding: 0;
        }

        .container {
            display: flex;
        }
.menu {
        width: 165px;
        background-color:#E3EAEB;
        height: 1000px;
        flex:1;
    }
   .content {
            flex: 8;
            padding: 20px;
        }

     .centered-content {
    flex: 8;
    padding: 20px;
    display: flex;
    flex-direction: column;
    align-items: center;
}   
    </style>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="menu">
              <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick" BackColor="#E3EAEB" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#666666" StaticSubMenuIndent="10px">
                  <DynamicHoverStyle BackColor="#666666" ForeColor="White" />
                  <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                  <DynamicMenuStyle BackColor="#E3EAEB" />
                  <DynamicSelectedStyle BackColor="#1C5E55" />
    <DynamicItemTemplate>
        <%# Eval("Text") %>
    </DynamicItemTemplate>
    <Items>
        <asp:MenuItem Text="Home" Value="Home" Selected="True"></asp:MenuItem>
        <asp:MenuItem Text="Update Graduation Date" Value="UpdateGP"></asp:MenuItem>
        <asp:MenuItem Text="Delete Course" Value="DeletefromGP"></asp:MenuItem>
        <asp:MenuItem Text="View">
            <asp:MenuItem Text="Advising Students" Value="AdvisingStudents"></asp:MenuItem>
            <asp:MenuItem Text="Students Major Courses" Value="StudentsMajorCourses"></asp:MenuItem>
            <asp:MenuItem Text="All Requests" Value="AllRequests"></asp:MenuItem>
            <asp:MenuItem Text="Pending Requests" Value="PendingRequests"></asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem Text="Insert">
            <asp:MenuItem Text="Graduation Plan" Value="Gradplan"></asp:MenuItem>
            <asp:MenuItem Text="Course in a Graduation Plan" Value="Courseingradplan"></asp:MenuItem>
        </asp:MenuItem>
        <asp:MenuItem Text="Sign Out" Value="SignOut"></asp:MenuItem>
    </Items>
                  <StaticHoverStyle BackColor="#666666" ForeColor="White" />
                  <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                  <StaticSelectedStyle BackColor="#1C5E55" />
</asp:Menu>

                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            <br />
            </div>

            <div class="centered-content">

           <asp:Panel ID="ContentPanel" runat="server">
                    <asp:Label ID="Label2" runat="server" Text="Label" ForeColor="Red" Visible="false"></asp:Label>
                    &nbsp; <asp:HyperLink ID="LoginLink" runat="server" NavigateUrl="login.aspx" Text="Log in" Visible="false"></asp:HyperLink>
                    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0" OnActiveViewChanged="MultiView1_ActiveViewChanged">

          <asp:View ID="ViewHome" runat="server">
              <h2>Welcome to the advising students&#39; system at the GUC  </h2>
                         
          </asp:View>
                        <asp:View ID="ViewAdvisingStudents" runat="server">
                            Write the major:<br />
            <asp:TextBox ID="targetMajor" runat="server"></asp:TextBox>
              <br />
            <asp:Button ID="ViewStudentsMajorCourses" runat="server" OnClick="ViewAdvisingStudentsWithMajor" Text="View" />
               
                            <br />
                            All Advising Students<asp:GridView ID="GridViewStudents" runat="server" AutoGenerateColumns="False" EmptyDataText="No records found">
        <Columns>
            <asp:BoundField DataField="student_id" HeaderText="Student ID" />
            <asp:BoundField DataField="Student_name" HeaderText="Student Name" />
            <asp:BoundField DataField="major" HeaderText="Major" />
            <asp:BoundField DataField="Course_name" HeaderText="Course Name" />
        </Columns>
    </asp:GridView>
            </asp:View>

             <asp:View ID="ViewStudentwithMajor" runat="server">       
                 <br />
                 All advising Students       
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="No advising students found">
    <Columns>
        <asp:BoundField DataField="student_id" HeaderText="Student ID" SortExpression="student_id" />
        <asp:BoundField DataField="Student_name" HeaderText="Student Name" SortExpression="Student_name" />
    </Columns>
</asp:GridView>
              </asp:View>

              <asp:View ID="AllRequests" runat="server">
               All requests
                  <asp:GridView ID="GridViewRequests" runat="server" AutoGenerateColumns="False" EmptyDataText="No records found">
    <Columns>
        <asp:BoundField DataField="request_id" HeaderText="Request ID" />
        <asp:BoundField DataField="type" HeaderText="Type" />
        <asp:BoundField DataField="comment" HeaderText="Comment" />
        <asp:BoundField DataField="status" HeaderText="Status" />
        <asp:BoundField DataField="credit_hours" HeaderText="Credit Hours" />
        <asp:BoundField DataField="course_id" HeaderText="Course ID" />
        <asp:BoundField DataField="student_id" HeaderText="Student ID" />
        <asp:BoundField DataField="advisor_id" HeaderText="Advisor ID" />
    </Columns>

    </asp:GridView>
              </asp:View>   

             <asp:View ID="AllPendingRequests" runat="server">
                         All Pending requests
    <asp:GridView ID="GridViewPending" runat="server" AutoGenerateColumns="False" EmptyDataText="No records found" >
<Columns>
    <asp:BoundField DataField="request_id" HeaderText="Request ID" />
    <asp:BoundField DataField="type" HeaderText="Type" />
    <asp:BoundField DataField="comment" HeaderText="Comment" />
    <asp:BoundField DataField="status" HeaderText="Status" />
    <asp:BoundField DataField="credit_hours" HeaderText="Credit Hours" />
    <asp:BoundField DataField="course_id" HeaderText="Course ID" />
    <asp:BoundField DataField="student_id" HeaderText="Student ID" />
    <asp:BoundField DataField="advisor_id" HeaderText="Advisor ID" />
   
    <asp:TemplateField HeaderText="Actions">
            <ItemTemplate>
          
                <asp:Button ID="Button1" runat="server" Text="Respond" OnClick="btnRespond_Click2" CommandArgument='<%# Eval("request_id") %>' />

            </ItemTemplate>
        </asp:TemplateField>
</Columns>
  </asp:GridView>
</asp:View>
                <asp:View ID="InsertGradPlan" runat="server">
                    Semester Code<br />
                    <asp:TextBox ID="SemCode" runat="server" Width="117px"></asp:TextBox>
                    <br />
                    <br />
                    Graduation Date
                    
                    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                    <br />
                    Credit Hours<br />
                    <asp:TextBox ID="Credit_Hours" TextMode="Number" runat="server" Width="90px"></asp:TextBox>
                    <br />

                    Student ID<br />
                    <asp:TextBox ID="Student_id" runat="server" Width="91px"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="Confirm" runat="server" OnClick="InsertionConfirm" Text="Insert" />
                    <br/>
                   
                    <asp:Label ID="Label1" runat="server" ForeColor="Green" Visible="false"></asp:Label>

                </asp:View>  

                <asp:View ID="InsertCourse" runat="server">
                    Student ID<br />
                    <asp:TextBox ID="StudentIDD" runat="server"></asp:TextBox>
                    <br />
                    Semester Code<br />
                    <asp:TextBox ID="SemCodee" runat="server"></asp:TextBox>
                    <br />
                    Course name<br />
                    <asp:TextBox ID="CourseNamee" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="InsertCourseButton" runat="server" OnClick="InsertCourse2" Text="Insert" />
                    <br />
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>

                </asp:View>  
                    <asp:View ID="UpdateDate" runat="server">

                        <br />
                        <asp:Calendar ID="Calendar2" runat="server"></asp:Calendar>
                        <br />
                        Student ID<br />
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Button ID="Button2" runat="server" Text="Update" OnClick="Button2_Click" />
                         <br />
                            <asp:Label ID="lblUpdateStatus" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                    </asp:View>
                    <asp:View ID="DeletCourse" runat="server">

                        Student ID<br />
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                        <br />
                        Semester Code<br />
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                        <br />
                        Course ID<br />
                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Button ID="Button3" runat="server" Text="Delete" OnClick="Button3_Click" />
                         <br />
                     <asp:Label ID="lblDeleteStatus" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                    </asp:View>

                    </asp:MultiView>
               </asp:Panel>

           </div>
        </div>
    </form>
</body>
</html>
