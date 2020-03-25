using console_adventure.Interfaces;

namespace console_adventure.Models
{
  class Game : IGame
  {
    public IPlayer CurrentPlayer { get; set; }
    public IRoom CurrentRoom { get; set; }
  }
}