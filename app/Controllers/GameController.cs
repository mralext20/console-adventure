using System;
using console_adventure.Interfaces;
using console_adventure.Services;

namespace console_adventure.Controllers
{
  class GameController : IGameController
  {

    private GameService _gs { get; set; }
    private bool _running { get; set; } = true;
    public void Run()
    {
      System.Console.Write("What is your name?: ");
      _gs = new GameService(Console.ReadLine().Trim());
      _gs.Look();
      Print();
      while (_running)
      {
        GetUserInput();
        Print();
      }
    }
    public void GetUserInput()
    {
      Console.WriteLine("What would you like to do?");
      string input = Console.ReadLine().ToLower() + " ";
      string command = input.Substring(0, input.IndexOf(" ")); //go; take; look
      string option = input.Substring(input.IndexOf(" ") + 1).Trim();//north; toilet paper;

      switch (command)
      {
        case "quit":
          _running = false;
          break;
        case "reset":
          _gs.Reset();
          break;
        case "look":
          _gs.Look();
          break;
        case "inventory":
          _gs.Inventory();
          break;
        case "go":
          _running = _gs.Go(option);
          break;
        case "take":
          _gs.Take(option);
          break;
        case "use":
          _gs.Use(option);
          break;
        case "help":
          _gs.Help();
          break;
        default:
          _gs.Messages.Add("Not a recognized command");
          break;
      }
    }

    public void Print()
    {
      foreach (string message in _gs.Messages)
      {
        Console.WriteLine(message);
      }
      _gs.Messages.Clear();
    }
  }

}