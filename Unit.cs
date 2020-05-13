using System;

namespace Unit
{
    class Unit
    {
        /// <summary>
        /// Nombre de la unidad
        /// </summary>
        string name;
        char ID;    //Representación en pantalla
        int hp;
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
        public Unit(string unitName, char unitID, int unitHP, int [] resistanceValues)
        {
            name = unitName;
            ID = unitID;
            hp = unitHP;
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
    }
}