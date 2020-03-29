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
      if (_game.CurrentRoom.Exits.ContainsKey(direction.ToLower()))
      {
        _game.CurrentRoom = _game.CurrentRoom.Exits[direction.ToLower()];
        Look();
        if (_game.CurrentRoom is EndRoom)
        {
          var room = _game.CurrentRoom as EndRoom;
          Messages.Add(room.Narative);
          return false;
        }
      }
      return true;
    }

    public void Help()
    {
      Messages.Add("commands: Go, Help, Inventory, Look, Reset, Take, Use");
      if (_game.CurrentRoom.Exits.Keys.Count > 0)
      {

        string template = "exits to the ";
        foreach (string item in _game.CurrentRoom.Exits.Keys)
        {
          template += item;
        }
        Messages.Add(template);
      }
    }

    public void Inventory()
    {
      if (_player.Inventory.Count > 0)
      {

        Messages.Add("your inventory contains: ");
        foreach (var item in _player.Inventory)
        {
          Messages.Add($"{item.Name}: {item.Description}");
        }
      }
      else
      {
        Messages.Add("You have no items in your posession.");
      }
    }

    public void Look()
    {
      Messages.Add(_game.CurrentRoom.Description);
    }

    public void Reset()
    {
      string name = _player.Name;
      _player = new Player(name);
      _game = new Game();
    }

    public void Take(string itemName)
    {
      IItem item = _game.CurrentRoom.Items.Find(item => item.Name.ToLower() == itemName.ToLower());
      if (item is null)
      {
        Messages.Add($"Could not find anything like {itemName}");
        return;
      }
      _game.CurrentRoom.Items.Remove(item);
      _player.Inventory.Add(item);
      Messages.Add($"You picked up the {item.Name}");
    }

    public void Use(string itemName)
    {
      IItem item = _player.Inventory.Find(i => i.Name.ToLower() == itemName.ToLower());
      if (item is null)
      {
        Messages.Add($"you dont have an item thats called '{itemName}'");
        return;
      }
      Messages.Add(_game.CurrentRoom.Use(item));
    }
  }
}