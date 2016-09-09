using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    abstract class Factory
    {
        public abstract string SetName();
        public abstract Gun CreateGun(TypeOfGun type);
        public abstract Armor CreateArmor(TypeOfArmor type);
        public abstract Engine CreateEngine(TypeOfEngine type);

    }
}

public enum TypeOfGun { Artillery, Tank}

public enum TypeOfArmor { Dynamic, Composite}

public enum TypeOfEngine { Diesel, Gasturbine}