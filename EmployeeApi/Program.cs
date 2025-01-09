var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();

app.Run();

//Do not remove anything below this comment, this is required to test your solution to the exercise
public partial class Program { }