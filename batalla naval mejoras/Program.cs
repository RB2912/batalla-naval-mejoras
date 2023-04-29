// See https://aka.ms/new-console-template for more information
class Program
{
    static void Main(string[] args)
    {
        bool seguirJugando = true;
        while (seguirJugando)
        {
            int nivel = 1;
            int barcosPorNivel = 3;
            int[,] tablero = new int[5, 5];
            Random rnd = new Random();

            Console.WriteLine("¡Bienvenido al juego de batalla naval!");
            Console.WriteLine("Instrucciones:");
            Console.WriteLine("- El objetivo del juego es hundir los barcos enemigos.");
            Console.WriteLine("- Ingresa las coordenadas para atacar en el formato 'fila, columna'.");
            Console.WriteLine("- Cada turno, el tablero se actualizará para mostrar el resultado de tu ataque.");
            Console.WriteLine("- Los barcos ocupan una casilla en el tablero. Si aciertas en una casilla que contiene un barco, lo hundirás.");
            Console.WriteLine("- Tienes un total de {0} barcos enemigos para hundir en cada nivel. ¡Buena suerte!\n", barcosPorNivel);

            while (nivel <= 3) // juego de tres niveles
            {
                // Reiniciar el tablero
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        tablero[i, j] = 0;
                    }
                }

                // Colocar barcos aleatoriamente
                for (int i = 0; i < barcosPorNivel; i++)
                {
                    int fila = rnd.Next(5);
                    int col = rnd.Next(5);
                    tablero[fila, col] = 1;
                }

                // Mostrar el tablero inicial
                Console.WriteLine("Nivel {0}", nivel);
                Console.WriteLine("  | 1 2 3 4 5");
                Console.WriteLine("--+-----------");
                for (int i = 0; i < 5; i++)
                {
                    Console.Write((i + 1) + " |");
                    for (int j = 0; j < 5; j++)
                    {
                        Console.Write("- ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();

                // Juego
                int intentos = 0;
                int barcosHundidos = 0;
                while (barcosHundidos < barcosPorNivel)
                {
                    int fila, col;
                    do
                    {
                        Console.WriteLine("Ingresa las coordenadas para atacar:");
                        Console.Write("Fila (1-5): ");
                    } while (!int.TryParse(Console.ReadLine(), out fila) || fila < 1 || fila > 5);
                    fila--;

                    do
                    {
                        Console.Write("Columna (1-5): ");
                    } while (!int.TryParse(Console.ReadLine(), out col) || col < 1 || col > 5);
                    col--;

                    if (tablero[fila, col] == 1)
                    {
                        tablero[fila, col] = 2;
                        barcosHundidos++;
                        Console.WriteLine("¡Golpeaste un barco!");
                    }
                    else
                    {
                        tablero[fila, col] = -1;
                        Console.WriteLine("Fallaste.");
                    }
                    intentos++; Console.WriteLine("Intentos: {0}\n", intentos);    
                    
                    // Mostrar el tablero actualizado
                    Console.WriteLine("  | 1 2 3 4 5");
                    Console.WriteLine("--+-----------");
                    for (int i = 0; i < 5; i++)
                    {
                        Console.Write((i + 1) + " |");
                        for (int j = 0; j < 5; j++)
                        {
                            if (tablero[i, j] == 0)
                            {
                                Console.Write("- ");
                            }
                            else if (tablero[i, j] == 1)
                            {
                                Console.Write("- ");
                            }
                            else if (tablero[i, j] == 2)
                            {
                                Console.Write("X ");
                            }
                            else if (tablero[i, j] == -1)
                            {
                                Console.Write("O ");
                            }
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();

                    // Pasar al siguiente nivel o salir del juego
                    if (barcosHundidos == barcosPorNivel)
                    {
                        Console.WriteLine("¡Nivel {0} completado!", nivel);
                        if (nivel == 3)
                        {
                            Console.WriteLine("¡Felicidades, has ganado el juego!");
                            seguirJugando = false;
                        }
                        else
                        {
                            nivel++;
                            Console.WriteLine("¡Avanzando al nivel {0}!", nivel);
                        }
                    }
                    else if (intentos == 10)
                    {
                        Console.WriteLine("¡Has agotado tus intentos! Perdiste el nivel {0}.", nivel);
                        seguirJugando = false;
                    }
                }

                // Preguntar si desea jugar de nuevo
                Console.WriteLine("¿Desea jugar de nuevo? (s/n)");
                string respuesta = Console.ReadLine().ToLower();
                if (respuesta != "s" && respuesta != "si")
                {
                    seguirJugando = false;
                    Console.WriteLine("¡Gracias por jugar!");
                    Environment.Exit(0);
                }

            }
            Console.WriteLine("¡Gracias por jugar!");
        }
    }
}


