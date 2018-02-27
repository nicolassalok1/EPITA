using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAirport.Pim.Models
{
    public class Natif : AbstractDefinition
    {
        public override Entities.BagageDefinition GetBagageId(string idBagage)
        {
            throw new NotImplementedException();
        }
        public override List<Entities.BagageDefinition> GetBagageIata(string codeIataBagage)
        {
            throw new NotImplementedException();
        }

        public override List<bool> GetBonus(string iataBagage)
        {
            throw new NotImplementedException();
        }

    }
}

