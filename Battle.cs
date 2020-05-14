using System;
using Unit;
using Skills;

namespace RPG
{
    class Battle
    {
        public void Blunt(Player player, Enemy enemy, bool playerIsAtaquer)
        {
            if (playerIsAtaquer)
            {
                enemy.TakeDamage(player.GetStrength(), Enemy.TypeOfResistance.blunt);
            }
            else
            {
                player.TakeDamage(enemy.GetStrength(), Player.TypeOfResistance.blunt);
            }
        }

        public void Slash(Player player, Enemy enemy, bool playerIsAtaquer)
        {
            if (playerIsAtaquer)
            {
                enemy.TakeDamage(player.GetStrength(), Enemy.TypeOfResistance.slashing);
            }
            else
            {
                player.TakeDamage(enemy.GetStrength(), Player.TypeOfResistance.slashing);
            }
        }

        public void FireI(Player player, Enemy enemy, bool playerIsAtaquer)
        {
            if (playerIsAtaquer)
            {
                enemy.TakeDamage(player.GetIntelligence(), Enemy.TypeOfResistance.fire);
            }
            else
            {
                player.TakeDamage(enemy.GetIntelligence(), Player.TypeOfResistance.fire);
            }
        }

        public void IceI(Player player, Enemy enemy, bool playerIsAtaquer)
        {
            if (playerIsAtaquer)
            {
                enemy.TakeDamage(player.GetIntelligence(), Enemy.TypeOfResistance.ice);
            }
            else
            {
                player.TakeDamage(enemy.GetIntelligence(), Player.TypeOfResistance.ice);
            }
        }

        public void WindI(Player player, Enemy enemy, bool playerIsAtaquer)
        {
            if (playerIsAtaquer)
            {
                enemy.TakeDamage(player.GetIntelligence(), Enemy.TypeOfResistance.wind);
            }
            else
            {
                player.TakeDamage(enemy.GetIntelligence(), Player.TypeOfResistance.wind);
            }
        }

        public void EarthI(Player player, Enemy enemy, bool playerIsAtaquer)
        {
            if (playerIsAtaquer)
            {
                enemy.TakeDamage(player.GetIntelligence(), Enemy.TypeOfResistance.earth);
            }
            else
            {
                player.TakeDamage(enemy.GetIntelligence(), Player.TypeOfResistance.earth);
            }
        }

        public void ShockI(Player player, Enemy enemy, bool playerIsAtaquer)
        {
            if (playerIsAtaquer)
            {
                enemy.TakeDamage(player.GetIntelligence(), Enemy.TypeOfResistance.shock);
            }
            else
            {
                player.TakeDamage(enemy.GetIntelligence(), Player.TypeOfResistance.shock);
            }
        }

        public void DarkI(Player player, Enemy enemy, bool playerIsAtaquer)
        {
            if (playerIsAtaquer)
            {
                enemy.TakeDamage(player.GetIntelligence(), Enemy.TypeOfResistance.dark);
            }
            else
            {
                player.TakeDamage(enemy.GetIntelligence(), Player.TypeOfResistance.dark);
            }
        }

        public void LightI(Player player, Enemy enemy, bool playerIsAtaquer)
        {
            if (playerIsAtaquer)
            {
                enemy.TakeDamage(player.GetIntelligence(), Enemy.TypeOfResistance.light);
            }
            else
            {
                player.TakeDamage(enemy.GetIntelligence(), Player.TypeOfResistance.light);
            }
        }

        public void AllMightyI(Player player, Enemy enemy, bool playerIsAtaquer)
        {
            if (playerIsAtaquer)
            {
                enemy.TakeDamage(player.GetIntelligence(), Enemy.TypeOfResistance.allMighty);
            }
            else
            {
                player.TakeDamage(enemy.GetIntelligence(), Player.TypeOfResistance.allMighty);
            }
        }

        static void Main(string[] args)
        {

        }
    }
}