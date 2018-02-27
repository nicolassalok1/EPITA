using MyAirport.Pim.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAirport.Pim.Models
{
    public abstract class AbstractDefinition
    {
        public abstract BagageDefinition GetBagageId(string idBagage);
        public abstract List<BagageDefinition> GetBagageIata(string iataBagage);
        public abstract List<bool> GetBonus(string iataBagage);
    }
}