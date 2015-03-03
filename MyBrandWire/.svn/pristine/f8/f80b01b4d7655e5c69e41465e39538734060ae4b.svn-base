using System.Collections.Generic;
using Model.Entity;

namespace Model
{
    public class ModelServices:IModelService
    {
        public List<CPressRealise> GetAllPressRealises()
        {
            using (var layer = new DASqliteLayer.DASqliteLayer())
            {
                return layer.GetAllPressRealises();
            }

        }

        public List<CSite> GetAllSites()
        {
            using (var layer = new DASqliteLayer.DASqliteLayer())
            {
                return layer.GetAllSites();
            }
        }

        public bool UpdatePressRealise(CPressRealise pressRealise)
        {
            using (var layer = new DASqliteLayer.DASqliteLayer())
            {
                return layer.UpdatePressRealise(pressRealise);
            }
        }
    }
}
