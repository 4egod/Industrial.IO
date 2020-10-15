//-----------------------------------------------------------------------
// <copyright file="Handshake.cs" company="Reasol, LLC">
//     Copyright (c) Reasol, LLC. All rights reserved.
// </copyright>
// <author>Dmitry Tarasov</author>
//-----------------------------------------------------------------------
namespace Industrial.IO
{
    public enum Handshake : byte
    {
#if MF
        None = 0,
        RequestToSend = 6,
        XOnXOff = 24,
#else
        None,
        XOnXOff,
        RequestToSend,
        RequestToSendXOnXOff
#endif
    }
}
