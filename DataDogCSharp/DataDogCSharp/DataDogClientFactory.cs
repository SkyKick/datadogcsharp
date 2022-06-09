namespace DataDogCSharp
{
    public interface IDataDogClientFactory
    {
        IDataDogClient Create(string apiKey, string url = "https://app.datadoghq.com/api/v1/series?api_key=");

    }
    public class DataDogClientFactory : IDataDogClientFactory
    {
        public IDataDogClient Create(string apiKey, string url = "https://app.datadoghq.com/api/v1/series?api_key=")
        {
            return new DataDogClient(apiKey, url);
        }
    }
}
