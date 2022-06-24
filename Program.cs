// See https://aka.ms/new-console-template for more information

using c1m1h1.Model;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("Game Start!");
var players = new List<Player> { new Human(), new Ai(), new Ai(), new Ai() };
var game = new Game(Deck.GetDeck(), players);
game.Start();