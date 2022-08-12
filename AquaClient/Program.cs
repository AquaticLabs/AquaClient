using AquaClient.View;
using AquaClient.View.Client;

namespace AquaClient;

static class Program
{
    
    public const string VERSION = "1.0.0",
        REPO_OWNER = "Aquatic-Labs",
        REPO_NAME = "N/A",
        REPO_URL = $"https://github.com/{REPO_OWNER}/{REPO_NAME}";
    
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        
        
        var background = new Background();
        var keyPresser = new DefaultClient(background);

        Application.Run(keyPresser);
    }
}