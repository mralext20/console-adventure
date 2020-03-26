using System.Collections.Generic;
using console_adventure.Interfaces;

namespace console_adventure.Models
{
  class Player : IPlayer
  {
    public string Name { get; set; }
    public List<IItem> Inventory { get; set; } = new List<IItem>();

    public Player(string name)
    {
      Name = name;
    }

  }
}