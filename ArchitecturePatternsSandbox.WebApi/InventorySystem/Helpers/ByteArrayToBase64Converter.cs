using AutoMapper;

namespace InventorySystem.Helpers
{
    public class ByteArrayToBase64Converter : IValueConverter<byte[], string>
    {
        public string Convert(byte[] source, ResolutionContext context)
        {
            return source == null ? null : System.Convert.ToBase64String(source);
        }
    }
}
