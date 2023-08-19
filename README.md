# webapitest

a simple project to try to understand a problem in exception handling

run the app and navigate to http://localhost:5000/api/test

what you get is a message "Some Controller Exception", the problem is it's wrong as what you should get is a message "Filter Exception"

the controller has a OnActionExecutionAsync which in the first line calls

    await base.OnActionExecutionAsync(context, next);

this execute the code inside SomeFilter, which throws an error with message "Filter Exception". so far so good.

But, instead of going directly to exception middleware, the code returns to SomeController.OnActionExecutionAsync and it execute the next lines, which throws a new error ("Some Controller Exception").

This is intercepted by exception middleware and returned to the client.

The question is: why the first exception is ignored?