using System.Net.Http.Json;
using Newtonsoft.Json;
using NutriSyncBackend.Models;

namespace NutriSyncIntegrationTests;

public class Tests
{
    private CustomWebApplicationFactory _factory;
    private HttpClient _client;
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Test");
        Environment.SetEnvironmentVariable("ASPNETCORE_ISSUERSIGNINGKEY", "PlaceholderSigningKey123");
        Environment.SetEnvironmentVariable("ASPNETCORE_VALIDAUDIENCE", "PlaceholderAudience");
        Environment.SetEnvironmentVariable("ASPNETCORE_VALIDISSUER", "PlaceholderIssuer");
        Environment.SetEnvironmentVariable("ASPNETCORE_ADMINEMAIL", "admin@admin.com");
        Environment.SetEnvironmentVariable("ASPNETCORE_ADMINPASSWORD", "Adminpassword123");
        _factory = new CustomWebApplicationFactory();
        _client = _factory.CreateClient();
    }
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _factory.Dispose();
        _client.Dispose();
    }
    [Test]
    public async Task ProductControllerCRUD()
    {
        try
        {
            var product = new Product
            {
                ProductId = 3,
                Description = "Legkomolyabb hely",
                Price = 25m,
                ProductName = "Pitbull",
                User = null
            };

            var createRes = await _client.PostAsync("Product/CreateProduct", JsonContent.Create(product));
            createRes.EnsureSuccessStatusCode();

            var getRes = await _client.GetAsync("Product/Get/3");
            getRes.EnsureSuccessStatusCode();

            var getResString = await getRes.Content.ReadAsStringAsync();
            var expectedProduct = JsonConvert.DeserializeObject<Product>(getResString);

            Assert.That(expectedProduct.ProductName, Is.EqualTo("Pitbull"));
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"HTTP request failed: {ex.Message}");
            throw; 
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"JSON serialization/deserialization failed: {ex.Message}");
            throw; 
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw;
        }
    }
}