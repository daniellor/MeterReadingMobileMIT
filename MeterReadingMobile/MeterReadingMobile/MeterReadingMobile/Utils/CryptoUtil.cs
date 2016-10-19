using PCLCrypto;
using System;

using System.Text;

namespace MeterReadingMobile.Utils
{
    public static class CryptoUtil
    {
        public static string Sha1Hash(string text)
        {

            byte[] data = Encoding.UTF8.GetBytes(text); ;
            var hasher = WinRTCrypto.HashAlgorithmProvider.OpenAlgorithm(HashAlgorithm.Sha1);
            byte[] hash = hasher.HashData(data);
            return Convert.ToBase64String(hash);
        }
    }
}
