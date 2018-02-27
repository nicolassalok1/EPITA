using MyAirport.Pim.Entities;
using MyAirport.Pim.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace MyAirport.Pim.Models
{

    public class Sql : AbstractDefinition
    {

        string strcnx = ConfigurationManager.ConnectionStrings["MyAiport.Pim.Settings.DbConnect"].ConnectionString;

        private string commandGetBagageIata = "select b.ID_BAGAGE, b.CODE_IATA, b.COMPAGNIE, b.LIGNE, b.DATE_CREATION, " +
                    "b.ESCALE, cc.PRIORITAIRE, " +
                    "cast (iif(b.CONTINUATION='N',0,1) as bit) as continuation, " +
                    "cast (iif(bp.PARTICULARITE is null,0,1)as bit) as 'RUSH' from BAGAGE b " +
                    "left outer join BAGAGE_A_POUR_PARTICULARITE bap on b.ID_BAGAGE = bap.ID_BAGAGE " +
                    "left outer join BAGAGE_PARTICULARITE bp on bp.ID_PART = bap.ID_PARTICULARITE " +
                    "and bp.PARTICULARITE = 'RUSH' " +
                    "LEFT OUTER JOIN COMPAGNIE c on c.CODE_IATA = b.COMPAGNIE " +
                    "LEFT OUTER JOIN COMPAGNIE_CLASSE cc on cc.ID_COMPAGNIE = c.ID_COMPAGNIE " +
                    "and cc.CLASSE = b.CLASSE " +
                    "Where (len(b.CODE_IATA) = 6 and SUBSTRING(b.CODE_IATA, 5, 6) = @iata) or b.CODE_IATA = @iata;";

        string commandGetBagageId = "select b.ID_BAGAGE, b.CODE_IATA, b.COMPAGNIE, b.LIGNE, b.DATE_CREATION, " +
                    "b.ESCALE, cc.PRIORITAIRE, " +
                    "cast (iif(b.CONTINUATION='N',0,1) as bit) as continuation, " +
                    "cast (iif(bp.PARTICULARITE is null,0,1)as bit) as 'RUSH' from BAGAGE b " +
                    "left outer join BAGAGE_A_POUR_PARTICULARITE bap on b.ID_BAGAGE = bap.ID_BAGAGE " +
                    "left outer join BAGAGE_PARTICULARITE bp on bp.ID_PART = bap.ID_PARTICULARITE " +
                    "and bp.PARTICULARITE = 'RUSH' " +
                    "LEFT OUTER JOIN COMPAGNIE c on c.CODE_IATA = b.COMPAGNIE " +
                    "LEFT OUTER JOIN COMPAGNIE_CLASSE cc on cc.ID_COMPAGNIE = c.ID_COMPAGNIE " +
                    "and cc.CLASSE = b.CLASSE " +
                    "where b.ID_BAGAGE = @id";
     
        string commandBonus =   "select cc.PRIORITAIRE" +
                                "from BAGAGE b" +
                                    "left outer join COMPAGNIE c on b.COMPAGNIE = c.CODE_IATA" +
                                    "left outer join COMPAGNIE_CLASSE cc on c.ID_COMPAGNIE = cc.ID_COMPAGNIE" +
                                "where b.CODE_IATA = @iata;";

        public BagageDefinition NewBagage(SqlDataReader sdr)
        {
            BagageDefinition bagRes = new BagageDefinition();

            bagRes.IdBagage = sdr.GetInt32(sdr.GetOrdinal("id_bagage"));
            bagRes.CodeIata = sdr.GetString(sdr.GetOrdinal("code_iata"));
            bagRes.Compagnie = sdr.GetString(sdr.GetOrdinal("compagnie"));
            bagRes.Ligne = sdr.GetString(sdr.GetOrdinal("ligne"));
            bagRes.DateVol = sdr.GetDateTime(sdr.GetOrdinal("date_creation"));
            bagRes.Itineraire = sdr.GetString(sdr.GetOrdinal("escale"));
            bagRes.Prioritaire = sdr.GetBoolean(sdr.GetOrdinal("prioritaire"));
            bagRes.EnContinuation = sdr.GetBoolean(sdr.GetOrdinal("continuation"));
            bagRes.Rush = sdr.GetBoolean(sdr.GetOrdinal("rush"));

            return bagRes;
        }


        public override BagageDefinition GetBagageId(string idBagage)
        {
            BagageDefinition bagRes = null;
            using (SqlConnection scnx = new SqlConnection(strcnx))
            {
                SqlCommand cmd = new SqlCommand(this.commandGetBagageId, scnx);

                cmd.Parameters.AddWithValue("@id", idBagage);

                scnx.Open();

                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.Read())
                    {
                        bagRes = NewBagage(sdr);
                    }
                }
                return bagRes;
            }
        }

        public override List<BagageDefinition> GetBagageIata(string iataBagage)
        {

            List<BagageDefinition> bagsRes = new List<BagageDefinition>();

            using (SqlConnection cnx = new SqlConnection(strcnx))
            {
                SqlCommand cmd = new SqlCommand(this.commandGetBagageIata, cnx);
                
                cmd.Parameters.AddWithValue("@iata", iataBagage);

                cnx.Open();

                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        //bagsRes.Add(NewBagage(sdr));
                        BagageDefinition bagRes = new BagageDefinition();


                        bagRes.IdBagage = sdr.GetInt32(sdr.GetOrdinal("id_bagage"));
                        bagRes.CodeIata = sdr.GetString(sdr.GetOrdinal("code_iata"));
                        bagRes.Compagnie = sdr.GetString(sdr.GetOrdinal("compagnie"));
                        bagRes.Ligne = sdr.GetString(sdr.GetOrdinal("ligne"));
                        bagRes.DateVol = sdr.GetDateTime(sdr.GetOrdinal("date_creation"));
                        bagRes.Itineraire = sdr.GetString(sdr.GetOrdinal("escale"));
                        bagRes.Prioritaire = sdr.GetBoolean(sdr.GetOrdinal("prioritaire"));
                        bagRes.EnContinuation = sdr.GetBoolean(sdr.GetOrdinal("continuation"));

                        bagRes.Rush = sdr.GetBoolean(sdr.GetOrdinal("rush"));
                        bagsRes.Add(bagRes);
                    }

                }
                return bagsRes;
            }
        }

        public override List<bool> GetBonus(string iataBagage)
        {

            List<bool> bagsRes = null;

            using (SqlConnection cnx = new SqlConnection(strcnx))
            {
                SqlCommand cmd = new SqlCommand(this.commandBonus, cnx);
                string iata = iataBagage.Remove(0, 4).Remove(6, 2);
                cmd.Parameters.AddWithValue("@iata", iata);

                cnx.Open();

                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        bagsRes.Add(sdr.GetBoolean(sdr.GetOrdinal("prioritaire")));
                    }
                }
                return bagsRes;
            }
        }
    }
}


