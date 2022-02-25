using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectKviz
{
    class Kviz
    {
        string tantargy;
        string tema;
        string kerdes;
        string valaszA;
        string valaszB;
        string valaszC;
        string valaszD;
        string helyes;
        public Kviz(string sor)
        {

            var sorE = sor.Split(';');
            Tantargy = sorE[0];
            Tema= sorE[1];
            Kerdes= sorE[2];
            valaszA = sorE[3];
            valaszB = sorE[4];
            valaszC = sorE[5];
            valaszD = sorE[6];
            Helyes=sorE[7];
        }
        public string Tantargy { get => tantargy; private set => tantargy = value; }
        public string Tema{ get => tema; private set => tema = value; }
        public string Kerdes { get => kerdes; private set => kerdes = value; }
        public string ValaszA { get => valaszA; private set => valaszA = value; }
        public string ValaszB { get => valaszB; private set => valaszB = value; }
        public string ValaszC { get => valaszC; private set => valaszC = value; }
        public string ValaszD { get => valaszD; private set => valaszD = value; }

        public string Helyes { get => helyes; private set => helyes = value; }
    }
}
