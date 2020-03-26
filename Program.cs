using System;
using console_adventure.Controllers;

namespace console_adventure
{
  class Program
  {
    static void Main(string[] args)
    {
      GameController _gc = new GameController();
      _gc.Run();
    }
  }
}
