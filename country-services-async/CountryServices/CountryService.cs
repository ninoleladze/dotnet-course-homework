using System.Net;
using System.Text.Json;

namespace CountryServices;

/// <summary>
/// Provides information about country local currency from RESTful API
/// <see><cref>https://restcountries.com/#api-endpoints-v2</cref></see>.
/// </summary>
public class CountryService : ICountryService
{
    private const string ServiceUrl = "https://restcountries.com/v2";

    private static readonly HttpClient HttpClient = new HttpClient();

    private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions()
    {
        PropertyNameCaseInsensitive = true,
    };

    private readonly Dictionary<string, WeakReference<LocalCurrency>> currencyCountries = new Dictionary<string, WeakReference<LocalCurrency>>();

    /// <summary>
    /// Gets information about currency by country code synchronously.
    /// </summary>
    /// <param name="alpha2Or3Code">ISO 3166-1 2-letter or 3-letter country code.</param>
    /// <returns>Information about country currency as <see cref="LocalCurrency"/>>.</returns>
    /// <exception cref="ArgumentException">Throw if countryCode is null, empty, whitespace or invalid country code.</exception>
    public LocalCurrency GetLocalCurrencyByAlpha2Or3Code(string? alpha2Or3Code)
    {
        ValidateAlphaCode(alpha2Or3Code);

        string code = alpha2Or3Code!.Trim();

        if (this.currencyCountries.TryGetValue(code, out var weakRef) &&
            weakRef.TryGetTarget(out var cached))
        {
            return cached;
        }

        string url = $"{ServiceUrl}/alpha/{code}";
        string json;

        try
        {
#pragma warning disable SYSLIB0014
            using var client = new WebClient();
            json = client.DownloadString(url);
#pragma warning restore SYSLIB0014
        }
        catch (WebException)
        {
            throw new ArgumentException($"Invalid or unknown country code: {alpha2Or3Code}", nameof(alpha2Or3Code));
        }

        var info = JsonSerializer.Deserialize<LocalCurrencyInfo>(json, JsonOptions)
            ?? throw new ArgumentException($"Invalid or unknown country code: {alpha2Or3Code}", nameof(alpha2Or3Code));

        var currency = MapToLocalCurrency(info);
        this.currencyCountries[code] = new WeakReference<LocalCurrency>(currency);
        return currency;
    }

    /// <summary>
    /// Gets information about currency by country code asynchronously.
    /// </summary>
    /// <param name="alpha2Or3Code">ISO 3166-1 2-letter or 3-letter country code.</param>
    /// <param name="token">Token for cancellation asynchronous operation.</param>
    /// <returns>Information about country currency as <see cref="LocalCurrency"/>>.</returns>
    /// <exception cref="ArgumentException">Throw if countryCode is null, empty, whitespace or invalid country code.</exception>
    public async Task<LocalCurrency> GetLocalCurrencyByAlpha2Or3CodeAsync(string? alpha2Or3Code, CancellationToken token)
    {
        ValidateAlphaCode(alpha2Or3Code);

        string code = alpha2Or3Code!.Trim();

        if (this.currencyCountries.TryGetValue(code, out var weakRef) &&
            weakRef.TryGetTarget(out var cached))
        {
            return cached;
        }

        var uri = new Uri($"{ServiceUrl}/alpha/{code}");
        HttpResponseMessage response;

        try
        {
            response = await HttpClient.GetAsync(uri, token);
        }
        catch (HttpRequestException)
        {
            throw new ArgumentException($"Invalid or unknown country code: {alpha2Or3Code}", nameof(alpha2Or3Code));
        }

        if (!response.IsSuccessStatusCode)
        {
            throw new ArgumentException($"Invalid or unknown country code: {alpha2Or3Code}", nameof(alpha2Or3Code));
        }

        string json = await response.Content.ReadAsStringAsync(token);
        var info = JsonSerializer.Deserialize<LocalCurrencyInfo>(json, JsonOptions)
            ?? throw new ArgumentException($"Invalid or unknown country code: {alpha2Or3Code}", nameof(alpha2Or3Code));

        var currency = MapToLocalCurrency(info);
        this.currencyCountries[code] = new WeakReference<LocalCurrency>(currency);
        return currency;
    }

    /// <summary>
    /// Gets information about the country by the country capital synchronously.
    /// </summary>
    /// <param name="capital">Capital name.</param>
    /// <returns>Information about the country as <see cref="Country"/>>.</returns>
    /// <exception cref="ArgumentException">Throw if the capital name is null, empty, whitespace or nonexistent.</exception>
    public Country GetCountryInfoByCapital(string? capital)
    {
        ValidateCapital(capital);

        string url = $"{ServiceUrl}/capital/{Uri.EscapeDataString(capital!.Trim())}";
        string json;

        try
        {
#pragma warning disable SYSLIB0014
            using var client = new WebClient();
            json = client.DownloadString(url);
#pragma warning restore SYSLIB0014
        }
        catch (WebException)
        {
            throw new ArgumentException($"Invalid or unknown capital: {capital}", nameof(capital));
        }

        var list = JsonSerializer.Deserialize<CountryInfo[]>(json, JsonOptions);
        var info = list?.FirstOrDefault()
            ?? throw new ArgumentException($"Invalid or unknown capital: {capital}", nameof(capital));

        return MapToCountry(info);
    }

    /// <summary>
    /// Gets information about the currency by the country capital asynchronously.
    /// </summary>
    /// <param name="capital">Capital name.</param>
    /// <param name="token">Token for cancellation asynchronous operation.</param>
    /// <returns>Information about the country as <see cref="Country"/>>.</returns>
    /// <exception cref="ArgumentException">Throw if the capital name is null, empty, whitespace or nonexistent.</exception>
    public async Task<Country> GetCountryInfoByCapitalAsync(string? capital, CancellationToken token)
    {
        ValidateCapital(capital);

        var uri = new Uri($"{ServiceUrl}/capital/{Uri.EscapeDataString(capital!.Trim())}");
        HttpResponseMessage response;

        try
        {
            response = await HttpClient.GetAsync(uri, token);
        }
        catch (HttpRequestException)
        {
            throw new ArgumentException($"Invalid or unknown capital: {capital}", nameof(capital));
        }

        if (!response.IsSuccessStatusCode)
        {
            throw new ArgumentException($"Invalid or unknown capital: {capital}", nameof(capital));
        }

        string json = await response.Content.ReadAsStringAsync(token);
        var list = JsonSerializer.Deserialize<CountryInfo[]>(json, JsonOptions);
        var info = list?.FirstOrDefault()
            ?? throw new ArgumentException($"Invalid or unknown capital: {capital}", nameof(capital));

        return MapToCountry(info);
    }

    private static LocalCurrency MapToLocalCurrency(LocalCurrencyInfo info)
    {
        var first = info.Currencies?.FirstOrDefault();
        return new LocalCurrency
        {
            CountryName = info.CountryName,
            CurrencyCode = first?.Code,
            CurrencySymbol = first?.Symbol,
        };
    }

    private static Country MapToCountry(CountryInfo info)
    {
        return new Country
        {
            Name = info.Name,
            CapitalName = info.CapitalName,
            Area = info.Area,
            Population = info.Population,
            Flag = info.Flag,
        };
    }

    private static void ValidateAlphaCode(string? code)
    {
        if (string.IsNullOrWhiteSpace(code))
        {
            throw new ArgumentException("Country code must not be null, empty, or whitespace.", nameof(code));
        }

        string trimmed = code.Trim();
        if (trimmed.Length < 2 || trimmed.Length > 3)
        {
            throw new ArgumentException("Country code must be 2 or 3 characters long.", nameof(code));
        }
    }

    private static void ValidateCapital(string? capital)
    {
        if (string.IsNullOrWhiteSpace(capital))
        {
            throw new ArgumentException("Capital name must not be null, empty, or whitespace.", nameof(capital));
        }
    }
}
