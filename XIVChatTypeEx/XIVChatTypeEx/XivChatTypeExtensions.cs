using Dalamud.Game.Text;

namespace XIVChatTools;

public static class XivChatTypeExtensions
{
    public static XivChannelDescriptor GetChannelDescriptor(this XivChatType chatType) => new(chatType);
}
