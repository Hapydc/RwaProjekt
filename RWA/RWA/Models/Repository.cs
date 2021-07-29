using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace RWA.Models
{
    public class Repository
    {
        public static DataSet ds { get; set; }
        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public static Customer GetCustomer(int idKupac)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetCustomer", idKupac).Tables[0].Rows[0];

            return GetCustomerFromDataRow(row); ;
        }
        public static IEnumerable<Customer> SelectTop50Desc()
        {
            ds = SqlHelper.ExecuteDataset(cs, "SelectTop50Desc");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return GetCustomerFromDataRow(row);
            }
            
        }
        private static Customer GetCustomerFromDataRow(DataRow row)
        {
            return new Customer
            {
                IDKupac = (int)row["IdKupac"],
                Ime = row["ime"].ToString(),
                Prezime = row["prezime"].ToString(),
                Email = row["Email"].ToString(),
                Telefon = row["Telefon"].ToString(),
                Town = new Town
                {
                    IDGrad = (int)row["GradID"],
                    Naziv = row["Naziv"].ToString(),
                    DrzavaID=(int)row["DrzavaID"]
                }
            };
        }
    }
}