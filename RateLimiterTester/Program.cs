using System.Net.Http;

var client = new HttpClient();
var tasks = new List<Task>();

for (int i = 0; i < 50; i++)
{
    tasks.Add(Task.Run(async () =>
    {
        try
        {
            var response = await client.GetAsync("https://localhost:7244/api/School/GetAllSchools?pageNumber=1&pageSize=10");
            Console.WriteLine((int)response.StatusCode);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Request failed: " + ex.Message);
        }
    }));
}

await Task.WhenAll(tasks);

Console.WriteLine("Test Completed");
