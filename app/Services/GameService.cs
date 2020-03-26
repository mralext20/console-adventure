using System.Collections.Generic;
using console_adventure.Interfaces;
using console_adventure.Models;

namespace console_adventure.Services
{
  class GameService : IGameService
  {
    public List<string> Messages { get; set; } = new List<string>();
    private IPlayer _player { get; set; }
    private IGame _game { get; set; }
    public GameService(string playerName)
    {
      _player = new Player(playerName);
      _game = new Game();
    }


    public bool Go(string direction)
    {
      throw new System.NotImplementedException();
    }

    public void Help()
    {
      throw new System.NotImplementedException();
    }

    public void Inventory()
    {
      throw new System.NotImplementedException();
    }

    public void Look()
    {
      Messages.Add(_game.CurrentRoom.Description);
    }

    public void Reset()
    {
      throw new System.NotImplementedException();
    }

    public void Take(string itemName)
    {
      throw new System.NotImplementedException();
    }

    public void Use(string itemName)
    {
      throw new System.NotImplementedException();
    }
  }
}