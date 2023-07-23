namespace WhoAreMyTeammates.Models
{
    public class WamtBroadcast
    {
        public bool IsEnabled { get; set; }

        public bool ClassChangeIsEnabled { get; set; }

        public string Contents { get; set; }

        public string AloneContents { get; set; }

        public string ChangeClassContents { get; set; }

        public int Delay { get; set; }

        public int MaxPlayers { get; set; }

        public DisplayType Type { get; set; }

        public ushort Time { get; set; }
    }
}