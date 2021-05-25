using System;
using System.Collections.Generic;
using System.Text;

namespace Encryption.Interface
{
    public interface IHMAC
    {
        byte[] ComputeMAC(byte[] message, byte[] salt);
        byte[] GenerateSalt(int lenght);
    }
}
