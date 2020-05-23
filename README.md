# Getting started with ASP.NET Core MVC Tutorial

In this tutorial we will look at how we can build web application using ASP.NET MVC framework.
Lets get started. We are following a tutorial that can be found [here](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-3.1&tabs=visual-studio).
We are using a older version of ASP.NET but the basics should be the same.

# Installation

You need Visual Studio to get up and running. Be sure to add the APSNET components when working with the
installer. Once you do this open Visual Studio and we can being create our application.

Click file and new and click new project.

[new_project.png]

Next lets select ASPNET Core Web Application.

[aspnet_create_application.png]

Now choose the MVC template and we should be good to go.

[asp_template.png]

Now Click on the IIS Express button to run our application.

[iis_express_button.png]

Now your application is started you can head to it via a broswer and view what it looks like.

If you see and SSL certificate warning you can click yes if you like to trust the SSL certificate.

[app_installed.png]


# Hello World

Lets create our basic hello world application. Head to Controllers folder and create a new function as shown below
inside the `HomeController.cs`.

```c#
public IActionResult HelloWorld()
{
    return Content("Helo World");
}
```

Now lets run our app and see the results.

[hello_world.png]

That is it. We have created our first hello world app.

## Hello World Advance

Instead of displaying text lets render some HTML. To do this we new to create a view.
In the `Views/Home` folder lets create a new view item.

[creating_a_new_view.png]

Our `HelloWorld.cshtml` is now created with the content below

```html

@{
    ViewData["Title"] = "HelloWorld";
}

<h2>HelloWorld</h2>
```

Lets add a description to the view.

```html
<p>My hello world view</p>
```

In our `HomeController.cs` lets return this view.


```c#
public IActionResult HelloWorld()
{
    return View();
}
```

Now we run the app to see the results.

[hello_world_view.png]


## Displaying a different view

Lets display a different view. First we create our different view layout file.
We call our view `AnotherView.cshtml` now in our `HomeController.cs` we want to display this view
when we go to our `helloworld` route. Lets see how we can do this.

```c#
public IActionResult HelloWorld()
{
    return View("AnotherView");
}
```

That is it. We can see the results below.

[another_view.png]

To learn more about the `View` function check out the documentation [here](https://docs.microsoft.com/en-us/dotnet/api/system.web.mvc.controller.view?view=aspnet-mvc-5.2#System_Web_Mvc_Controller_View_System_String_System_String_System_Object_).


# Routing

Routing is handled in `Startup.cs` as shown below.

```c#
app.UseMvc(routes =>
{
    routes.MapRoute(
        name: "default",
        template: "{controller=Home}/{action=Index}/{id?}");
});
```

This can be modified and edited but for now this is all we need to get started. Lets create some more routes.
Learn more about routing [here](https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-3.1).

## Creating a route via controllers

Lets create a new route via a controller. Head to the Controllers directory and add a new controller.
We created one called `DashboardController.cs`.

```c#
namespace AspnetMvcTutorial.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
```

We have an `Index` function pointing to our view. We can see this in the `Views` directory.

[dashboard_views.png]

Our view contains some basic html as shown below

```html

@{
    ViewData["Title"] = "Index";
}

<h2>Index</h2>

```

Let see it in action.

[dashboard_route.png]


## Another Route called help

Lets create a help route. In our `DashboardController.cs` we create a new route.

```c#
public IActionResult Help()
{
    return Content("help route");
}
```

Let see the results.

[help_route.png]

Above the layout is not rendered because we are not using a view.
Instead we use the `Content` function.

## Getting arguments from url route

Lets get arguments passed from the request route.
We create a new route called `page` in the `DashboardController.cs`.

```c#
public IActionResult Page(int id)
{
    return Content("Page is: " + id.ToString());
}
```

We show our results using the `Content` function based on the `id` if it exists. Let see the results.

If it exists we have

[get_url_parameter.png]

If it doesnt exists we get

[get_url_parameter_no_exists.png]

## More url arguments

Lets add more arguments and see what we can do. Lets update our `Page` function/route.

```c#
public IActionResult Page(int id, string location)
{
    string loc = Request.Query["location"];
    return Content("Page is: " + id.ToString() + "location is: " + loc);
}
```

Now we can either use `location` via the function argument or we can use `Request.Query` to get the location.
Whatever way we choose to go the results should be the same.

This is using location.

```c#
public IActionResult Page(int id, string location)
{
    string loc = Request.Query["location"];
    return Content("Page is: " + id.ToString() + " location is: " + location);
}
```

The results is shown below.

[multiple_arguments.png]

## Getting POST data via the routes

Lets send a POST request and get back the data.
In our `DashboardController.cs` we create a function called `Create()` as shown below.

```c#
[HttpPost]
public IActionResult Create()
{
    string name = Request.Form["name"];
    return Content("submitted for creationg: " + name);
}
```

So we can get form data using `Request.Form` collection.
Lets see the how the results work. We will be using POSTMAN to send the request.

[post_request.png]

## Redirections

Lets create some routes that we can redirect to.

```c#
public IActionResult Login()
{
    return Redirect("~/home/index");
}

public IActionResult Logout()
{
    return RedirectToAction("help");
}
```

Above we have two functions. One is called `login`. This will take you to the `home/index` page.
The second function uses the `RedirectToAction` function to send the user to the action in the controller called
`help`.

We can see this in action below.

[redirection_samples.gif]

# Working with views

Let check out what we can do with views.
Lets create a `home` view for our `DashboardController.cs`.

```html

@{
    ViewData["Title"] = "Home";
}

<h2>Home</h2>

```

So we have a default template. Lets see what else we can do.

## Passing data to your views

Lets see how we can pass data to our views.
We use `ViewData` to add the values we want to access in our views this is shown below.

```c#
public IActionResult Home()
{
    ViewData["description"] = "My home page description";
    ViewData["pageTitle"] = "This is My Home Page";
    return View();
}
```

We can see how we use this in our `Home.cshtml`.

```html

@{
    ViewData["Title"] = "Home";
}

<h2>@ViewData["pageTitle"]</h2>
<p>@ViewData["description"]</p>

```

Now we can view the results below.

[passing_data.png]

## Passing lists

Let see how we can pass lists to our views.

```c#
public IActionResult Home()
{
    List<String> list = new List<String>();
    list.Add("List item 1");
    list.Add("List item 2");
    list.Add("List item 3");
    ViewData["items"] = list;
    ViewData["description"] = "My home page description";
    ViewData["pageTitle"] = "This is My Home Page";
    return View();
}
```

In the `home` function:-

* Our `home` function creates a new `list`. 
* We add elements to this list.
* We add our list to `ViewData`. 

Then we can acess it in our view.

```html

@{
    ViewData["Title"] = "Home";
}

<h2>@ViewData["pageTitle"]</h2>
<p>@ViewData["description"]</p>

<ul>
    @foreach (var item in (List<String>)ViewData["items"])
    {
        <li>@item</li>
    }
</ul>

```

To display our items we had to cast `List<string>` on our `ViewData` items.

The results are shown below.

[list_items.png]

Another way we can do this is shown below.
We "intialize" `var items` in our view. Then we use it
as we need to.

```html

@{
    ViewData["Title"] = "Home";
}

@{ 

    var items = (List<String>)ViewData["items"];
}

<h2>@ViewData["pageTitle"]</h2>
<p>@ViewData["description"]</p>

<ul>
    @foreach (var item in @items)
    {
        <li>@item</li>
    }
</ul>
```


## Views Control Structures

Lets see how we can us `if` and `else` statements to show or hide html elements.
We will show the list if our value `show` exists.

We modify the Route function as shown below in `DashboardController.cs`.

```c#
public IActionResult Home()
{
    List<String> list = new List<String>();
    list.Add("List item 1");
    list.Add("List item 2");
    list.Add("List item 3");
    ViewData["items"] = list;
    ViewData["description"] = "My home page description";
    ViewData["pageTitle"] = "This is My Home Page";
    ViewData["show"] = false; // hide or show
    return View();
}
```

In the view we can check for this as shown below.

```html

@{
    ViewData["Title"] = "Home";
}

@{ 

    var items = (List<String>)ViewData["items"];
}

<h2>@ViewData["pageTitle"]</h2>
<p>@ViewData["description"]</p>

@if ((Boolean)ViewData["show"] == true)
{
<ul>
    @foreach (var item in @items)
    {
        <li>@item</li>
    }
</ul>
}

```

Our `@if` is how we check if our `show` variable exists.


# Working with Layouts

When we render a view we can see some menu items as shown below

[layout_menu.png]

This is accomplished by using layouts. Let create our own layout.
In our `Views/Shared` directoy we create a view called `main.cshtml`.

The content is shown below.

```html
<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>main</title>
</head>
<body>
    <ul style="display:block">
        <li style="display:inline;">Home</li>
        <li style="display:inline">Login</li>
    </ul>
    <div style="padding:10px; margin:0 auto; border: 1px solid #808080;">
        @RenderBody()
    </div>
</body>
</html>

```

We use `@RenderBody` to display the content we will be passing through this layout.

Now in our `Home.cshtml` we can change the layout for the view at the top of the file
as shown below.

```html
@{
    ViewData["Title"] = "Home";
    Layout = "~/Views/Shared/main.cshtml";
}
```

This should allow us to use the layout we just created as shown below.

[layout_template.png]

# Connecting to a database

To connect to a database we need to install a dependency because we will be working with a MySQL database.
Of course working with MS dataabase will be more straight forward.
Checek out this link [here](https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/database-first-development/creating-the-web-application)
to learn how.

We need to install a `NuGet` package to work with MySql as shown below.

[nuget_package.png]

Head to Project and manage `NuGet` dependencies and install `MySql.Data`.
Once you do this we can get started connecting to our databases.

We create a new route called `Users` in the `DashboardController.cs` it looks like

```c#

public IActionResult Users()
{
    List<String> emails = new List<String>();
    string connectionString = "server=localhost;user=root;password=;database=wftutorials";
    MySqlConnection conn = new MySqlConnection(connectionString);
    conn.Open();
    var command = new MySqlCommand("SELECT email FROM musers limit 10;", conn);
    var reader = command.ExecuteReader();
    while (reader.Read())
    {
        var value = reader.GetValue(0).ToString();
        emails.Add(value);
        // do something with 'value'
    }
    return View(emails);
}
```

Above we have a connection string which holds our connection information.
We create a new `MySqlConnection` object. We open the connection.
We then create a new `MySqlCommand` object and pass our query and the connection object.
We run the command using `command.ExecutedReader` and while we have data we add the `emails`
to a `string` list.

We then pass the emails to our View. 
Doing it this way allows us to set is as the model for the view.

In our view we can display our lists of emails as shown below.


```html

@{
    ViewData["Title"] = "Users";
}

@model List<String>;

<h2>Users</h2>

<ul>
    @foreach (var item in @Model)
    {
        <li>@item</li>
    }
</ul>

```

Using `@model List<String>` we define the type of our model.
Then we can use it using `@Model` the difference being common and capital letters.

The results is shown below.

[list_of_users.png]

## Using Models

To get started with models we have to do a few things. First I already have a database. So instead of doing
migrations I will have to work backwards and reverse engineer my models.

Lets download `Pomelo`. Using `NuGet` package manager.

[pomelo_framework.png]

Now we run the command below to create our models.


```bash
$ dotnet ef dbcontext scaffold "server=localhost;uid=root;pwd=;database=wftutorials" Pomelo.EntityFrameworkCore.MySql --schema wftutorials
```

My database is `wftutorials`. Yours could be whatever you like.

Once this is done we would have created models for all the tables in the database. Pay attention to this.

Most importantly we created a file called `wftutorialsContext.cs` this manages connections with my database.
Check out the full file [here](https://github.com/wftutorials/aspnetmvctutorial/blob/master/wftutorialsContext.cs).

Next in our `Startup.cs` we add our Context as a service.

```c#
services.AddDbContext<wftutorialsContext>(options =>
options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
```

In our `appsettings.json` we add our `DefaultConnection` string.

```json
"ConnectionStrings": {
"DefaultConnection": "server=localhost;user=root;password=;database=wftutorials"
}
```

Now we are almost complete. In our `DashboardController.cs` we create a new route called `Allusers`.

```c#
public IActionResult AllUsers()
{
    var users = _context.Musers;
    Console.Write(users);
    List<String> emails = new List<String>();
    foreach ( Musers u in users)
    {
        emails.Add(u.Email);
    }
    return View(emails);
}
```

We pass emails as the model so in the view we can loop through and display out list.

The results is has expected. Below we see our long list of users.

[long_list_users.png]

Our sample `Users` model can be seen [here](https://github.com/wftutorials/aspnetmvctutorial/blob/master/Musers.cs).

## Getting data using WHERE command

We can get data conditionally. Lets try using a `WHERE` query. Check out our route below.


```c#

public IActionResult UsersPlay()
{
    string output = "";
    var users = _context.Musers.Where(p => p.Gender == "Male");
    foreach(Musers u in users)
    {
        output += u.Email + " | " + u.Gender + "<br>";
    }
    Response.ContentType = "text/html";
    return Content("<html>" + output + "</html");
}
```

For this to work we need to make sure to add the code below

```c#
using System.Linq;
```

Lets pay attention to some things. We pull our data using

```c#
var users = _context.Musers.Where(p => p.Gender == "Male");
```

We only want the male genders. So we filtere for gender where gender is male.

We then apply a `foreach` loop to get our data.

Using `Response.ContentType = "text/html";` we can defined the content type
so that it displays as html instead of just text even though we are using
the `Content` function.

The results is shown below.

[list_users_male.png]

# Working with forms

Lets see how we can get working with forms.
In our Dashboard folders we create a new view called `CreateUser.cshtml`.
We add the content below. This is a basic html form with bootstrap styling.

```html

@{
    ViewData["Title"] = "CreateUser";
}

<h2>CreateUser</h2>

<form method="post" action="/dashboard/createuser">
    <div class="row">
        <div class="col-lg-6">
            <label>Firstname</label>
            <input name="firstname" type="text" class="form-control" placeholder="First name">
        </div>
        <div class="col-lg-6">
            <label>Lastname</label>
            <input name="lastname" type="text" class="form-control" placeholder="Last name">
        </div>
    </div>
    <div class="form-group">
        <label>Email address</label>
        <input name="email" type="email" class="form-control" placeholder="sample@gmail.com">
        <small class="form-text text-muted">We'll never share your email with anyone else.</small>
    </div>
    <div class="form-group">
        <label>IP address</label>
        <input name="ipaddress" type="text" class="form-control" placeholder="192.168.0.1">
    </div>
    <button type="submit" class="btn btn-primary">Submit</button>
</form>
```

In our `DashboardController` we create our route called `CreateUser`.

```c#
public IActionResult CreateUser()
{
	return View();
}
```

The output will be as shown

[create_user.png]

Now lets add the conditionals to deal with if the form is submitted.

First we use the `Request.Method` to confirm that it is a post request.
The we use `Request.Form` to get our data and we add it to our `output` string.
We then return using the `Content` function.

```c#
public IActionResult CreateUser()
{
    if (Request.Method == "POST")
    {
        String output = "Form submitted<br>";
        String firstname = Request.Form["firstname"];
        output += "Fistname: " + firstname + "<br>";
        String lastname = Request.Form["lastname"];
        output += "Lastname: " + lastname + "<br>";
        String email = Request.Form["email"];
        output += "Email: " + email + "</br>";
        String ipaddress = Request.Form["ipaddress"];
        output += "Ip Address: " + ipaddress + "</br>";
        Response.ContentType = "text/html";
        return Content("<html>" + output + "</html");
    }
    else
    {

        return View();
    }
}
     
}
```

We can see how this works below.

[form_submission.gif]

## Saving forms to models

Lets save our forms to a model. Update our `CreateUser` function to look like below.
We create our Model using the `new Musers()` model.
We then add our data from the `Request.Form`.
Then we add this model to `_context.Musers.Add()`.
We then save our changes using `_context.SaveChanges()`.

```c#
public IActionResult CreateUser()
{
    if (Request.Method == "POST")
    {
        String output = "Form submitted and saved successfully<br>";
        String firstname = Request.Form["firstname"];
        String lastname = Request.Form["lastname"];
        String email = Request.Form["email"];
        String ipaddress = Request.Form["ipaddress"];
        var model = new Musers();
        model.Firstname = firstname;
        model.Lastname = lastname;
        model.Email = email;
        model.Ipaddress = ipaddress;
        model.Gender = "male";
        _context.Musers.Add(model);
        _context.SaveChanges();
        Response.ContentType = "text/html";
        return Content("<html>" + output + "</html");
    }
    else
    {

        return View();
    }
}
```

We can see the updates in our database. 
Lets see the results below.

[create_user_model.png]

[user_saved_in_model.png]

# User authentication

Coming soon...


# Conclusion

Thank you for reading this tutorial. I hope it helped you.
Leave a comment and tell me what you think.
