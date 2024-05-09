<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Portal</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
            height: 100vh;
        }

        .menu {
            width: 250px;
            background-color: #333;
            position: fixed;
            left: 0;
            top: 0;
            overflow-y: auto;
            padding-top: 20px;
            height: 100%;
        }

        .menu ul {
            list-style: none;
            padding: 0;
            margin: 0;
        }

        .menu ul li {
            color: #ccc;
            transition: background-color 0.3s;
            margin-bottom: 10px;
        }

        .menu ul li a {
            color: #ccc;
            text-decoration: none;
            transition: color 0.3s;
            display: block;
            padding: 10px 20px;
            border-radius: 5px;
            background-color: #555;
            margin-bottom: 5px;
        }

        .menu ul li a:hover {
            color: #fff;
        }

        .menu ul li a.active {
            background-color: #3498db;
            color: #fff;
        }

        .menu ul li a.active:hover {
            background-color: #2980b9;
        }

        .content {
            margin-left: 250px;
            padding: 20px;
            height: 100%;
            overflow: auto;
            width: calc(100% - 250px);
            box-sizing: border-box;
            display: flex;
            flex-direction: column;
        }

        .content h1 {
            color: #333;
        }

        iframe {
            flex: 1;
            width: 100%;
            border: none;
        }
    </style>
    <script>
        function setActive(link) {
            var links = document.querySelectorAll('.menu ul li a');
            links.forEach(function(item) {
                item.classList.remove('active');
            });
            link.classList.add('active');
        }
    </script>
</head>
<body>
    <div class="menu">
        <ul>
            <li><a class="link-item" onclick="setActive(this)" href="activvv.aspx" target="contentFrame">View Active Students</a></li>
            <li><a class="link-item" onclick="setActive(this)" href="addmexam.aspx" target="contentFrame">Add Makeup Exam</a></li>
            <li><a class="link-item" onclick="setActive(this)" href="addnewcourse.aspx" target="contentFrame">Add New Course</a></li>
            <li><a class="link-item" onclick="setActive(this)" href="addnewsem.aspx" target="contentFrame">Add New Semester</a></li>
            <li><a class="link-item" onclick="setActive(this)" href="adminlinkinst.aspx" target="contentFrame">Link Instructor to a Coure in a Specific Slot</a></li>
            <li><a class="link-item" onclick="setActive(this)" href="adminlinksta.aspx" target="contentFrame">Link Student to an Advisor</a></li>
            <li><a class="link-item" onclick="setActive(this)" href="adminlinkstci.aspx" target="contentFrame">Link Student to a Course with a Specific Instructor</a></li>

            <li><a class="link-item" onclick="setActive(this)" href="deletecourse.aspx" target="contentFrame">Delete Course</a></li>
            <li><a class="link-item" onclick="setActive(this)" href="gplansadvi.aspx" target="contentFrame">View Graduation Plans with Advisors</a></li>
            <li><a class="link-item" onclick="setActive(this)" href="issueinstallment.aspx" target="contentFrame">Issue Installments</a></li>
            <li><a class="link-item" onclick="setActive(this)" href="offeredcourses.aspx" target="contentFrame">View Offered Courses</a></li>
            <li><a class="link-item" onclick="setActive(this)" href="result.aspx" target="contentFrame">List All Advisors</a></li>
            <li><a class="link-item" onclick="setActive(this)" href="result1.aspx" target="contentFrame">List All Students with their Advisors</a></li>
            <li><a class="link-item" onclick="setActive(this)" href="result2.aspx" target="contentFrame">List All Pending Requests</a></li>
            <li><a class="link-item" onclick="setActive(this)" href="result3.aspx" target="contentFrame">View Details of Instructors with their Courses</a></li>
            <li><a class="link-item" onclick="setActive(this)" href="result4.aspx" target="contentFrame">Fetch Semesters with their Offered Courses</a></li>
            <li><a class="link-item" onclick="setActive(this)" href="slotsdelete.aspx" target="contentFrame">Delete Unoffered Courses' Slots</a></li>
            <li><a class="link-item" onclick="setActive(this)" href="studentpayment.aspx" target="contentFrame">Students' Payments</a></li>
            <li><a class="link-item" onclick="setActive(this)" href="transcript.aspx" target="contentFrame">Students' Transcripts</a></li>
            <li><a class="link-item" onclick="setActive(this)" href="updatestatus.aspx" target="contentFrame">Update Students' Status</a></li>
        </ul>
    </div>
    <div class="content">
        <h1>Welcome to Student Portal</h1>
        <iframe name="contentFrame" src="" frameborder="0"></iframe>
    </div>
</body>
</html>
