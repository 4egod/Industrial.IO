using System;
using System.Text;
using System.Threading;

namespace Industrial.IO
{
    using _Handshake = System.IO.Ports.Handshake;
    using _Parity = System.IO.Ports.Parity;
    using _StopBits = System.IO.Ports.StopBits;

    public class SerialPort : System.IO.Ports.SerialPort, IPort
    {
        public SerialPort(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits, Handshake handshake)
            : base(portName, (int)baudRate, (_Parity)parity, (int)dataBits, (_StopBits)stopBits)
        {
            this.Handshake = (_Handshake)handshake;
        }

        public SerialPort(string portName, BaudRate baudRate, Parity parity, DataBits dataBits, StopBits stopBits, Handshake handshake)
            : base(portName, (int)baudRate, (_Parity)parity, (int)dataBits, (_StopBits)stopBits)
        {
            this.Handshake = (_Handshake)handshake;
        }

        public virtual PortTypes PortType
        {
            get { return PortTypes.SerialPort; }
        }

        public bool IsConnected
        {
            get
            {
                throw new InvalidOperationException();
            }
        }

        public void Connect()
        {
            base.Open();
        }

        public void Disconnect()
        {
            base.Close();
        }

#if MF
        public void Write(string text)
#else
        public new void Write(string text)
#endif
        {
            if (!this.IsOpen)
            {
                throw new InvalidOperationException();
            }

            if (text == null)
            {
                throw new ArgumentNullException();
            }

            if (text.Length != 0)
            {
                byte[] bytes = Encoding.UTF8.GetBytes(text);
                this.Write(bytes, 0, bytes.Length);
            }
        }

        public new int Read(byte[] buffer, int offset, int count)
        {
            // Fix when Readtimeout == -1 it's always throws _TimeoutException
            if (ReadTimeout == Timeout.Infinite)
            {
                return base.Read(buffer, offset, count);
            }

            for (int i = 0; i < (this.ReadTimeout); i++)
            {
                if (this.BytesToRead >= count)
                {
                    return base.Read(buffer, offset, count);
                }
                else
                {
                    Thread.Sleep(1);
                }
            }
            
            throw new TimeoutException();
        }

        public new void Write(byte[] buffer, int offset, int count)
        {
            base.Write(buffer, offset, count);
        }

#if !MF
        public void Flush()
        {
            base.DiscardInBuffer();
            base.DiscardOutBuffer();
        }
#else
        public new void Flush()
        {
            this.DiscardInBuffer();
            this.DiscardOutBuffer();
        }
#endif
    }
}
