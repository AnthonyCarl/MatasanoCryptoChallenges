using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MatasanoCryptoChallenges.Set1
{
    public class Challenge1
    {
        private const int ByteChunkSize = 3;
        private const int Base64ChunkSize = 4;

        private const string HexadecimalFormatSpecifier = "X2";

        private const char Base64Pad = '=';

        private const byte SixMsbMask = 0xfc;

        private const byte TwoLsbMask = 0x03;

        private const byte FourMsbMask = 0xf0;

        private const byte FourLsbMask = 0x0f;

        private const byte TwoMsbMask = 0xc0;

        private const byte SixLsbMask = 0x3f;

        private static readonly char[] Base64Map = 
           {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O',
            'P','Q','R','S','T','U','V','W','X','Y','Z','a','b','c','d',
            'e','f','g','h','i','j','k','l','m','n','o','p','q','r','s',
            't','u','v','w','x','y','z','0','1','2','3','4','5','6','7',
            '8','9','+','/' };

        private static Dictionary<char, int> Base64CharValueMap =
            Base64Map.Select((c, i) => new KeyValuePair<char, int>(c, i)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

        private static readonly string[] HexMap =
            Enumerable.Range(0, byte.MaxValue + 1).Select(v => v.ToString(HexadecimalFormatSpecifier)).ToArray();

        public static string ByteHexToBase64(string hex)
        {
            var byteArray = ByteHexToByteArray(hex);
            //In case calling the framework Convert.ToBase64String() is considered "cheating"
            var base64 = ToBase64(byteArray);
            //var base64 = Convert.ToBase64String(byteArray);
            return base64;
        }

        public static byte[] ByteHexToByteArray(string hex)
        {
            if (hex == null)
            {
                throw new ArgumentNullException("hex");
            }

            if (hex.Length%2 != 0)
            {
                throw new ArgumentException("Hex string length must be an even number.");
            }

            var byteArray = new byte[hex.Length/2];

            using (var sr = new StringReader(hex))
            {
                var buffer = new char[2];

                for (int i = 0; i < byteArray.Length; i++)
                {
                    sr.Read(buffer, 0, 2);
                    //In case using the framework Convert.ToByte() is considered "cheating"
                    byteArray[i] = ToByte(buffer);
                    //byteArray[i] = Convert.ToByte(new string(buffer), 16);
                }
            }

            return byteArray;
        }

        //In case calling the framework Convert.ToBase64String() is considered cheating
        public static string ToBase64(byte[] bytes)
        {
            var leftoverBytes = bytes.Length%ByteChunkSize;
            var byteFullChunkLength = bytes.Length - leftoverBytes;
            var base64FullChunkLength = (bytes.Length/ByteChunkSize)*Base64ChunkSize;
            
            var sb = new StringBuilder(base64FullChunkLength + leftoverBytes != 0 ? Base64ChunkSize : 0);
          
            for (int i = 0; i < byteFullChunkLength; i += ByteChunkSize)
            {
                sb.Append(Base64Map[(bytes[i] & SixMsbMask) >> 2]);
                sb.Append(Base64Map[((bytes[i] & TwoLsbMask )<< 4) | ((bytes[i + 1] & FourMsbMask) >> 4)]);
                sb.Append(Base64Map[((bytes[i + 1] & FourLsbMask) << 2) | ((bytes[i + 2] & TwoMsbMask) >> 6)]);
                sb.Append(Base64Map[(bytes[i + 2] & SixLsbMask)]);
            }

            switch (leftoverBytes)
            {
                case 2:
                    sb.Append(Base64Map[(bytes[byteFullChunkLength] & SixMsbMask) >> 2]);
                    sb.Append(
                        Base64Map[
                            ((bytes[byteFullChunkLength] & TwoLsbMask) << 4) |
                            ((bytes[byteFullChunkLength + 1] & FourMsbMask) >> 4)]);
                    sb.Append(Base64Map[(bytes[byteFullChunkLength + 1] & FourLsbMask) << 2]);
                    sb.Append(Base64Pad);
                    break;
                case 1:
                    sb.Append(Base64Map[(bytes[byteFullChunkLength] & SixMsbMask) >> 2]);
                    sb.Append(Base64Map[(bytes[byteFullChunkLength] & TwoLsbMask) << 4]);
                    sb.Append(Base64Pad);
                    sb.Append(Base64Pad);
                    break;
            }
            
            return sb.ToString();
        }

        public static byte[] ToBytes(string base64encoded)
        {
            if (base64encoded == null)
            {
                throw new ArgumentNullException("base64encoded");
            }

            if (string.IsNullOrWhiteSpace(base64encoded))
            {
                return new byte[0];
            }

            var leftoverCharacters = base64encoded.Length%Base64ChunkSize;
            
            if (leftoverCharacters != 0)
            {
                throw new ArgumentException("Base64 length should be evenly divisible by " + Base64ChunkSize + ".");
            }

            return GetBytesFromCorrectLengthBase64(base64encoded.Trim());
        }

        private static byte[] GetBytesFromCorrectLengthBase64(string base64encoded)
        {
            var base64PadCharCount = base64encoded[base64encoded.Length - 1] == Base64Pad
                ? (base64encoded[base64encoded.Length - 2] == Base64Pad ? 2 : 1)
                : 0;
            var byteLength = ((base64encoded.Length / Base64ChunkSize) * ByteChunkSize) - base64PadCharCount;
            var bytes = new byte[byteLength];

            var byteFullChunkLength = base64encoded.Length - ((base64PadCharCount > 0 ? 1 : 0) * Base64ChunkSize);
            
            using (var ms = new MemoryStream(bytes))
            {
                for (int i = 0; i < byteFullChunkLength; i += Base64ChunkSize)
                {
                    ms.WriteByte(GetFirstByte(base64encoded, i));
                    ms.WriteByte(GetSecondByte(base64encoded, i));
                    ms.WriteByte(GetThirdByte(base64encoded, i));
                }
                switch (base64PadCharCount)
                {
                    case 1:
                        ms.WriteByte(GetFirstByte(base64encoded, byteFullChunkLength));
                        ms.WriteByte(GetSecondByte(base64encoded, byteFullChunkLength));
                        break;
                    case 2:
                        ms.WriteByte(GetFirstByte(base64encoded, byteFullChunkLength)); 
                        break;
                }
                return ms.ToArray();
            }
        }

        private static byte GetFirstByte(string base64encoded, int chunkOffset)
        {
            return
                (byte)
                    ((Base64CharValueMap[base64encoded[chunkOffset]] << 2) |
                     ((Base64CharValueMap[base64encoded[chunkOffset + 1]] >> 4)));
        }

        private static byte GetSecondByte(string base64encoded, int chunkOffset)
        {
            return
                (byte)
                    ((Base64CharValueMap[base64encoded[chunkOffset + 1]] << 4) |
                     (Base64CharValueMap[base64encoded[chunkOffset + 2]] >> 2));
        }

        private static byte GetThirdByte(string base64encoded, int chunkOffset)
        {
            return
                (byte)
                    ((Base64CharValueMap[base64encoded[chunkOffset + 2]] << 6) |
                     Base64CharValueMap[base64encoded[chunkOffset + 3]]);
        }

        //In case using the framework Convert.ToByte() is considered "cheating"
        public static byte ToByte(char[] twoHexCharsForSingleByte)
        {
            if (twoHexCharsForSingleByte == null)
            {
                throw new ArgumentNullException("twoHexCharsForSingleByte");
            }
            if (twoHexCharsForSingleByte.Length != 2)
            {
                throw new ArgumentOutOfRangeException("twoHexCharsForSingleByte", twoHexCharsForSingleByte.Length,
                    "The hex value for the byte must consist of exactly two characters.");
            }

            var byteValue = Array.IndexOf(HexMap, new string(twoHexCharsForSingleByte).ToUpperInvariant());
            if (byteValue == -1)
            {
                throw new ArgumentException("Unable to convert provided hex characters to a byte.");
            }
            return (byte)byteValue;
        }

        public static byte ToByte(char mostSignificant, char leastSignificant)
        {
            return ToByte(new[] {mostSignificant, leastSignificant});
        }
    }
}