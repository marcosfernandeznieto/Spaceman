using System;

namespace Spaceman
{
  class Program
  {
    static void Main(string[] args)
    {
      Game newGame = new Game();
      newGame.Greet();
      do {
        newGame.Display();
        newGame.Ask();
      } while ( !(newGame.DidWin() || newGame.DidLose()) );
      if (newGame.DidWin()) {
        Console.WriteLine("Congratulations!! You won this game!");
      } else {
        Console.WriteLine("Better luck next time.");
      }
    }
  }
}
