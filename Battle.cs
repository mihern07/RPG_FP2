using System;
using Unit;
using System.IO;

namespace RPG
{
    class Battle
    {
        static Player player;
        static Enemy[] enemies;
        static String roundLog;
        static String damageLog;
        static bool HandleInput(string input)
        {
            bool canDo = false;
            if (input != "")
            {
                string[] separator = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                switch (separator[0])
                {
                    case "blunt":
                    case "Blunt":
                        try
                        {
                            int enemyNumber = SearchEnemy(separator[1]);
                            if (enemyNumber != -1)
                            {
                                Blunt(enemies[enemyNumber], true);
                                canDo = true;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Enemy not specified");
                        }
                        break;

                    case "slash":
                    case "Slash":
                        try
                        {
                            int enemyNumber = SearchEnemy(separator[1]);
                            if (enemyNumber != -1)
                            {
                                Slash(enemies[enemyNumber], true);
                                canDo = true;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Enemy not specified");
                        }
                        break;

                    case "fireI":
                    case "FireI":
                        try
                        {
                            int enemyNumber = SearchEnemy(separator[1]);
                            if (enemyNumber != -1)
                            {
                                FireI(enemies[enemyNumber], true);
                                canDo = true;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Enemy not specified");
                        }
                        break;

                    case "iceI":
                    case "IceI":
                        try
                        {
                            int enemyNumber = SearchEnemy(separator[1]);
                            if (enemyNumber != -1)
                            {
                                IceI(enemies[enemyNumber], true);
                                canDo = true;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Enemy not specified");
                        }
                        break;

                    case "windI":
                    case "WindI":
                        try
                        {
                            int enemyNumber = SearchEnemy(separator[1]);
                            if (enemyNumber != -1)
                            {
                                WindI(enemies[enemyNumber], true);
                                canDo = true;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Enemy not specified");
                        }
                        break;

                    case "earthI":
                    case "EarthI":
                        try
                        {
                            int enemyNumber = SearchEnemy(separator[1]);
                            if (enemyNumber != -1)
                            {
                                EarthI(enemies[enemyNumber], true);
                                canDo = true;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Enemy not specified");
                        }
                        break;

                    case "shockI":
                    case "ShockI":
                        try
                        {
                            int enemyNumber = SearchEnemy(separator[1]);
                            if (enemyNumber != -1)
                            {
                                ShockI(enemies[enemyNumber], true);
                                canDo = true;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Enemy not specified");
                        }
                        break;

                    case "darkI":
                    case "DarkI":
                        try
                        {
                            int enemyNumber = SearchEnemy(separator[1]);
                            if (enemyNumber != -1)
                            {
                                DarkI(enemies[enemyNumber], true);
                                canDo = true;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Enemy not specified");
                        }
                        break;

                    case "lightI":
                    case "LightI":
                        try
                        {
                            int enemyNumber = SearchEnemy(separator[1]);
                            if (enemyNumber != -1)
                            {
                                LightI(enemies[enemyNumber], true);
                                canDo = true;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Enemy not specified");
                        }
                        break;

                    case "allmightyI":
                    case "allMightyI":
                    case "AllMightyI":
                        try
                        {
                            int enemyNumber = SearchEnemy(separator[1]);
                            if (enemyNumber != -1)
                            {
                                AllMightyI(enemies[enemyNumber], true);
                                canDo = true;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Enemy not specified");
                        }
                        break;
                    case "help":
                    case "Help":
                        Console.WriteLine("blunt <TargetID>\nDeals blunt damage to selected target\n\n");
                        Console.WriteLine("slash <TargetID>\nDeals slashing damage to selected target\n\n");
                        Console.WriteLine("fireI <TargetID>\nDeals fire damage to selected target\n\n");
                        Console.WriteLine("iceI <TargetID>\nDeals ice damage to selected target\n\n");
                        Console.WriteLine("windI <TargetID>\nDeals wind damage to selected target\n\n");
                        Console.WriteLine("earthI <TargetID>\nDeals earth damage to selected target\n\n");
                        Console.WriteLine("shockI <TargetID>\nDeals shock damage to selected target\n\n");
                        Console.WriteLine("darkI <TargetID>\nDeals dark damage to selected target\n\n");
                        Console.WriteLine("lightI <TargetID>\nDeals light damage to selected target\n\n");
                        Console.WriteLine("allMightyI <TargetID>\nDeals allMighty damage to selected target.\n" +
                                          "AllMighty damage can't be blocked\n\n");
                        Console.WriteLine("help\nWrites this window\n\n");
                        canDo = false;
                        break;

                    default:
                        Console.WriteLine("Command not valid, type help for a list of valid commands");
                        break;
                }
            }
            
            
            return canDo;
        }

        static int SearchEnemy(string ID)
        {
            try
            {
                int contador = 0;
                while (contador < enemies.Length && !(ID == enemies[contador].GetID() + ""))
                {
                    contador++;
                }
                if (contador >= enemies.Length)
                {
                    throw new Exception("Specified enemy not found");
                }
                return contador;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }
        static void Blunt(Enemy enemy, bool playerIsAtaquer)
        {
            if (playerIsAtaquer)
            {
                enemy.TakeDamage(player.GetStrength(), Enemy.TypeOfResistance.blunt, out damageLog);
                roundLog += damageLog;
            }
            else
            {
                player.TakeDamage(enemy.GetStrength(), Player.TypeOfResistance.blunt, out damageLog);
                roundLog += damageLog;
            }
        }

        static void Slash(Enemy enemy, bool playerIsAtaquer)
        {
            if (playerIsAtaquer)
            {
                enemy.TakeDamage(player.GetStrength(), Enemy.TypeOfResistance.slashing, out damageLog);
                roundLog += damageLog;
            }
            else
            {
                player.TakeDamage(enemy.GetStrength(), Player.TypeOfResistance.slashing, out damageLog);
                roundLog += damageLog;
            }
        }

        static void FireI(Enemy enemy, bool playerIsAtaquer)
        {
            if (playerIsAtaquer)
            {
                enemy.TakeDamage(player.GetIntelligence(), Enemy.TypeOfResistance.fire, out damageLog);
                roundLog += damageLog;
            }
            else
            {
                player.TakeDamage(enemy.GetIntelligence(), Player.TypeOfResistance.fire, out damageLog);
                roundLog += damageLog;
            }
        }

        static void IceI(Enemy enemy, bool playerIsAtaquer)
        {
            if (playerIsAtaquer)
            {
                enemy.TakeDamage(player.GetIntelligence(), Enemy.TypeOfResistance.ice, out damageLog);
                roundLog += damageLog;
            }
            else
            {
                player.TakeDamage(enemy.GetIntelligence(), Player.TypeOfResistance.ice, out damageLog);
                roundLog += damageLog;
            }
        }

        static void WindI(Enemy enemy, bool playerIsAtaquer)
        {
            if (playerIsAtaquer)
            {
                enemy.TakeDamage(player.GetIntelligence(), Enemy.TypeOfResistance.wind, out damageLog);
                roundLog += damageLog;
            }
            else
            {
                player.TakeDamage(enemy.GetIntelligence(), Player.TypeOfResistance.wind, out damageLog);
                roundLog += damageLog;
            }
        }

        static void EarthI(Enemy enemy, bool playerIsAtaquer)
        {
            if (playerIsAtaquer)
            {
                enemy.TakeDamage(player.GetIntelligence(), Enemy.TypeOfResistance.earth, out damageLog);
                roundLog += damageLog;
            }
            else
            {
                player.TakeDamage(enemy.GetIntelligence(), Player.TypeOfResistance.earth, out damageLog);
                roundLog += damageLog;
            }
        }

        static void ShockI(Enemy enemy, bool playerIsAtaquer)
        {
            if (playerIsAtaquer)
            {
                enemy.TakeDamage(player.GetIntelligence(), Enemy.TypeOfResistance.shock, out damageLog);
                roundLog += damageLog;
            }
            else
            {
                player.TakeDamage(enemy.GetIntelligence(), Player.TypeOfResistance.shock, out damageLog);
                roundLog += damageLog;
            }
        }

        static void DarkI(Enemy enemy, bool playerIsAtaquer)
        {
            if (playerIsAtaquer)
            {
                enemy.TakeDamage(player.GetIntelligence(), Enemy.TypeOfResistance.dark, out damageLog);
                roundLog += damageLog;
            }
            else
            {
                player.TakeDamage(enemy.GetIntelligence(), Player.TypeOfResistance.dark, out damageLog);
                roundLog += damageLog;
            }
        }

        static void LightI(Enemy enemy, bool playerIsAtaquer)
        {
            if (playerIsAtaquer)
            {
                enemy.TakeDamage(player.GetIntelligence(), Enemy.TypeOfResistance.light, out damageLog);
                roundLog += damageLog;
            }
            else
            {
                player.TakeDamage(enemy.GetIntelligence(), Player.TypeOfResistance.light, out damageLog);
                roundLog += damageLog;
            }
        }

        static void AllMightyI(Enemy enemy, bool playerIsAtaquer)
        {
            if (playerIsAtaquer)
            {
                enemy.TakeDamage(player.GetIntelligence(), Enemy.TypeOfResistance.allMighty, out damageLog);
                roundLog += damageLog;
            }
            else
            {
                player.TakeDamage(enemy.GetIntelligence(), Player.TypeOfResistance.allMighty, out damageLog);
                roundLog += damageLog;
            }
        }

        /// <summary>
        /// Renderiza el estado actual del juego
        /// </summary>
        static void Render()
        {
            Console.Clear();

            //Dibujamos los enemigos
            Console.Write("      ");
            for (int i = 0; i < enemies.Length; i++)
            {
                Console.Write(enemies[i].GetID() + "          ");
            }
            Console.WriteLine();
            Console.Write("   ");
            for (int i = 0; i < enemies.Length; i++)
            {
                Console.Write(enemies[i].GetHP() + "/" + enemies[i].GetMaxHP() + "HP    ");
            }


            Console.WriteLine();
            Console.WriteLine();


            //Dibujamos al jugador
            Console.Write("      ");
            Console.Write(player.GetID());
            Console.WriteLine();
            Console.Write("   ");
            Console.Write(player.GetHP() + "/" + player.GetMaxHP() + "HP");
            Console.WriteLine();

            //Escribimos el log
            Console.WriteLine();
            Console.WriteLine(roundLog);
            Console.WriteLine();

            //Escribimos el prompt
            Console.Write(" > ");
        }

        static void ReadBattle(string battleFileName)
        {
            string tempLine;
            string[] splittedLine;

            string tempName = "";
            char tempID = ' ';
            int tempHP = 0;
            int tempStrength = 0;
            int tempIntelligence = 0;
            int tempPhysResistance = 0;
            int tempMagResistance = 0;
            int[] tempElemResistances = new int[10];
            tempElemResistances[9] = 0;

            //Leemos la batalla en cuestión
            StreamReader battle;
            battle = new StreamReader(battleFileName);

            int numberOfEnemies = int.Parse(battle.ReadLine());
            int currentEnemy = 0;
            enemies = new Enemy[numberOfEnemies];
            while (!battle.EndOfStream)
            {
                tempLine = battle.ReadLine();
                if (tempLine != "" && tempLine[0] != '/')
                {
                    splittedLine = tempLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (splittedLine[0] == "Player")
                    {
                        //Nos aseguramos de que las variables temporales están correctas
                        tempName = "";
                        tempID = ' ';
                        tempHP = 0;
                        tempStrength = 0;
                        tempIntelligence = 0;
                        tempPhysResistance = 0;
                        tempMagResistance = 0;
                        tempElemResistances[0] = 0;
                        tempElemResistances[1] = 0;
                        tempElemResistances[2] = 0;
                        tempElemResistances[3] = 0;
                        tempElemResistances[4] = 0;
                        tempElemResistances[5] = 0;
                        tempElemResistances[6] = 0;
                        tempElemResistances[7] = 0;
                        tempElemResistances[8] = 0;
                        tempElemResistances[9] = 0;

                        StreamReader playerFile;
                        playerFile = new StreamReader(splittedLine[1] + ".txt");
                        while (!playerFile.EndOfStream)
                        {
                            tempLine = playerFile.ReadLine();
                            if (tempLine != "" && tempLine != "Player" && tempLine[0] != '/')
                            {
                                splittedLine = tempLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                if (splittedLine[0] == "Name:")
                                {
                                    tempName = splittedLine[1];
                                }
                                else if (splittedLine[0] == "ID:")
                                {
                                    tempID = char.Parse(splittedLine[1]);
                                }
                                else if (splittedLine[0] == "HP:")
                                {
                                    tempHP = int.Parse(splittedLine[1]);
                                }
                                else if (splittedLine[0] == "Strength:")
                                {
                                    tempStrength = int.Parse(splittedLine[1]);
                                }
                                else if (splittedLine[0] == "Intelligence:")
                                {
                                    tempIntelligence = int.Parse(splittedLine[1]);
                                }
                                else if (splittedLine[0] == "PhysicalResistance:")
                                {
                                    tempPhysResistance = int.Parse(splittedLine[1]);
                                }
                                else if (splittedLine[0] == "MagicalResistance:")
                                {
                                    tempMagResistance = int.Parse(splittedLine[1]);
                                }
                                else if (splittedLine[0] == "Blunt:")
                                {
                                    tempElemResistances[0] = int.Parse(splittedLine[1]);
                                }
                                else if (splittedLine[0] == "Slashing:")
                                {
                                    tempElemResistances[1] = int.Parse(splittedLine[1]);
                                }
                                else if (splittedLine[0] == "Fire:")
                                {
                                    tempElemResistances[2] = int.Parse(splittedLine[1]);
                                }
                                else if (splittedLine[0] == "Ice:")
                                {
                                    tempElemResistances[3] = int.Parse(splittedLine[1]);
                                }
                                else if (splittedLine[0] == "Wind:")
                                {
                                    tempElemResistances[4] = int.Parse(splittedLine[1]);
                                }
                                else if (splittedLine[0] == "Earth:")
                                {
                                    tempElemResistances[5] = int.Parse(splittedLine[1]);
                                }
                                else if (splittedLine[0] == "Shock:")
                                {
                                    tempElemResistances[6] = int.Parse(splittedLine[1]);
                                }
                                else if (splittedLine[0] == "Dark:")
                                {
                                    tempElemResistances[7] = int.Parse(splittedLine[1]);
                                }
                                else if (splittedLine[0] == "Light:")
                                {
                                    tempElemResistances[8] = int.Parse(splittedLine[1]);
                                }
                            }
                        }
                        player = new Player(tempName, tempID, tempHP, tempStrength, tempIntelligence, tempPhysResistance, tempMagResistance, tempElemResistances);
                    }
                    else
                    {
                        StreamReader enemyFile;
                        enemyFile = new StreamReader(tempLine + ".txt");

                        while (!enemyFile.EndOfStream)
                        {
                            tempLine = enemyFile.ReadLine();
                            if (tempLine != "" && tempLine != "Enemy" && tempLine[0] != '/')
                            {
                                splittedLine = tempLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                if (splittedLine[0] == "Name:")
                                {
                                    tempName = splittedLine[1];
                                }
                                else if (splittedLine[0] == "ID:")
                                {
                                    tempID = char.Parse(splittedLine[1]);
                                }
                                else if (splittedLine[0] == "HP:")
                                {
                                    tempHP = int.Parse(splittedLine[1]);
                                }
                                else if (splittedLine[0] == "Strength:")
                                {
                                    tempStrength = int.Parse(splittedLine[1]);
                                }
                                else if (splittedLine[0] == "Intelligence:")
                                {
                                    tempIntelligence = int.Parse(splittedLine[1]);
                                }
                                else if (splittedLine[0] == "PhysicalResistance:")
                                {
                                    tempPhysResistance = int.Parse(splittedLine[1]);
                                }
                                else if (splittedLine[0] == "MagicalResistance:")
                                {
                                    tempMagResistance = int.Parse(splittedLine[1]);
                                }
                                else if (splittedLine[0] == "Blunt:")
                                {
                                    tempElemResistances[0] = int.Parse(splittedLine[1]);
                                }
                                else if (splittedLine[0] == "Slashing:")
                                {
                                    tempElemResistances[1] = int.Parse(splittedLine[1]);
                                }
                                else if (splittedLine[0] == "Fire:")
                                {
                                    tempElemResistances[2] = int.Parse(splittedLine[1]);
                                }
                                else if (splittedLine[0] == "Ice:")
                                {
                                    tempElemResistances[3] = int.Parse(splittedLine[1]);
                                }
                                else if (splittedLine[0] == "Wind:")
                                {
                                    tempElemResistances[4] = int.Parse(splittedLine[1]);
                                }
                                else if (splittedLine[0] == "Earth:")
                                {
                                    tempElemResistances[5] = int.Parse(splittedLine[1]);
                                }
                                else if (splittedLine[0] == "Shock:")
                                {
                                    tempElemResistances[6] = int.Parse(splittedLine[1]);
                                }
                                else if (splittedLine[0] == "Dark:")
                                {
                                    tempElemResistances[7] = int.Parse(splittedLine[1]);
                                }
                                else if (splittedLine[0] == "Light:")
                                {
                                    tempElemResistances[8] = int.Parse(splittedLine[1]);
                                }
                            }
                        }

                        enemies[currentEnemy] = new Enemy(tempName, tempID, tempHP, tempStrength, tempIntelligence, tempPhysResistance, tempMagResistance, tempElemResistances);
                        currentEnemy++;
                    }
                }
            }

            //Controlar excepciones
            
        }

        static bool enemiesAlive()
        {
            bool someoneIsAlive = false;
            for(int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].IsAlive())
                {
                    someoneIsAlive = true;
                }
            }
            return someoneIsAlive;
        }

        static void Main(string[] args)
        {
            roundLog = "";    //Aquí se registra todo lo sucedido en una ronda de combate
            string input;
            string battleName = "TestBattle.txt";

            ReadBattle(battleName);

            while (player.IsAlive() && enemiesAlive())
            {
                //Dibujado
                Render();

                roundLog = "";

                //Control del input
                input = Console.ReadLine();
                while (!HandleInput(input))
                {
                    Console.Write(" > ");
                    input = Console.ReadLine();
                }
            }
            if (!player.IsAlive())
            {
                roundLog += "You died, press Enter to quit the game";
                Render();
            }
            if (!enemiesAlive() && player.IsAlive())
            {
                roundLog += "You won! Thanks for playing this demo!\n Press Enter to quit the game";
                Render();
            }

            Console.ReadLine();
        }
    }
}