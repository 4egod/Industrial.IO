//-----------------------------------------------------------------------
// <copyright file="StopBits.cs" company="Reasol, LLC">
//     Copyright (c) Reasol, LLC. All rights reserved.
// </copyright>
// <author>Dmitry Tarasov</author>
//-----------------------------------------------------------------------
namespace Industrial.IO
{
    public enum StopBits : byte
    {
        None = 0,
        One = 1,
        Two = 2,
        OnePointFive = 3,
    }
}
