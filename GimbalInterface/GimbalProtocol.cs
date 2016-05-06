using System;
using System.Text;
using System.IO;

namespace GimbalInterface
{
    public class GimbalProtocol : IGimbalInterface
    {
        private const int HEADER_SIZE = 2;

        private enum Id : byte
        {
            SetAngle = (byte)'A',
            SetMode = (byte)'M'
        }

        private Stream _stream;

        public GimbalProtocol(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream", "the stream cannot be null");
            }
            if (!stream.CanWrite)
            {
                throw new ArgumentException("The input stream must be writable!", "stream");
            }
            _stream = stream;
        }

        public void SetAngles(float pitch, float yaw)
        {
            // NOTE binary write writes as LE by default
            //using (var w = new BinaryWriter(_stream, Encoding.ASCII, true))
            //{
                var w = new BinaryWriter(_stream, Encoding.ASCII);
                w.Write((byte)Id.SetAngle);// id
                w.Write((byte)(sizeof(float) * 2));// size MAKE SURE TO CAST THIS IT NEEDS TO BE A BYTE NOT AN INT!!!
                w.Write(pitch);
                w.Write(yaw);
                w.Flush();
            //}
        }

        public void SetMode(GimbalMode mode)
        {
            //using (var w = new BinaryWriter(_stream, Encoding.ASCII, true))
            //{
                var w = new BinaryWriter(_stream, Encoding.ASCII);
                w.Write((byte)Id.SetMode);
                w.Write((byte)1);// the 1 byte for the mode
                w.Write((byte)mode);
                w.Flush();
            //}
        }
    }
}
