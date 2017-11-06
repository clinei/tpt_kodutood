/*
 Text-based RPG.
 Kasutajale kirjeldatakse olukorda ning pakutakse valikuid.
 Kasutaja sisestab oma valiku numbrina.
 Mängu eesmärk on põgeneda ruumist.

 BUGS:
 * Unhandled Exception mitte-numbri või mittemillegi sisestamisel
 * peidetud valikuid saab kasutada
 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_choice_game {
    class Program {
        static void Main( string[] args ) {
            int mode = 0;
            int mode0Stage = 0;
            int mode1Stage = 0;
            bool lightBulbTaken = false;
            bool inventoryHasLightbulb = false;
            bool desklampHasLightbulb = false;
            bool isLightOn = false;
            bool lockOpen = false;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            while ( true ) {
                Console.ForegroundColor = ConsoleColor.Gray;
                if ( mode == 0 ) {
                    if ( mode0Stage == 0 ) {
                        Console.WriteLine( "      Ärkad pimedas ruumis ja ei mäleta kuidas sa siia sattusid." );
                        mode0Stage = 1;
                    }
                    else {
                        Console.WriteLine( "      Seisad toa keskel." );
                    }
                    Console.WriteLine();
                    Console.WriteLine( "      Mida teed?" );
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine( "      1) Vaatan ringi" );
                    if ( mode0Stage == 2 ) {
                        Console.WriteLine( "      2) Lähen kirjutuslaua juurde" );
                        Console.WriteLine( "      3) Ronin redelist üles" );
                    }
                    Console.WriteLine();
                    Console.Write( "    : " );
                    int response = int.Parse( Console.ReadLine() );
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    if ( response == 1 ) {
                        if ( mode0Stage == 1 ) {
                            Console.WriteLine( "      Su silmad harjuvad pimedusega ning märkad keset tuba" );
                            Console.WriteLine( "      sirget, maast laeni redelit, mis viib katuseluugini." );
                            Console.WriteLine();
                            Console.WriteLine( "      Peale selle on toas veel kirjutuslaud, " );
                            Console.WriteLine( "      mille peal seisab laualamp." );
                            mode0Stage = 2;
                        }
                        else {
                            if ( !isLightOn ) {
                                Console.WriteLine( "      Keset tuba on redel, mis viib laes oleva katuseluugini. " );
                                Console.WriteLine( "      Seina ääres on kirjutuslaud laualambiga." );
                            }
                            else {
                                Console.WriteLine( "      Keset tuba on redel, mis viib laes oleva katuseluugini. \nSeina ääres on kirjutuslaud laualambiga, \nmille violetne kuma muudab nähtavaks laual oleva numbrikombinatsiooni: 1182" );
                            }
                        }
                    }
                    else if ( response == 2 ) {
                        mode = 1;
                    }
                    else if ( response == 3 ) {
                        mode = 2;
                    }
                }
                else if ( mode == 1 ) {
                    Console.WriteLine( "      Oled kirjutuslaua juures. " );
                    Console.WriteLine( "      Selle peal seisab laualamp. " );
                    Console.WriteLine( "      Laual on ka sahtlid." );
                    Console.WriteLine();
                    Console.WriteLine( "      Mida teed?" );
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine( "      1) Vaatan sahtlitesse" );
                    Console.WriteLine( "      2) Vajutan lambi lülitit" );
                    if ( inventoryHasLightbulb ) {
                        Console.WriteLine( "      3) Keeran lambipirni sisse" );
                    }
                    else if ( !desklampHasLightbulb ) {
                        Console.WriteLine( "      3) Vaatan laualampi lähemalt" );
                    }
                    else {
                        Console.WriteLine();
                    }
                    Console.WriteLine( "      4) Lähen tagasi" );

                    Console.WriteLine();
                    Console.Write( "    : " );
                    int response = int.Parse( Console.ReadLine() );
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    if ( response == 1 ) {
                        if ( !lightBulbTaken ) {
                            Console.WriteLine( "      Leidsid sahtlitest kummalise kujuga lambipirni ja pistad selle tasku." );
                            lightBulbTaken = true;
                            inventoryHasLightbulb = true;
                        }
                        else {
                            Console.WriteLine( "      Sahtlites pole enam midagi." );
                        }
                    }
                    else if ( response == 2 ) {
                        if ( desklampHasLightbulb ) {
                            Console.WriteLine( "      Lamp plõksab põlema ning selle ultravioletne kuma muudab nähtavaks " );
                            Console.WriteLine( "      laual oleva numbri: 1182" );
                            isLightOn = true;
                        }
                        else {
                            Console.WriteLine( "      Vajutad lülitit, kuid midagi ei juhtu." );
                        }
                    }
                    else if ( response == 3 ) {
                        if ( inventoryHasLightbulb ) {
                            Console.WriteLine( "      Keerad laualambile pirni sisse." );
                            inventoryHasLightbulb = false;
                            desklampHasLightbulb = true;
                        }
                        else {
                            Console.WriteLine( "      Laualambil pole pirni sees." );
                        }
                    }
                    else if ( response == 4 ) {
                        mode = 0;
                    }
                }
                else if ( mode == 2 ) {
                    Console.WriteLine( "      Oled redelil. " );
                    if ( !lockOpen ) {
                        Console.WriteLine( "      Su ees on luuk, mida hoiab kinni " );
                        Console.WriteLine( "      nelja numbriga kombinatsioonilukk." );
                    } else {
                        Console.WriteLine( "      Su ees on lukuta luuk." );
                    }
                    Console.WriteLine();
                    Console.WriteLine( "      Mida teed?" );
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    if ( !lockOpen ) {
                        Console.WriteLine( "      1) Proovin numbrikombinatsiooni" );
                    } else {
                        Console.WriteLine();
                    }
                    Console.WriteLine( "      2) Lähen tagasi" );
                    if ( lockOpen ) {
                        Console.WriteLine( "      3) Teen luugi lahti" );
                    }
                    Console.WriteLine();
                    Console.Write( "    : " );
                    int response = int.Parse( Console.ReadLine() );
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    if ( response == 1 ) {
                        Console.Write( "    Kombinatsioon: " );
                        int response2 = int.Parse( Console.ReadLine() );
                        if ( response2 == 1182 ) {
                            Console.WriteLine();
                            Console.WriteLine( "      Klik! Ja lukk on lahti." );
                            lockOpen = true;
                        }
                        else {
                            Console.WriteLine( "      Lukk on endiselt kinni." );
                        }
                    }
                    else if ( response == 2 ) {
                        mode = 0;
                    }
                    else if ( response == 3 ) {
                        Console.WriteLine( "      Sa lükkad lahti raske raudluugi ning lased värskel õhul oma kopsudesse voolata. " );
                        Console.WriteLine( "      Sa naeratad, ronid välja ning lased luugil kõva pauguga kinni minna. " );
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine( "             The End" );
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        break;
                    }
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine( "    :" );
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write( "Press any key to continue..." );
            Console.ReadLine();
        }
    }
}
