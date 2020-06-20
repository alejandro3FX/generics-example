using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Marvel_Generics
{
    class Program
    {
        static void Main(string[] args)
        {

            //Ejemplo de interfaces con patron irepository;

            // mensaje 
            Console.WriteLine("Hello World!");
            var heroe = new HeroeAlienigena
            {
                NombreReal = "Máximo Henriquez",
                NombreFantasia = "El Gladiador",
                Mama = new PersonaComunYCorriente
                {
                    FechaNacimiento = DateAndTime.Now.AddYears(-50)
                },
                Poderes = new List<Poder> {
                    new Poder { NroDanio = 10, TipoPoder = TipoPoder.Fuego },
                    new Poder { NroDanio = 20, TipoPoder = TipoPoder.Hielo }
                }
            };

            var villano = new MorganaInvasadoraDeLasAlmasPerdidasDeLosProgramadoresEsforzadosDeAcl
            {
                Mascota = new Animal { Nombre = "Satanas", Identificador = "666" },
                NombreFantasia = "Morgana",
                NombreReal = "***",
                Poderes = new List<Poder> {
                    new Poder { NroDanio = 10, TipoPoder = TipoPoder.HinchaWea },
                    new Poder { NroDanio = 10, TipoPoder = TipoPoder.DestruyeAlmas },
                    new Poder { NroDanio = 120, TipoPoder = TipoPoder.SobadoraDeLomos}
                }
            };


            var accionDeHeroe = new AccionDeHeroe<HeroeAlienigena>();

            
            Console.WriteLine(accionDeHeroe.Golpe(heroe, TipoPoder.Fuego, villano).Mensaje);
            Console.ReadLine();

            

            

        }

        public class ModeloDelSuperSistema {
            public IDbManager<Persona> RepositorioPersonas { get; set; }
        }

        

        public class MorganaInvasadoraDeLasAlmasPerdidasDeLosProgramadoresEsforzadosDeAcl : IVillano
        {

            
            public Animal Mascota { get; set; }
            public string NombreFantasia { get; set; }
            public string NombreReal { get; set; }
            public List<Poder> Poderes { get; set; }
        }


        public class ResultadoGolpe {
            public string Mensaje { get; set; }

            public int Danio { get; set; }
        }

        public class AccionDeHeroe<T> where T : IHeroe {

            public ResultadoGolpe Golpe(T heroe, TipoPoder tipoPoder, IVillano vallanoRecibio)
            {
                var golpes = heroe.Poderes;


                var poderEjecutado = golpes.Any(s => s.TipoPoder == tipoPoder);

                if (!poderEjecutado) return new ResultadoGolpe { Danio = 0, Mensaje = "Eris terrible wn" };


                return new ResultadoGolpe { Danio = 50, Mensaje = $"{heroe.NombreFantasia} ha conseguido un Coooooombooo - BReaaaaaakkeeeeeeer!!!!! golpeando a {vallanoRecibio.NombreFantasia} con un danio de {50}" };
                



                
            }
            
        }

        /*
         Ejemplo de interfaces, patrón IRepository,
        este patrón permite conectar distintas bases de datos a un sistema y
        también reemplazar la base de datos por un fake para hacer testing.
         */

        public class ColeccionPersonasMongoDb : IDbManager<Persona>
        {
            public string ConnectionString { get; set; }

            private List<ICrudOperations<Persona>> _operacionesDb;

            public List<ICrudOperations<Persona>> OperacionesDb
            {
                get {
                    _operacionesDb = _operacionesDb ?? new List<ICrudOperations<Persona>>();
                    return _operacionesDb; }
                set { _operacionesDb = value; }
            }

        }



        public class Persona : IEntity {
            public string Id { get; set; }
            
            public string Nombre { get; set; }
        }
        public interface IEntity {
            string Id { get; set; }
        }

        public interface IDbManager<T> where T: IEntity {

            public string ConnectionString { get; set; }

            public List<ICrudOperations<T>> OperacionesDb { get; set; }
        }

        public class PersonaOperations : ICrudOperations<Persona>
        {
            public void Create(Persona entity)
            {
                // creando persona en mongo
            }

            public void Delete(Persona elemento)
            {
                throw new NotImplementedException();
            }

            public Persona Get()
            {
                throw new NotImplementedException();
            }

            public List<Persona> GetList()
            {
                throw new NotImplementedException();
            }
        }

        public interface ICrudOperations<T> where T:IEntity  {

            void Create(T entity);

            T Get();

            List<T> GetList();

            void Delete(T elemento);
        }




        public class HeroeAlienigena : IHeroe
        {
            
            public PersonaComunYCorriente Mama { get; set; }
            public string NombreFantasia { get; set; }
            public string NombreReal { get; set; }
            public List<Poder> Poderes { get; set; }
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

            public List<Poder> Poderes { get; set; }




        }

        public interface IVillano : IPersonaConPoderes {

            public Animal Mascota { get; set; }
        }

        public class Poder {

            public TipoPoder TipoPoder { get; set; }
            public int NroDanio { get; set; }
        }


        public enum TipoPoder { 
            Hielo = 0,
            Fuego = 1,
            SuperInteligencia =2,
            HinchaWea = 3, 
            ControlMental =4, 
            DestruyeAlmas =5,
            SobadoraDeLomos = 6
        }

        

    }
}
