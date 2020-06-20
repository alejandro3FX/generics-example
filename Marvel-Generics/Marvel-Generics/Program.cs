using Microsoft.VisualBasic;
using System;

namespace Marvel_Generics
{
    class Program
    {
        static void Main(string[] args)
        {
          
            // mensaje 
            Console.WriteLine("Hello World!");
        }

        public interface IHeroe : IPersonaConPoderes {
            public PersonaComunYCorriente Mama { get; set; }
        }

        public class  PersonaComunYCorriente  {
            public DateTime? FechaNacimiento { get; set; }
        }

        public class Animal {
            public string Identificador { get; set; }

            public string Nombre { get; set; }
        }



        public interface IPersonaConPoderes {
            public string NombreFantasia { get; set; }

            public string NombreReal { get; set; }
        }

        public interface IVillano : IPersonaConPoderes {

            public Animal Mascota { get; set; }
        }

        public class Poder { 
            
        }


        public enum TipoPoder { 
            Hielo = 0,
            Fuego = 1,
            SuperInteligencia =2,
            HinchaWea = 3, 
            ControlMental =4, 
            DestruyeAlmas =5
        }

        

    }
}
