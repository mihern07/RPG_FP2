using System;

namespace Unit
{
    class Enemy
    {
        string name;    //Nombre de la unidad
        char ID;    //Representación en pantalla
        int hp;

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
                    if (resistances[GetResistance(element)].quantity <= 100)
                    {
                        damageTaken /= resistances[GetResistance(element)].quantity;
                        hp -= (damageTaken - physicalResistance);
                    }
                    else
                    {
                        hp += damageTaken / (resistances[GetResistance(element)].quantity - 100);
                        
                    }
                    break;
                case TypeOfResistance.slashing:
                    if (resistances[GetResistance(element)].quantity <= 100)
                    {
                        damageTaken /= resistances[GetResistance(element)].quantity;
                        hp -= (damageTaken - magicalResistance);
                    }
                    else
                    {
                        hp += damageTaken / (resistances[GetResistance(element)].quantity - 100);

                    }
                    break;

                default:
                    if (resistances[GetResistance(element)].quantity <= 100)
                    {
                        hp -= damageTaken / resistances[GetResistance(element)].quantity;
                    }
                    else
                    {
                        hp += damageTaken / (resistances[GetResistance(element)].quantity - 100);
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

        public int GetHP()
        {
            return hp;
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