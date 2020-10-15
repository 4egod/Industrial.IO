//-----------------------------------------------------------------------
// <copyright file="Parity.cs" company="Reasol, LLC">
//     Copyright (c) Reasol, LLC. All rights reserved.
// </copyright>
// <author>Dmitry Tarasov</author>
//-----------------------------------------------------------------------
namespace Industrial.IO
{
    public enum Parity : byte
    {
        None = 0,
        Odd = 1,
        Even = 2,
        Mark = 3,
        Space = 4,
    }

    public static class ParityToString
    {
        /// <summary>
        /// Extension for Micro Framework
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToStringEx(this Parity value)
        {
            switch (value)
            {
                case Parity.None: return "N";
                case Parity.Odd: return "O";
                case Parity.Even: return "E";
                case Parity.Mark: return "M";
                case Parity.Space: return "S";
                default: return "N";
            }
        }
    }
}
