using System;

namespace Unit
{
    class Enemy
    {
        string name;    //Nombre de la unidad
        char ID;    //Representación en pantalla
        int hp;
        int maxHP;

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
        public Enemy(string unitName, char unitID, int unitHP, int unitStrength, int unitIntelligence,
            int unitPhysicalResistance, int unitMagicalResistance, int [] resistanceValues)
        {
            name = unitName;
            ID = unitID;
            maxHP = unitHP;
            hp = unitHP;
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
        public void ChangeResistances(int [] resistanceValues)
        {
            for (int i = 0; i < resistances.Length-1; i++)
            {
                resistances[i].type = (TypeOfResistance)i;
                resistances[i].quantity = resistanceValues[i];
            }
        }

        public void TakeDamage(int damageTaken, TypeOfResistance element)
        {
            switch (element)
            {
                case TypeOfResistance.allMighty:
                    hp -= damageTaken;
                    break;
                case TypeOfResistance.blunt:
                    int bluntResistanceQuantity = resistances[GetResistance(element)].quantity;
                    if (bluntResistanceQuantity <= 100)
                    {
                        if (bluntResistanceQuantity != 0)
                            damageTaken /= bluntResistanceQuantity;
                        hp -= (damageTaken - physicalResistance);
                    }
                    else
                    {
                        int bluntDamageRecovery = bluntResistanceQuantity - 100;
                        if (bluntDamageRecovery != 0)
                            damageTaken /= bluntDamageRecovery;
                        hp += damageTaken;
                    }
                    break;
                case TypeOfResistance.slashing:
                    int slashingResistanceQuantity = resistances[GetResistance(element)].quantity;
                    if (slashingResistanceQuantity <= 100)
                    {
                        if (slashingResistanceQuantity!=0)
                            damageTaken /= slashingResistanceQuantity;
                        hp -= (damageTaken - magicalResistance);
                    }
                    else
                    {
                        int slashingDamageRecovery = slashingResistanceQuantity - 100;
                        if (slashingDamageRecovery != 0)
                            damageTaken /= slashingDamageRecovery;
                        hp += damageTaken;
                    }
                    break;

                default:
                    int elementResistanceQuantity = resistances[GetResistance(element)].quantity;
                    if (elementResistanceQuantity <= 100)
                    {
                        if (elementResistanceQuantity != 0)
                            damageTaken /= elementResistanceQuantity;
                        hp -= damageTaken;
                    }
                    else
                    {
                        int elementDamageRecovery = elementResistanceQuantity - 100;
                        if (elementDamageRecovery != 0)
                            damageTaken /= elementDamageRecovery;
                        hp += damageTaken;
                    }
                    break;
            }
        }

        private int GetResistance(TypeOfResistance element)
        {
            int contador = 0;
            while(contador<resistances.Length && resistances[contador].type != element)
            {
                contador++;
            }
            if (contador >= resistances.Length)
            {
                throw new Exception("No se ha encontrado la resistencia");
            }
            return contador;
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
    }
}