using System.Text.Json.Serialization;

public class ClickerResponse
{
  [JsonPropertyName("clickerUser")]
  public ClickerUser ClickerUser { get; set; }
}
public class ClickerUser
{
  [JsonPropertyName("id")]
  public string Id { get; set; }

  [JsonPropertyName("totalCoins")]
  public double TotalCoins { get; set; }

  [JsonPropertyName("balanceCoins")]
  public double BalanceCoins { get; set; }

  [JsonPropertyName("level")]
  public int Level { get; set; }

  [JsonPropertyName("availableTaps")]
  public int AvailableTaps { get; set; }

  [JsonPropertyName("lastSyncUpdate")]
  public long LastSyncUpdate { get; set; }

  [JsonPropertyName("exchangeId")]
  public string ExchangeId { get; set; }

  [JsonPropertyName("boosts")]
  public Dictionary<string, object> Boosts { get; set; }

  [JsonPropertyName("upgrades")]
  public Upgrades Upgrades { get; set; }

  [JsonPropertyName("tasks")]
  public Dictionary<string, object> Tasks { get; set; }

  [JsonPropertyName("airdropTasks")]
  public Dictionary<string, object> AirdropTasks { get; set; }

  [JsonPropertyName("referralsCount")]
  public int ReferralsCount { get; set; }

  [JsonPropertyName("maxTaps")]
  public int MaxTaps { get; set; }

  [JsonPropertyName("earnPerTap")]
  public double EarnPerTap { get; set; }

  [JsonPropertyName("earnPassivePerSec")]
  public double EarnPassivePerSec { get; set; }

  [JsonPropertyName("earnPassivePerHour")]
  public double EarnPassivePerHour { get; set; }

  [JsonPropertyName("lastPassiveEarn")]
  public double LastPassiveEarn { get; set; }

  [JsonPropertyName("tapsRecoverPerSec")]
  public double TapsRecoverPerSec { get; set; }

  [JsonPropertyName("referral")]
  public Referral Referral { get; set; }
}
public class Upgrades
{
  [JsonPropertyName("two_factor_authentication")]
  public UpgradeDetail TwoFactorAuthentication { get; set; }

  [JsonPropertyName("anonymous_transactions_ban")]
  public UpgradeDetail AnonymousTransactionsBan { get; set; }

  [JsonPropertyName("two_chairs")]
  public UpgradeDetail TwoChairs { get; set; }

  [JsonPropertyName("short_squeeze")]
  public UpgradeDetail ShortSqueeze { get; set; }

  [JsonPropertyName("notcoin_listing")]
  public UpgradeDetail NotcoinListing { get; set; }

  [JsonPropertyName("ceo_21m")]
  public UpgradeDetail Ceo21m { get; set; }

  [JsonPropertyName("licence_japan")]
  public UpgradeDetail LicenceJapan { get; set; }

  [JsonPropertyName("btc_pairs")]
  public UpgradeDetail BtcPairs { get; set; }

  [JsonPropertyName("premarket_launch")]
  public UpgradeDetail PremarketLaunch { get; set; }
}
public class UpgradeDetail
{
  [JsonPropertyName("id")]
  public string Id { get; set; }

  [JsonPropertyName("level")]
  public int Level { get; set; }

  [JsonPropertyName("lastUpgradeAt")]
  public long LastUpgradeAt { get; set; }

  [JsonPropertyName("snapshotReferralsCount")]
  public int SnapshotReferralsCount { get; set; }
}
public class Referral
{
  [JsonPropertyName("friend")]
  public Friend Friend { get; set; }
}
public class Friend
{
  [JsonPropertyName("isBot")]
  public bool IsBot { get; set; }

  [JsonPropertyName("firstName")]
  public string FirstName { get; set; }

  [JsonPropertyName("lastName")]
  public string LastName { get; set; }

  [JsonPropertyName("addedToAttachmentMenu")]
  public object AddedToAttachmentMenu { get; set; }

  [JsonPropertyName("id")]
  public int Id { get; set; }

  [JsonPropertyName("isPremium")]
  public object IsPremium { get; set; }

  [JsonPropertyName("canReadAllGroupMessages")]
  public object CanReadAllGroupMessages { get; set; }

  [JsonPropertyName("languageCode")]
  public string LanguageCode { get; set; }

  [JsonPropertyName("canJoinGroups")]
  public object CanJoinGroups { get; set; }

  [JsonPropertyName("supportsInlineQueries")]
  public object SupportsInlineQueries { get; set; }

  [JsonPropertyName("photos")]
  public List<object> Photos { get; set; }

  [JsonPropertyName("username")]
  public string Username { get; set; }

  [JsonPropertyName("welcomeBonusCoins")]
  public int WelcomeBonusCoins { get; set; }
}
