using System;
using Unit;

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


                default:
                    Console.WriteLine("Command not valid, type help for a list of valid commands");
                    break;
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

        static void Main(string[] args)
        {
            
            enemies = new Enemy[3];
            roundLog = "";    //Aquí se registra todo lo sucedido en una ronda de combate
            String input;

            int[] tempResistances = new int[10];
            tempResistances[0] = 0;
            tempResistances[1] = 0;
            tempResistances[2] = 0;
            tempResistances[3] = 0;
            tempResistances[4] = 0;
            tempResistances[5] = 0;
            tempResistances[6] = 0;
            tempResistances[7] = 0;
            tempResistances[8] = 0;
            tempResistances[9] = 0;
            player = new Player("TestPlayer", 'P', 30, 8, 10, 2, 3, tempResistances);

            for (int i = 0; i < enemies.Length; i++)
            {
                tempResistances[0] = 0;
                tempResistances[1] = 0;
                tempResistances[2] = 0;
                tempResistances[3] = 0;
                tempResistances[4] = 0;
                tempResistances[5] = 0;
                tempResistances[6] = 0;
                tempResistances[7] = 0;
                tempResistances[8] = 0;
                tempResistances[9] = 0;
                enemies[i] = new Enemy("Enemy" + i, 'E', 60, 8, 6, 2, 3, tempResistances);
            }

            while (true)
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
            

            Console.ReadLine();
        }
    }
}