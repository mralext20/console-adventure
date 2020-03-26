namespace console_adventure.Models
{
  class EndRoom : Room
  {
    public bool IsWinning { get; set; }
    public string Narative { get; set; }
    public EndRoom(string name, string description, bool winning, string narative) : base(name, description)
    {
      IsWinning = winning;
      Narative = narative;
    }
  }
}