namespace API.DTO
{
    public class InfoDTO
    {
        public long GameCreation { get; set; }
        public long GameDuration { get; set; }
        public long GameEndTimeStamp { get; set; }
        public long GameId { get; set; }
        public string GameMode { get; set; }
        public string GameName { get; set; }
        public string GameVersion { get; set; }
        public int MapId { get; set; }
        public List<ParticipantDTO> Participants { get; set; }
        public string PlatformId { get; set; }
        public int QueueId { get; set; }
        public string TournamentCode { get; set; }
    }
}