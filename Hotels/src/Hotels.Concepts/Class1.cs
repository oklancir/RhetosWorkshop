using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Hotels.Concepts
{
    //[Export(typeof(IConceptInfo))]
    //[ConceptKeyword("Sifarnik")]
    //public class SifarnikInfo : EntityInfo
    //{
    //}

    [Export(typeof(IConceptInfo))]
    [ConceptKeyword("Sifarnik")]
    public class SifarnikInfo : IConceptInfo
    {
        [ConceptKey]
        public EntityInfo Entity { get; set; }
    }


    [Export(typeof(IConceptMacro))]
    public class SifarnikMacro : IConceptMacro<SifarnikInfo>
    {
        public IEnumerable<IConceptInfo> CreateNewConcepts(SifarnikInfo conceptInfo, IDslModel existingConcepts)
        {
            var newConcepts = new List<IConceptInfo>();

            var poljeOznaka = new ShortStringPropertyInfo
            {
                Name = "Oznaka",
                DataStructure = conceptInfo.Entity
            };

            newConcepts.Add(poljeOznaka);

            newConcepts.Add(new AutoCodePropertyInfo
            {
                Property = poljeOznaka
            });

            var poljeNaziv = new ShortStringPropertyInfo
            {
                Name = "Naziv",
                DataStructure = conceptInfo.Entity
            };

            newConcepts.Add(poljeNaziv);
            newConcepts.Add(new RequiredPropertyInfo
            {
                Property = poljeNaziv
            });

            return newConcepts;
        }
    }
}
