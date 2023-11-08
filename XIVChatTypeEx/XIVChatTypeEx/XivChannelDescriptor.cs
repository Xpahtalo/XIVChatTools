using Dalamud.Game.Text;

namespace XIVChatTools;

public readonly record struct XivChannelDescriptor(Group Source, Group Target, Channel Channel)
{
    public XivChannelDescriptor(XivChatType chatType)
        : this(GetSourceGroup(chatType), GetTargetGroup(chatType), GetChannel(chatType)) { }

    public XivChannelDescriptor(uint magic)
        : this(GetSourceGroup(magic), GetTargetGroup(magic), GetChannel(magic)) { }

    internal static uint GetSourceId(uint magic) => magic >> 11;

    internal static uint GetTargetId(uint magic) => (magic >> 7) & 0xF;

    internal static uint GetChannelId(uint magic) => magic & 0x007F;

    public static Group GetSourceGroup(uint magic) => (Group)GetSourceId(magic);

    public static Group GetTargetGroup(uint magic) => (Group)GetTargetId(magic);

    public static Channel GetChannel(uint magic) => (Channel)GetChannelId(magic);

    public static Group GetSourceGroup(XivChatType chatType) => GetSourceGroup((uint)chatType);

    public static Group GetTargetGroup(XivChatType chatType) => GetTargetGroup((uint)chatType);

    public static Channel GetChannel(XivChatType chatType) => GetChannel((uint)chatType);
}
