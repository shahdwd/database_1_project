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
            <li><a class="link-item" onclick="setActive(this)" href="AddPhone.aspx" target="contentFrame">Add Phone Number(s)</a></li>
            <li><a class="link-item" onclick="setActive(this)" href="OptionalCourses.aspx" target="contentFrame">View Optional Courses</a></li>
            <li><a class="link-item" onclick="setActive(this)" href="AvailableCourses.aspx" target="contentFrame">View Available Courses</a></li>
            <li><a class="link-item" onclick="setActive(this)" href="RequiredCourses.aspx" target="contentFrame">View Required Courses</a></li>
            <li><a class="link-item" onclick="setActive(this)" href="MissingCourses.aspx" target="contentFrame">View Missing Courses</a></li>
            <li><a class="link-item" onclick="setActive(this)" href="AddCourseRequest.aspx" target="contentFrame">Send Course Request</a></li>
            <li><a class="link-item" onclick="setActive(this)" href="AddCHRequest.aspx" target="contentFrame">Send Credit Hour(s) Request</a></li>

            <li><a class="link-item" onclick="setActive(this)" href="CertainCourseSlotsInstructor.aspx" target="contentFrame">Slots of Certain Course and Instructor</a></li>
            <li><a class="link-item" onclick="setActive(this)" href="ChooseCourseInstructor.aspx" target="contentFrame">Choose Course Instructor</a></li>
            <li><a class="link-item" onclick="setActive(this)" href="CoursePrerequisites.aspx" target="contentFrame">Course Prerequisites</a></li>
            <li><a class="link-item" onclick="setActive(this)" href="CoursesSlotsInstructor.aspx" target="contentFrame">All Courses Slots</a></li>
            <li><a class="link-item" onclick="setActive(this)" href="RegisterForMakeupExam.aspx" target="contentFrame">Register For First Makeup Exam</a></li>
            <li><a class="link-item" onclick="setActive(this)" href="RegisterForSecondMakeupExam.aspx" target="contentFrame">Register For Second Makeup Exam</a></li>
            <li><a class="link-item" onclick="setActive(this)" href="student_gradplan_courses.aspx" target="contentFrame">Student Graduation Plan and Courses</a></li>
            <li><a class="link-item" onclick="setActive(this)" href="StudentInstallment.aspx" target="contentFrame">Upcoming Installments</a></li>
            <li><a class="link-item" onclick="setActive(this)" href="CoursesAndExams.aspx" target="contentFrame">Courses and Exams</a></li>
        </ul>
    </div>
    <div class="content">
        <h1>Welcome to Student Portal</h1>
        <iframe name="contentFrame" src="" frameborder="0"></iframe>
    </div>
</body>
</html>
