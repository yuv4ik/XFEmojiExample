﻿using System;
using System.Text;

namespace XFEmojiExample
{
    public class Emoji
    {
        readonly int[] codes;

        public Emoji(int[] codes)
        {
            this.codes = codes;
        }

        public Emoji(int code)
        {
            codes = new int[] { code };
        }

        public override string ToString()
        {
            if (codes == null)
                return string.Empty;

            var sb = new StringBuilder(codes.Length);

            foreach (var code in codes)
                sb.Append(Char.ConvertFromUtf32(code));

            return sb.ToString();
        }
    }
}
