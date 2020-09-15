# 20 09 15 Authentication CRUD

### Authorization Set Up
- Create an mvc application with authorization using `--auth individual`
- Add Microsoft.AspNetCore.MVC.Razor.RuntimeCompilation package and add to services
- Add a new mvc authorization policy to services and add required imports
```c#
services.AddMvc(obj =>
{
    AuthorizationPolicy policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});
```
- Run the application and attempt to register a new user and login

### Model
Book Model
- id : primary key
- title : required, must be under 100 characters
- author : required
- ISBN : must be a 9 digit number
- New York Times Best Seller : boolean
- Define unique display names and error messages for each field (except primary key)

### Controller
- Create a new Controller for all book endpoints 
- View All Books
- View a Book's Details
- Create a Book
    - endpoint to view form (protected)
    - endpoint to preform db create
- Update an Existing Book
    - endpoint to view form (protected)
    - endpoint to preform db update
- Delete a Book
    - endpoint to view page (protected)
    - endpoint to preform db delete 
- Test accessible endpoints in postman

### Views
- Update the start up file to route to the endpoint that displays all books by default
- Remove the Privacy Page navigation from the nav bar and add navigation for adding a book to nav bar
- View
    - Create a partial to display book properties
    - Create a view to display all books using a partial with a button to view details
    - Create a book details view that displays a books properties using a partial with a button to update and delete the book
- Create and Update
    - Create a partial to display the form fields required to create and update a book
    - Create a view that displays a model bound form using a partial submitting to the appropriate endpoint to create a book
    - Create a view that displays a model bound form using a partial submitting to the appropriate endpoint to update a book
- Create a view that displays a confirmation to delete a book
- Implement client side validation by adding required script files to `_Layout` file

### Styling
- Use bootstrap to style views
- Style validation messages to display in red text
- Style invalid form field to display with a red border