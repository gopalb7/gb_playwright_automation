public static class TestData
{
    public static string BaseUrl =>
        Environment.GetEnvironmentVariable("BASE_URL")
        ?? throw new Exception("BASE_URL not found in .env file");

    public static string Username =>
        Environment.GetEnvironmentVariable("USERNAME")
        ?? throw new Exception("USERNAME not found in .env file");

    public static string Password =>
        Environment.GetEnvironmentVariable("PASSWORD")
        ?? throw new Exception("PASSWORD not found in .env file");
}