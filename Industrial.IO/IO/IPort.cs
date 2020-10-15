//-----------------------------------------------------------------------
// <copyright file="IPort.cs" company="Reasol, LLC">
//     Copyright (c) Reasol, LLC. All rights reserved.
// </copyright>
// <author>Dmitry Tarasov</author>
//-----------------------------------------------------------------------
namespace Industrial.IO
{
#if !MF || TINYCLR
    using System.Threading.Tasks;
#endif

    public interface IPort
    {
        bool IsConnected { get; }

        PortTypes PortType { get; }

        int ReadTimeout { get; set; }

        int WriteTimeout { get; set; }

        void Connect();

        void Disconnect();

        void Flush();

        int Read(byte[] buffer, int offset, int length);

        void Write(byte[] buffer, int offset, int length);

#if !MF || TINYCLR
        //Task ConnectAsync();

        //Task<int> ReadAsync(byte[] buffer, int offset, int length);

        //Task WriteAsync(byte[] buffer, int offset, int length);
#endif
    }
}
