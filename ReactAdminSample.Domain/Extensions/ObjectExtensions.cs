using System.Text.Json;

namespace ReactAdminSample.Domain.Extensions
{
    public static class ObjectExtensions
    {
        public static T DeepCopy<T>(this T self)
        {
            var serialized = JsonSerializer.Serialize(self);
#pragma warning disable CS8603 // Possible null reference return.
            return JsonSerializer.Deserialize<T>(serialized);
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
