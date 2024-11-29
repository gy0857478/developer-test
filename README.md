# SchoolsBuddy Developer Test

The SchoolsBuddy developer coding test asks the candidate to develop a simple C# API and Angular website for evaluation by the development team and discussion in their interview.

Please do not add any features beyond what is defined in this document.

## Story
As the system user I would like to see active user's personal data in a table so that I may make management decisions. I would like to filter, order and search the data to help me make those decisions.

# Backend

A very simple backend project is included which contains all the data and data classes necessary to complete the API.

## Definition of Done
- An API with two endpoints. Please note the included `Backend.http` which has requests for both endpoints.
  1. `GET /api/users` - Get all users.
     - There is no need to support anything other than getting the full list of users
     - `UserDto` provides all necessary fields for the frontend. It should not need anything added or removed and paging support is NOT required
     - If no icon is defined on the user then provide the `unknown` icon
  2. `GET /api/icons/<iconname>` - Get a PNG icon by name
- Implement both `IUserService` and `IIconService` to access data from `Data/Users` and `Data/Icons` respectively. Use these with the endpoints definited above.
- `User` and `Friend` "entities" are for deserialisation of JSON files in `Data/Users` directory. These are to simulate a very rudimentary database.

## Restrictions
- Minimal API is recomended over using controllers to save time in implementation. However, feel free to use controllers if you want to.
- Use the included classes
- Do not use a database. Fetching the JSON files from the filesystem is perfectly adequate
- Use .NET 8 or later

# Frontend

## Definition of Done
- A table bound to the data from the users API
  - Showing the following columns
    - Icon from `/api/icons/<iconname>`
    - Name
    - Age
    - Registered Date, format `dd-mm-yyyy dd:mm:ss`
    - Email
    - Balance, format currency as pounds to 2 decimal places
  - Sorted by "Name" ascending by default
  - Paging is NOT required

- A "Search" input and label 
  - Typing in the search input filters the table results by “Name”
- A button named “Reset Balance” that sets all of users balances to zero and reflects this in the view.

## Restrictions
- Must use Angular (17 or later)
- Responsive grid - Please use `@ng-bootstrap`
- Use of `rxjs` or `Observable` when handling data paired them with Angular's `async pipe` is encouraged

Please do not spend more than a few hours on this as we're not looking for something polished but more your approach and ability to turn the spec into functioning software. If you'd like to publish it to GitHub we can pull this down from the office.
