using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guessing_game {
    class Program {
        static void Main( string[] args ) {
            Console.WriteLine( "Ma valin välja ühe suvalise numbri vahemikus [1 – 100]. \nProovi see ära arvata" );

            Random randGen = new System.Random();
            int target = randGen.Next( 1, 101 );

            int guess = 0;

            while ( true ) {
                Console.Write( "Sinu pakkumine: " );
                guess = int.Parse( Console.ReadLine() );

                if ( guess > target ) {
                    Console.WriteLine( "Minu number on väiksem" );
                }
                else if ( guess < target ) {
                    Console.WriteLine( "Minu number on suurem" );
                }
                else if ( guess == target ) {
                    Console.WriteLine( "Arvasid numbri ära" );
                    break;
                }
            }

            Console.ReadLine();
        }
    }
}
