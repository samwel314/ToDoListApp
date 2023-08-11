namespace ToDoList.Filters
{
    public class EmailFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var Email = context.GetArgument<string>(1);

            if (Email == null || !Email.Contains("@") || Email.Length > 55 )  
                return Results.Problem
                    ("Invalide Email ", statusCode: 400);

            return await next(context); 
        }
    }
}
