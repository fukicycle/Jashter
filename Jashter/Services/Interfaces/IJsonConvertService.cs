namespace Jashter.Services.Interfaces
{
    public interface IJsonConvertService
    {
        T Deserialize<T>(string content);
        string Serialize<T>(T item);
    }
}
