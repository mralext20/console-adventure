using console_adventure.Interfaces;

namespace console_adventure.Models
{
  class Game : IGame
  {
    public IPlayer CurrentPlayer { get; set; }
    public IRoom CurrentRoom { get; set; }

    ///<summary>Initalizes data and establishes relationships</summary>
    public Game()
    {
      // NOTE ALL THESE VARIABLES ARE REMOVED AT THE END OF THIS METHOD
      // We retain access to the objects due to the linked list


      // NOTE Create all rooms
      Room home = new Room("Home", "your current house. there is a desk with your important documents, and a packed suitcase. ");
      Room car = new Room("car", "a vehicle, someone is ready to take you to the airport.");
      Room airport = new Room("airport", "the airport. you arrive, and give the Airline Agent your bag.");
      Room tsaArea = new Room("TSA Area", "a high security area where you get screened. hope you have yuor ID Card handy");
      Room gateArea = new Room("Gate 2B", "a waiting area for a plane. the sign says 'Direct Flight to Alaska'");
      Room plane = new Room("a standard boeing 757", "you quickly find your seat. this is going to be a long plane ride... i think i packed a pillow!");
      Room anchorageAirport = new Room("anchorage International Airport", "you have landed! welcome to Alaska. your luggage is east of here.");
      Room aAirportLuggage = new EndRoom("Luggage Area", "luggagemachine go brrrrrr", true, "you find your luggage, and get out of the airport, time to get home\n\n To Be Continied...");

      Room mcDonalds = new EndRoom("McDonalds", "you go to order a big mac", false, "you have cought the CoronaVirus.");
      Room boiseFryCo = new EndRoom("Boise Fry Co", "you go to order a large plate of frys", false, "you have missed your flight.");

      // NOTE Create all Items
      Item idcard = new Item("ID Card", "Your ID Card. kinda important. ");
      Item ticket = new Item("Ticket", "describes the gate as 2B. ");
      Item pillow = new Item("Pillow", "could be usfil to pass the time.");

      // NOTE Make Room Relationships
      home.Exits.Add("east", car);
      car.Exits.Add("east", airport);
      airport.Exits.Add("west", tsaArea);
      airport.Exits.Add("south", boiseFryCo);
      tsaArea.Exits.Add("east", airport);
      tsaArea.AddLockedRoom(idcard, "west", gateArea);
      gateArea.Exits.Add("east", airport);
      gateArea.AddLockedRoom(ticket, "west", plane);
      plane.AddLockedRoom(pillow, "east", anchorageAirport);
      anchorageAirport.Exits.Add("south", mcDonalds);
      anchorageAirport.Exits.Add("east", aAirportLuggage);

      // NOTE put Items in Rooms
      home.Items.Add(idcard);
      airport.Items.Add(ticket);
      plane.Items.Add(pillow);

      CurrentRoom = home;
    }
  }
}