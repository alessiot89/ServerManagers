using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace ServerManagerTool.Plugin.Discord
{
    internal static class NetworkUtils
    {
        public static async Task<Version> CheckLatestVersionAsync(bool betaEnabled)
        {
            try
            {
                using (var webClient = new WebClient())
                {
                    string latestVersion = null;

                    if (betaEnabled)
                        latestVersion = await webClient.DownloadStringTaskAsync(Config.Default.LatestBetaVersionUrl);
                    else
                        latestVersion = await webClient.DownloadStringTaskAsync(Config.Default.LatestVersionUrl);

                    if (Version.TryParse(latestVersion, out Version version))
                        return version;

                    return new Version();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR: {nameof(CheckLatestVersionAsync)}\r\n{ex.Message}");
                return new Version();
            }
        }

        public static bool DownloadLatestVersion(string sourceUrl, string destinationFile)
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile(sourceUrl, destinationFile);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR: {nameof(DownloadLatestVersion)}\r\n{ex.Message}");
                return false;
            }
        }
    }
}
