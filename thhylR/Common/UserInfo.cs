using System.Reflection;
using System.Text;

namespace thhylR.Common
{
	[Obfuscation(Exclude = false)]
	public static class UserInfo
    {
        public static List<InfoBlock> GetReplayInfoBlocks(byte[] replayData, int infoBlockStart)
        {
            var result = new List<InfoBlock>();
            int offset = infoBlockStart;
            while (offset <= replayData.Length - 12)
            {
                var blockLength = BitConverter.ToInt32(replayData, offset + 4);
                if (blockLength == 0)
                {
                    break;
                }
                if (offset + blockLength > replayData.Length)
                {
                    break;
                }
                if (blockLength >= 12)
                {
                    var infoBlock = new InfoBlock();
                    try
                    {
                        infoBlock.Marker = Encoding.ASCII.GetString(replayData[offset..(offset + 4)]);
                    }
                    catch
                    {
                        infoBlock.Marker = string.Empty;
                    }
                    infoBlock.Length = blockLength;
                    infoBlock.Id = BitConverter.ToInt32(replayData, offset + 8);
                    if (blockLength == 12)
                    {
                        infoBlock.Data = new byte[0];
                    }
                    else
                    {
                        infoBlock.Data = replayData[(offset + 12)..(offset + blockLength)];
                    }
                    result.Add(infoBlock);
                }
                offset += blockLength;
            }
            return result;
        }

        public static byte[] GetByteArray(InfoBlock infoBlock)
        {
            var result = new byte[infoBlock.Length];
            Encoding.ASCII.GetBytes(infoBlock.Marker).CopyTo(result, 0);
            BitConverter.GetBytes(infoBlock.Length).CopyTo(result, 4);
            BitConverter.GetBytes(infoBlock.Id).CopyTo(result, 8);
            infoBlock.Data.CopyTo(result, 12);
            return result;
        }

        public static string GetStringFromByteArray(int codePage, byte[] bytes)
        {
            Encoding encoding = Encoding.GetEncoding(codePage);
            var result = encoding.GetString(bytes);

            int endPos = result.IndexOf('\0');
            if (endPos == 0)
            {
                result = string.Empty;
            }
            else if (endPos != -1)
            {
                result = result[..endPos];
            }
            return result;
        }
    }

    public class InfoBlock
    {
        public string Marker { get; set; }
        public int Length { get; set; }
        public int Id { get; set; }
        public byte[] Data { get; set; }

        public enum UserBlockType
        {
            UserInfo = 0,
            Comment = 1
        }

        public InfoBlock()
        {

        }

        public InfoBlock(UserBlockType userBlockType, byte[] data)
        {
            Marker = "USER";
            BlockType = userBlockType;
            Data = data;
            Length = data.Length + 12;
        }

        public UserBlockType BlockType
        {
            get
            {
                return (UserBlockType)(Id & 0xFF);
            }
            set
            {
                Id = (int)value;
            }
        }

        public bool IsUserBlock
        {
            get
            {
                return Marker == "USER";
            }
        }
    }
}
