using SuperheroesUniverse.Data.Context;
using SuperheroesUniverse.Exporters;
using SuperheroesUniverse.Importers;

namespace SuperheroesUniverse
{
    public class Startup
    {
        public static void Main()
        {
            var superHeroesContext = new SuperHeroesDbContext();

            //var jsonImporter = new JsonSuperheroesImporter(superHeroesContext);
            //jsonImporter.LoadSuperHeroes("../../sample-data.json");

            var superheroesExporter = new SuperheroesUniverseExporter(superHeroesContext, "../../heroes.xml");
             superheroesExporter.ExportAllSuperheroes();
            // superheroesExporter.ExportSupperheroesWithPower("Martial Arts");
            // superheroesExporter.ExportSuperheroesByCity("New York");
            // superheroesExporter.ExportSuperheroDetails(4);
            // superheroesExporter.ExportFractions();
            // superheroesExporter.ExportFractionDetails(1);
        }
    }
}
