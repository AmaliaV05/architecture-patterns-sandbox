using AutoMapper;

namespace InventorySystem.Helpers
{
    public class Base64ToByteArrayConverter : IValueConverter<string, byte[]>
    {
        public byte[] Convert(string source, ResolutionContext context)
        {
            return string.IsNullOrEmpty(source) ? null : System.Convert.FromBase64String(source);
        }
    }
}
