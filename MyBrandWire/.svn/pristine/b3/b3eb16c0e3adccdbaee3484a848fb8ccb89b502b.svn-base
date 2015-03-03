using System.Collections.Generic;
using System.Data.Common;
using Model.Entity;

namespace Model.DASqliteLayer
{
    public interface IDaLayer
    {
        bool InitializeDb();
        void PerformCommand(string command, DbConnection connection);

        List<CPressRealise> GetAllPressRealises();
        List<CSite> GetAllSites();
    }
}
