using System;

namespace Model.Extensions {
    public static class StringExtensions {
        public static string Reverse(this string text) {
            if (text == null) return null;
            var array = text.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
    }
}
