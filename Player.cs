using System;

namespace Unit
{
    class Player
    {
        string name;    //Nombre de la unidad
        char ID;    //Representación en pantalla
        int hp;
        int maxHP;
        bool alive; //Indica si el jugador está vivo o muerto

        //Stats
        int strength;
        int intelligence;
        int physicalResistance;
        int magicalResistance;

        //Resistencias del enemigo
        ResistanceType[] resistances = new ResistanceType[10];

        /// <summary>
        /// Los distintos elementos que se encuentran disponibles en el juego
        /// </summary>
        public enum TypeOfResistance
        {
            blunt, slashing, fire, ice, wind, earth, shock, dark, light, allMighty
        }

        /// <summary>
        /// Almacena una de las resistencias de la unidad
        /// </summary>
        struct ResistanceType
        {
            public TypeOfResistance type;
            public int quantity;
        }

        /// <summary>
        /// Crea una unidad nueva
        /// </summary>
        /// <param name="unitName">Nombre de la unidad</param>
        /// <param name="unitID">Representación en pantalla</param>
        /// <param name="unitHP">Vida máxima</param>
        /// <param name="resistanceValues">
        /// Vector que contiene todas lsa resistencias a asignar (excluyendo allMighty) en el siguiente orden:
        /// blunt, slashing, fire, ice, wind, earth, shock, dark, light</param>
        public Player(string unitName, char unitID, int unitHP, int unitStrength, int unitIntelligence,
            int unitPhysicalResistance, int unitMagicalResistance, int[] resistanceValues)
        {
            name = unitName;
            ID = unitID;
            maxHP = unitHP;
            hp = unitHP;
            alive = true;
            strength = unitStrength;
            intelligence = unitIntelligence;
            physicalResistance = unitPhysicalResistance;
            magicalResistance = unitMagicalResistance;

            ChangeResistances(resistanceValues);

            //Asignamos aparte la resistencia a allMighty que siempre es 0
            resistances[resistances.Length - 1].type = TypeOfResistance.allMighty;
            resistances[resistances.Length - 1].quantity = 0;
        }

        /// <summary>
        /// Cambia todas las resistencias (excepto allMighty) de una unidad
        /// </summary>
        /// <param name="resistanceValues">
        /// Vector que contiene todas lsa resistencias a asignar (excluyendo allMighty) en el siguiente orden:
        /// blunt, slashing, fire, ice, wind, earth, shock, dark, light
        /// </param>
        public void ChangeResistances(int[] resistanceValues)
        {
            for (int i = 0; i < resistances.Length - 1; i++)
            {
                resistances[i].type = (TypeOfResistance)i;
                resistances[i].quantity = resistanceValues[i];
            }
        }

        public void TakeDamage(int damageTaken, TypeOfResistance element, out String damageLog)
        {
            damageLog = "";
            switch (element)
            {
                case TypeOfResistance.allMighty:
                    hp -= damageTaken;
                    damageLog = (name + " takes " + damageTaken + " " + element + " damage\n");
                    break;
                case TypeOfResistance.blunt:
                    float bluntResistanceQuantity = resistances[GetResistance(element)].quantity;
                    if (bluntResistanceQuantity < 100)
                    {
                        damageTaken -= physicalResistance;
                        if (bluntResistanceQuantity != 0)
                        {
                            bluntResistanceQuantity = 1 - bluntResistanceQuantity / 100;
                            float tempDamage = (float)damageTaken;
                            tempDamage *= bluntResistanceQuantity;
                            damageTaken = (int)tempDamage;
                        }
                        if (damageTaken <= 0)
                            damageTaken = 0;
                        hp -= damageTaken;
                        damageLog = (name + " takes " + damageTaken + " " + element + " damage\n");
                    }
                    else
                    {
                        if (bluntResistanceQuantity != 100)
                        {
                            float bluntDamageRecovery = bluntResistanceQuantity - 100;
                            if (bluntDamageRecovery != 0)
                            {
                                bluntDamageRecovery /= 100;
                                float tempDamage = (float)damageTaken;
                                tempDamage *= bluntDamageRecovery;
                                damageTaken = (int)tempDamage;
                            }
                            hp += damageTaken;
                            if (hp > maxHP)
                            {
                                hp = maxHP;
                            }
                            damageLog = (name + " heals " + damageTaken + " " + element + " damage\n");
                        }
                        else
                        {
                            damageLog = (name + " takes no damage from " + element + "\n");
                        }
                    }
                    break;
                case TypeOfResistance.slashing:
                    float slashingResistanceQuantity = resistances[GetResistance(element)].quantity;
                    if (slashingResistanceQuantity < 100)
                    {
                        damageTaken -= physicalResistance;
                        if (slashingResistanceQuantity != 0)
                        {
                            slashingResistanceQuantity = 1 - slashingResistanceQuantity / 100;
                            float tempDamage = (float)damageTaken;
                            tempDamage *= slashingResistanceQuantity;
                            damageTaken = (int)tempDamage;
                        }

                        if (damageTaken <= 0)
                            damageTaken = 0;
                        hp -= damageTaken;
                        damageLog = (name + " takes " + damageTaken + " " + element + " damage\n");
                    }
                    else
                    {
                        if (slashingResistanceQuantity != 100)
                        {
                            float slashingDamageRecovery = slashingResistanceQuantity - 100;
                            if (slashingDamageRecovery != 0)
                            {
                                slashingDamageRecovery /= 100;
                                float tempDamage = (float)damageTaken;
                                tempDamage *= slashingDamageRecovery;
                                damageTaken = (int)tempDamage;
                            }
                            hp += damageTaken;
                            if (hp > maxHP)
                            {
                                hp = maxHP;
                            }
                            damageLog = (name + " heals " + damageTaken + " " + element + " damage\n");
                        }
                        else
                        {
                            damageLog = (name + " takes no damage from " + element + "\n");
                        }

                    }
                    break;

                default:
                    float elementResistanceQuantity = resistances[GetResistance(element)].quantity;
                    if (elementResistanceQuantity < 100)
                    {
                        damageTaken -= magicalResistance;
                        if (elementResistanceQuantity != 0)
                        {
                            elementResistanceQuantity = 1 - elementResistanceQuantity / 100;
                            float tempDamage = (float)damageTaken;
                            tempDamage *= elementResistanceQuantity;
                            damageTaken = (int)tempDamage;
                        }
                        if (damageTaken <= 0)
                            damageTaken = 0;
                        hp -= damageTaken;
                        damageLog = (name + " takes " + damageTaken + " " + element + " damage\n");
                    }
                    else
                    {
                        if (elementResistanceQuantity != 100)
                        {
                            float elementDamageRecovery = elementResistanceQuantity - 100;
                            if (elementDamageRecovery != 0)
                            {
                                elementDamageRecovery /= 100;
                                float tempDamage = (float)damageTaken;
                                tempDamage *= elementDamageRecovery;
                                damageTaken = (int)tempDamage;
                            }
                            hp += damageTaken;
                            if (hp > maxHP)
                            {
                                hp = maxHP;
                            }
                            damageLog = (name + " heals " + damageTaken + " " + element + " damage\n");
                        }
                        else
                        {
                            damageLog = (name + " takes no damage from " + element + "\n");
                        }
                    }
                    break;
            }
            if (hp <= 0)
                alive = false;
        }

        private int GetResistanceRecursivo(TypeOfResistance element, int act)
        {
            if (element == resistances[act].type)
                return act;
            else
                return GetResistanceRecursivo(element, act + 1);
        }

        private int GetResistance(TypeOfResistance element)
        {
            return GetResistanceRecursivo(element, 0);
        }

        public string GetName()
        {
            return name;
        }

        public char GetID()
        {
            return ID;
        }

        public int GetHP()
        {
            return hp;
        }

        public int GetMaxHP()
        {
            return maxHP;
        }

        public int GetStrength()
        {
            return strength;
        }

        public int GetIntelligence()
        {
            return intelligence;
        }

        public bool IsAlive()
        {
            return alive;
        }
    }
}