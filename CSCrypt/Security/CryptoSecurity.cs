using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace CSCrypt.Security
{
    public class CryptoSecurity
    {
        [DllImport("Kernel32.dll", EntryPoint = "RtlZeroMemory", SetLastError = false)]
        static unsafe extern void ZeroMemory(IntPtr dest, IntPtr size);

        public byte[] GenerateRandomSalt(int saltLength)
        {
            byte[] bSalt = new byte[saltLength];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetNonZeroBytes(bSalt);
            }

            return bSalt;
        }

        public byte[] ClearByteArray(byte[] bArr)
        {
            byte[] zByteArr = bArr;
            Array.Clear(zByteArr, 0, zByteArr.Length);
            return zByteArr;
        }
    }
}
