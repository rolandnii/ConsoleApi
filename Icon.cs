
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApiClient
{
	 class Icon
	{

		private string FileName { get; init; } = "Icons.json";
		public Icon() {  }

		public Icon(string fileName) => FileName = fileName;

		public List<IconHub> GetIcons()
		{
			try
			{
				var jsonIcons =  File.ReadAllText(FileName);
				List<IconHub> icons = JsonSerializer.Deserialize<List<IconHub>>(jsonIcons);
				return  icons ?? new();

			}
			catch (Exception ex) { 
				Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
				 
			}
			return new();

		}






	}
}
