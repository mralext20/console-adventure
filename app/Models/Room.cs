
using System.Collections.Generic;
using console_adventure.Interfaces;

namespace console_adventure.Models
{
  class Room : IRoom
  {
    private string v;

    public string Name { get; set; }
    public string Description { get; set; }
    public List<IItem> Items { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }
    public Dictionary<IItem, KeyValuePair<string, IRoom>> LockedExits { get; set; }

    public void AddLockedRoom(IItem key, string direction, IRoom room)
    {
      var lockedRoom = new KeyValuePair<string, IRoom>(direction, room);
      LockedExits.Add(key, lockedRoom);
    }

    public string Use(IItem item)
    {
      if (LockedExits.ContainsKey(item))
      {
        Exits.Add(LockedExits[item].Key, LockedExits[item].Value);
        LockedExits.Remove(item);
        if (item.Name.ToLower() == "id card")
        {
          Description = "the TSA Agent is waiting for you to pass.";
          return "you show the TSA agent your ID Card and they let you through.";

        }
        if (item.Name.ToLower() == "pillow")
        {
          Description = "it is dark outside. the plane is landing soon. you gather your things and get ready to deplane.";
          return "you sleep like a rock.";
        }
        return "You have unlocked a room";
      }
      return "No use for that here";
    }

    public Room(string name, string description)
    {
      Name = name;
      Description = description;
      Items = new List<IItem>();
      Exits = new Dictionary<string, IRoom>();
      LockedExits = new Dictionary<IItem, KeyValuePair<string, IRoom>>();
    }

    public Room(string name, string description, string v) : this(name, description)
    {
      this.v = v;
    }
  }
}