using System;
using System.IO;
using System.Text;

namespace MatasanoCryptoChallenges.Set1
{
    public class Challenge5
    {
        public static string RepeatingKeyXor(string key, string source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            var xorBytes = RepeatingKeyXor(Encoding.UTF8.GetBytes(key), Encoding.UTF8.GetBytes(source));
            return Challenge2.ToHex(xorBytes);
        }

        public static byte[] RepeatingKeyXor(byte[] key, byte[] source)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            var keyLength = key.Length;
            var result = new byte[source.Length];
            using (var sourceMs = new MemoryStream(source))
            {
                using (var destinationMs = new MemoryStream(result))
                {
                    var buffer = new byte[keyLength];
                    int read;

                    while ((read = sourceMs.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        byte[] keyBytesToUse;
                        byte[] bufferToUse;
                        if (read != keyLength)
                        {
                            keyBytesToUse = new byte[read];
                            Array.Copy(key, keyBytesToUse, read);
                            bufferToUse = new byte[read];
                            Array.Copy(buffer, bufferToUse, read);
                        }
                        else
                        {
                            keyBytesToUse = key;
                            bufferToUse = buffer;
                        }

                        var currentChunk = Challenge2.Xor(keyBytesToUse, bufferToUse);
                        destinationMs.Write(currentChunk, 0, read);
                    }
                }
            }
            return result;
        }
    }
}