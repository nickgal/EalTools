using System;

namespace EalTools.Eal
{
    /// <summary>
    /// These flags determine what properties are affected by environment size.
    /// </summary>
    [Flags]
    public enum EaxListenerFlags : uint
    {
        None = 0,
        DecayTimeScale = 0x00000001, // reverberation decay time
        ReflectionsScale = 0x00000002, // reflection level
        ReflectionsDelayScale = 0x00000004, // initial reflection delay time
        ReverbScale = 0x00000008, // reflections level
        ReverbDelayScale = 0x00000010, // late reverberation delay time
        DecayHfLimit = 0x00000020, // limits high-frequency decay time according to air absorption.
        Reserved = 0xFFFFFFC0, // reserved future use
    }
}
