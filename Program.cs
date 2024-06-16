using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System.Text.Json.Serialization;

class Program
{
  private static readonly string AUTH_TOKEN; // Replace With Your Own Authorization Token From one of you request Headers
  private static readonly int TAB_COUNT = 10; // Replace with your value
  private static readonly int AVAILABLE_TAB_COUNT = 5; // Replace with your value
  private static readonly int SLEEP_TIME = 5000; // Replace with your value in milliseconds
  private static int CURRENT_N_COINS = 0;
  private static readonly HttpClient client = new HttpClient();
  private static readonly ILogger<Program> logger;

  static Program()
  {
    var loggerFactory = LoggerFactory.Create(builder =>
    {
      builder.AddConsole();
    });
    logger = loggerFactory.CreateLogger<Program>();
  }

  static async Task Main(string[] args)
  {
    while (true)
    {
      await SendRequest();
      Thread.Sleep(SLEEP_TIME);
    }
  }

  private static async Task SendRequest()
  {
    // Headers
    client.DefaultRequestHeaders.Clear();
    client.DefaultRequestHeaders.Add("Host", "api.hamsterkombat.io");
    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10.15; rv:125.0) Gecko/20100101 Firefox/125.0");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
    client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.5");
    client.DefaultRequestHeaders.Add("Referer", "https://hamsterkombat.io/");
    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {AUTH_TOKEN}");
    client.DefaultRequestHeaders.Add("Origin", "https://hamsterkombat.io");
    client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "empty");
    client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "cors");
    client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-site");
    client.DefaultRequestHeaders.Add("Connection", "close");

    // Data
    var payload = new
    {
      count = TAB_COUNT,
      availableTaps = AVAILABLE_TAB_COUNT,
      timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
    };

    try
    {
      var content = new StringContent(JsonSerializer.Serialize(payload), System.Text.Encoding.UTF8, "application/json");
      var response = await client.PostAsync("https://api.hamsterkombat.io/clicker/tap", content);

      response.EnsureSuccessStatusCode();
      var responseBody = await response.Content.ReadAsStringAsync();
      var info = JsonSerializer.Deserialize<ClickerResponse>(responseBody);

      int totalCoins = (int)info.ClickerUser.TotalCoins;
      int level = info.ClickerUser.Level;
      int availableTaps = info.ClickerUser.AvailableTaps;

      logger.LogInformation($"Total Coins: {totalCoins} (+{totalCoins - CURRENT_N_COINS}) | Level: {level} | Available Taps: {availableTaps} | Sleep: {SLEEP_TIME / 1000}s");

      // Update current N.coins
      CURRENT_N_COINS = totalCoins;
    } catch (Exception ex)
    {
      logger.LogError(ex, "Error occurred while sending request.");
    }
  }
}

