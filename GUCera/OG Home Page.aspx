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
            <li><a class="link-item" onclick="setActive(this)" href="Student/StudentLogin.aspx" target="contentFrame">Student</a></li>
            <li><a class="link-item" onclick="setActive(this)" href="Advisor/Login.aspx" target="contentFrame">Advisor</a></li>
            <li><a class="link-item" onclick="setActive(this)" href="Admin/AdminLogin.aspx" target="contentFrame">Admin</a></li>
            
        </ul>
    </div>
    <div class="content">
        <h1>German University in Cairo</h1>
        <iframe name="contentFrame"  frameborder="0"></iframe>
    </div>
</body>
</html>
