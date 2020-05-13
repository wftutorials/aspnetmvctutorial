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

Lets display a different view. First we create our different view.
We call our view `AnotherView.cshtml` now in our `HomeController.cs` we want to display this view
when we in our `helloworld` route. Lets see how we can do this.

```c#
public IActionResult HelloWorld()
{
    return View("AnotherView");
}
```

That is it. We can see the results below.

[another_view.png]

To learn  more about the `View` function check out the documentation [here](https://docs.microsoft.com/en-us/dotnet/api/system.web.mvc.controller.view?view=aspnet-mvc-5.2#System_Web_Mvc_Controller_View_System_String_System_String_System_Object_).


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

This can be modified and edited but for now this is all we need to get started. Lets create more routes.
Learn more about routing [here](https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-3.1).

## Creating a route via controllers

Lets create a new route via a controller. Head to the Controllers direction and add a new controller.
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

We have and `Index` function pointing to our view. We can see this in the `Views` directory.

[dashboard_views.png]

How view as basic html

```html

@{
    ViewData["Title"] = "Index";
}

<h2>Index</h2>

```

Let see it in action.

[dashboard_route.png]


## Another Route

Lets create a help route. In our `DashboardController.cs` we create a new route.

```c#
public IActionResult Help()
{
    return Content("help route");
}
```

Let see the results.

[help_route.png]

Above the layout is rendered because we are not using a view.

## Getting arguments

Lets get arguments passed from the url path.
We create a `page` route in `DashboardController.cs`.

```c#
public IActionResult Page(int id)
{
    return Content("Page is: " + id.ToString());
}
```

We return the `Content` based on the `id` if it exists. Let see the results.

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

Now we can either use `location` via and argument. Or we can use `Request.Query` to get the location.
Which every way we choose to go the results should be the same.

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
In our `DashboardController.cs` you create a function called `create`.

```c#
[HttpPost]
public IActionResult Create()
{
    string name = Request.Form["name"];
    return Content("submitted for creationg: " + name);
}
```

So we can get from data using `Request.Form`.
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

Above we have to functions. One is called `login`. This will take you the the `home/index` page.
The second function uses `RedirectToAction` to send the user to the action in the controller called
`help`.

We can see this in action.

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
We use `ViewData` to add the values we want to access in our views.

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

Our `home` function creates a `new list`. We add elements to this list.
We add our list to `ViewData`. Then we can acess it in our view.

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

Another way we can do this is

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

Lets see how we can us `if` and `else` statements to show items.
We will show the list of our value `show` exists.

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

In the view we can check for this as shown beloww.

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