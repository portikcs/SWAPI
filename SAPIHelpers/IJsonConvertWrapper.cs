namespace SWAPIHelpers
{
    public interface IJsonConvertWrapper<out T>
    {
        T Deserialize(string json);
    }
}