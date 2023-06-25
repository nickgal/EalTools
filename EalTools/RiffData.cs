using System;

using EalTools.Riff;

namespace EalTools
{
    public abstract class RiffData
    {
        public string Version { get; private set; } = "Unknown";

        protected readonly RiffChunk _riffChunk;

        public RiffData(RiffChunk riffChunk)
        {
            _riffChunk = riffChunk ?? throw new ArgumentNullException(nameof(riffChunk));

            SetVersion();
        }

        private void SetVersion()
        {
            var majorVersion = _riffChunk.FindSubChunk<MajvChunk>()?.MajorVersion;
            var minorVersion = _riffChunk.FindSubChunk<MinvChunk>()?.MinorVersion;
            if (majorVersion != null && minorVersion != null)
            {
                Version = $"{majorVersion}.{minorVersion}";
            }
        }
    }
}
