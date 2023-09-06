namespace API.DTO
{
    public class ParticipantDTO
    {
        public int Assists { get; set; }
        public int Deaths { get; set; }
        public int Kills { get; set; }

        public int ChampionId { get; set; }
        public string ChampionName { get; set; }
        public int NexusLost { get; set; }
        public bool Win { get; set; }
    }
}