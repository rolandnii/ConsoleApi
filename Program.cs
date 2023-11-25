using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using WebApiClient;

Console.OutputEncoding = Encoding.UTF8;

using HttpClient client = new();
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(
	new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");



List<Repository> repositories = await ProcessRepositoriesAsync(client);

var Icon = new Icon();
Random random = new Random();
List<IconHub> icons = Icon.GetIcons();

Console.WriteLine($"{"",-3} {"Name",-20} | {"Homepage",-60} |");
foreach (Repository repo in repositories)
{
	var randomIndex = random.Next(icons.Count);
	Console.WriteLine($"{icons[randomIndex].Icon,-3} {repo.Name,-20} | {repo.Homepage,-60} |");

	Task.Delay(300).Wait();
	//Console.WriteLine($"GitHub: {repo.GitHubHomeUrl}");
	//Console.WriteLine($"Description: {repo.Description}");
	//Console.WriteLine($"Watchers: {repo.Watchers:#,0}");
	//Console.WriteLine(repo.LashPush);
}

static async Task<List<Repository>> ProcessRepositoriesAsync(HttpClient client)
{
	using Stream stream = await client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");

	var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(stream);

	return repositories ?? new();

}





