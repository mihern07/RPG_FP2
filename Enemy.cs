using System;

namespace Unit
{
    class Enemy
    {
        string name;    //Nombre de la unidad
        char ID;    //Representación en pantalla
        int hp;
        int maxHP;
        bool alive; //Indica si el enemigo está vivo o muerto

        //Stats
        int strength;
        int intelligence;
        int physicalResistance;
        int magicalResistance;

        TypeOfResistance primaryElement;

        //Resistencias del enemigo
        ResistanceType[] resistances = new ResistanceType[10];

        /// <summary>
        /// Los distintos elementos que se encuentran disponibles en el juego
        /// </summary>
        public enum TypeOfResistance
        {
            blunt, slashing, fire, ice, wind, earth, shock, dark, light, allMighty
        }

        public enum Skill
        {
            Blunt, Slash, FireI, IceI, WindI, EarthI, ShockI, DarkI, LightI, AllMightyI
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
            int unitPhysicalResistance, int unitMagicalResistance, int [] resistanceValues, string mainElement)
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
            switch (mainElement)
            {
                case "Slash":
                case "slash":
                    primaryElement = TypeOfResistance.slashing;
                    break;
                case "Blunt":
                case "blunt":
                    primaryElement = TypeOfResistance.blunt;
                    break;
                case "Fire":
                case "fire":
                    primaryElement = TypeOfResistance.fire;
                    break;
                case "Ice":
                case "ice":
                    primaryElement = TypeOfResistance.ice;
                    break;
                case "Wind":
                case "wind":
                    primaryElement = TypeOfResistance.wind;
                    break;
                case "Earth":
                case "earth":
                    primaryElement = TypeOfResistance.fire;
                    break;
                case "Shock":
                case "shock":
                    primaryElement = TypeOfResistance.shock;
                    break;
                case "Dark":
                case "dark":
                    primaryElement = TypeOfResistance.dark;
                    break;
                case "Light":
                case "light":
                    primaryElement = TypeOfResistance.light;
                    break;
                case "AllMighty":
                case "allMighty":
                case "Allmighty":
                case "allmighty":
                    primaryElement = TypeOfResistance.allMighty;
                    break;
                default:
                    throw new Exception(name + " element not recognized. Supported element types are:\n" +
                        "blunt, slash, fire, ice, wind, earth, shock, dark, light, allMighty\n" +
                        "Please ensure that: Element: <DesiredElement> appears in the "+ name + ".txt file\n" +
                        "Desired enemy was changed to a default enemy as a result");
            }

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

        public void TakeDamage(int damageTaken, TypeOfResistance element, out string damageLog)
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
                        if(slashingResistanceQuantity != 100)
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
            {
                alive = false;
            }
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

        public Skill DecideAction()
        {
            Random randomAction;
            randomAction = new Random();
            int chance = randomAction.Next(0, 101);
            Skill decidedAction = Skill.Blunt;
            switch (primaryElement)
            {
                case TypeOfResistance.blunt:
                    if (chance > 30)
                    {
                        decidedAction = Skill.Blunt;
                    }
                    else
                    {
                        decidedAction = Skill.Slash;
                    }
                    break;
                case TypeOfResistance.slashing:
                    if (chance > 30)
                    {
                        decidedAction = Skill.Slash;
                    }
                    else
                    {
                        decidedAction = Skill.Blunt;
                    }
                    break;
                case TypeOfResistance.fire:
                    if (chance > 30)
                    {
                        decidedAction = Skill.FireI;
                    }
                    else
                    {
                        decidedAction = Skill.DarkI;
                    }
                    break;
                case TypeOfResistance.ice:
                    if (chance > 30)
                    {
                        decidedAction = Skill.IceI;
                    }
                    else
                    {
                        decidedAction = Skill.LightI;
                    }
                    break;
                case TypeOfResistance.wind:
                    if (chance > 30)
                    {
                        decidedAction = Skill.WindI;
                    }
                    else
                    {
                        decidedAction = Skill.Slash;
                    }
                    break;
                case TypeOfResistance.earth:
                    if (chance > 30)
                    {
                        decidedAction = Skill.EarthI;
                    }
                    else
                    {
                        decidedAction = Skill.Blunt;
                    }
                    break;
                case TypeOfResistance.shock:
                    if (chance > 30)
                    {
                        decidedAction = Skill.ShockI;
                    }
                    else
                    {
                        decidedAction = Skill.AllMightyI;
                    }
                    break;
                case TypeOfResistance.dark:
                    if (chance > 30)
                    {
                        decidedAction = Skill.DarkI;
                    }
                    else
                    {
                        decidedAction = Skill.Slash;
                    }
                    break;
                case TypeOfResistance.light:
                    if (chance > 30)
                    {
                        decidedAction = Skill.LightI;
                    }
                    else
                    {
                        decidedAction = Skill.Blunt;
                    }
                    break;
                case TypeOfResistance.allMighty:
                    if (chance > 30)
                    {
                        decidedAction = Skill.AllMightyI;
                    }
                    else
                    {
                        decidedAction = Skill.Slash;
                    }
                    break;
            }
            return decidedAction;
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