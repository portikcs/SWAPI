namespace SWAPIHelpers
{
    public interface IJsonConvertWrapper<T>
    {
        T Deserialize(string json);
    }
}