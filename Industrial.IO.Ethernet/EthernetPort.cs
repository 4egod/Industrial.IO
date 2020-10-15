
namespace Industrial.IO
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    
    public class EthernetPort : IPort
    {
        private IPAddress _ip;
        private int _port;
        private Socket _socket;
        private bool _isConnected;

        public EthernetPort(string ip, int port, ProtocolType protocolType = ProtocolType.Tcp)
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, protocolType);
            _ip = IPAddress.Parse(ip);
            _port = port;
        }

#if NET40 || MF
        public bool IsOpen { get { throw new NotSupportedException(); } }

        public bool IsConnected
        {
            get
            {
                return _isConnected;
            }

            set
            {
                _isConnected = value;
            }
        }

        public PortTypes PortType { get { return PortTypes.EthernetPort; } }

        public int ReadTimeout { get { return _socket.ReceiveTimeout; } set { _socket.ReceiveTimeout = value; } }

        public int WriteTimeout { get { return _socket.SendTimeout; } set { _socket.SendTimeout = value; } }
#else
        public bool IsOpen => throw new NotSupportedException();
        public bool IsConnected => _isConnected;
        public PortTypes PortType => PortTypes.EthernetPort;
        public int ReadTimeout { get => _socket.ReceiveTimeout; set => _socket.ReceiveTimeout = value; }
        public int WriteTimeout { get => _socket.SendTimeout; set => _socket.SendTimeout = value; }
#endif


        public void Open()
        {
            throw new NotSupportedException();
        }

        public void Close()
        {
            throw new NotSupportedException();
        }

        public void Connect()
        {
            IPEndPoint remoteEP = new IPEndPoint(_ip, _port);
            _socket.Connect(remoteEP);
            _isConnected = true;
        }

        public void Disconnect()
        {
#if MF || TINYCLR
            _socket.Close();
#else
            _socket.Shutdown(SocketShutdown.Both);
#endif
            _isConnected = false;
        }

        public int Read(byte[] buffer, int offset, int length)
        {
            return _socket.Receive(buffer, offset, length, SocketFlags.None);
        }

        public void Write(byte[] buffer, int offset, int length)
        {
            _socket.Send(buffer, offset, length, SocketFlags.None);
        }

        public void Flush()
        {
            throw new NotImplementedException();
        }

#if !MF || !TINYCLR
        //public async Task ConnectAsync()
        //{
        //    IPEndPoint remoteEP = new IPEndPoint(_ip, _port);
        //    try
        //    {
        //        await _socket.ConnectAsync(remoteEP);
        //        _isConnected = true;
        //    }
        //    catch (Exception e)
        //    {
        //        _isConnected = false;
        //        throw e;
        //    }               
        //}

        //public async Task<int> ReadAsync(byte[] buffer, int offset, int length)
        //{
        //    SocketAsyncEventArgs e = new SocketAsyncEventArgs();
        //    e.SetBuffer(buffer, offset, length);
        //    return await _socket.ReceiveAsync((e, SocketFlags.None);
        //}

        //public async Task WriteAsync(byte[] buffer, int offset, int length)
        //{
        //    SocketAsyncEventArgs e = new SocketAsyncEventArgs();
        //    e.SetBuffer(buffer, offset, length);
        //    return await _socket.SendAsync(e, SocketFlags.None);
        //}
#endif
    }
}
