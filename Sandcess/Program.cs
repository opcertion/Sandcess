
namespace Sandcess
{
	internal static class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			ApplicationConfiguration.Initialize();
			Application.Run(new MainWindow(args));
		}
	}
}