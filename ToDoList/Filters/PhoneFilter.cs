namespace ToDoList.Filters
{
    public class PhoneFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var Phone = context.GetArgument<string>(1);

            if (Phone == null || 
                Phone.Length != 11 || 
                Phone.All(c=>char.IsDigit(c)))  
                return Results.Problem
                    ("Invalide Phone ", statusCode: 400);

            return await next(context);
        }
    }
}
