namespace EalTools.Eal;

[Flags]
public enum EaxBufferFlags : uint
{
    DirectHfAuto = 0x00000001, // affects DSPROPERTY_EAXBUFFER_DIRECTHF
    RoomAuto =     0x00000002, // affects DSPROPERTY_EAXBUFFER_ROOM
    RoomHfAuto =   0x00000004, // affects DSPROPERTY_EAXBUFFER_ROOMHF
    Reserved =     0xFFFFFFF8, // reserved future use
}
