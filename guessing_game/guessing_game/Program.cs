using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guessing_game {
    class Program {
        static void Main( string[] args ) {
            Console.WriteLine( "Ma valin välja ühe suvalise numbri vahemikus [1 – 100]. \nProovi see ära arvata" );

            uint target = 54;

            Console.Write( "Sinu pakkumine: " );
            uint guess = uint.Parse( Console.ReadLine() );

            if ( guess > target ) {
                Console.WriteLine( "Minu number on väiksem" );
            }
            else if ( guess < target ) {
                Console.WriteLine( "Minu number on suurem" );
            }
            else if ( guess == target ) {
                Console.WriteLine( "Arvasid numbri ära" );
            }
        }
    }
}
