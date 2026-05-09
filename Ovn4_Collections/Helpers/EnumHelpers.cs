using System.ComponentModel;

namespace Ovn4_Collections.Helpers;

public static class EnumHelpers
{
    public static string GetDescription<T>(T value) where T : Enum
    {
        var field = value.GetType().GetField(value.ToString());
        var attr = field?.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
        return attr?.FirstOrDefault()?.Description ?? value.ToString();
    }
}
