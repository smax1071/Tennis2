using System.Reflection.Metadata.Ecma335;
using Tennis.Interface;
using Microsoft.Extensions.DependencyInjection;
namespace Tennis
{

    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection().AddSingleton<IPlayer>(p => new Player("Giocatore 1"))
                .AddSingleton<IPlayer>(p => new Player("Giocatore 2"))
                .AddSingleton<IScoreManger>(p => { var player=p.GetServices<IPlayer>().ToList();
                    return new ScoreManager(player[0], player[1]);
                }
                ).AddSingleton<Game>(p=> { var player1 = p.GetServices<IPlayer>().First(p=> p.Name== "Giocatore 1");
                    var player2 = p.GetServices<IPlayer>().First(p => p.Name == "Giocatore 2");
                    var scoreManager = p.GetRequiredService<IScoreManger>();
                    return new Game(player1, player2, scoreManager);    
                })
                .BuildServiceProvider();

            
            var game = services.GetService<Game>();
            game.PlayGame();
            
            

        }
    }
}
