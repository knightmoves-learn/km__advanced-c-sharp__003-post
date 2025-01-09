# 003 Post

## Lecture

[![003 Post(Part 1)](https://img.youtube.com/vi/C9O1YqCKNcs/0.jpg)](https://www.youtube.com/watch?v=C9O1YqCKNcs)


## Instructions

In this assignment you will refactor add to a controller in an API meant to keep track of employees. This will draw on the example you saw of adding a Post method in the lesson.

In `EmployeeApi/Controllers/EmployeeController.cs`...
- Should contain an HTTP GET method
    - This method should return a list of `Employee`s
    - The list of `Employee`s being returned should be empty if no employees have been added.
    - The list of `Employee`s being returned should contain employees added through your HTTP POST method after POST requests have been made.
- Should contain an HTTP POST method
    - This method should accept an `Employee` in its body.
    - This method should add the `Employee` to a list which can be returned by your HTTP GET method afterwards.
    - This method should return the `Employee` being added.
- All methods should use the route `/Employee`

Additional Information:

- The `Employee` type is defined for you as a record in `EmployeeApi/Models/EmployeeModel.cs`, do not change this definition
- You should NOT change any code within the `TestsProj` directory

## Resources

- https://en.wikipedia.org/wiki/REST
- https://en.wikipedia.org/wiki/HTTP
- https://en.wikipedia.org/wiki/HTTP#Request_methods

## Building toward CSTA Standards

- Explain how abstractions hide the underlying implementation details of computing systems embedded in everyday objects (3A-CS-01) https://www.csteachers.org/page/standards
- Demonstrate code reuse by creating programming solutions using libraries and APIs (3B-AP-16) https://www.csteachers.org/page/standards

Copyright &copy; 2025 Knight Moves. All Rights Reserved.
