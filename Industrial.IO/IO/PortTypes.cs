//-----------------------------------------------------------------------
// <copyright file="PortTypes.cs" company="Reasol, LLC">
//     Copyright (c) Reasol, LLC. All rights reserved.
// </copyright>
// <author>Dmitry Tarasov</author>
//-----------------------------------------------------------------------
namespace Industrial.IO
{
    using System;

    [Flags]
    public enum PortTypes
    {
        Undefined = 0,

        SerialPort = 1 << 0,

        SerialModemPort = 1 << 1,

        CellularModemPort = 1 << 2,

        EthernetPort = 1 << 3,
    }
}
