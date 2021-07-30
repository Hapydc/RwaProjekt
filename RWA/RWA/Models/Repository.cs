using Microsoft.ApplicationBlocks.Data;
using RWA.Models.ViewModel;
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

            return GetCustomerFromDataRow(row);
        }
        public static IEnumerable<Customer> GetAllCustomers()
        {
            ds = SqlHelper.ExecuteDataset(cs, "SelectTop50Desc");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return GetCustomerFromDataRow(row);
            }

        }

        public static IEnumerable<Customer> GetFilteredCustomers(int townID)
        {
            ds = SqlHelper.ExecuteDataset(cs, "GetFilteredCustomers",townID);
            foreach(DataRow row in ds.Tables[0].Rows)
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
                GradID = row["GradID"] != DBNull.Value ? (int)row["GradID"] : 1
            };
        }

        public static List<Country> GetCountries()
        {

            List<Country> countries = new List<Country>();
            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetCountries");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                countries.Add(new Country
                {
                    IDDrzava = (int)row["IDDrzava"],
                    Naziv = row["Naziv"].ToString(),
                });
            }
            return countries;
        }
        public static Town GetTown(int townID)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetTown", townID).Tables[0].Rows[0];
            return new Town
            {
                IDGrad = (int)row["IDGrad"],
                DrzavaID = (int)row["DrzavaID"],
                Naziv = row["Naziv"].ToString()
            };
        }
        public static List<Town> GetTowns(int countryID)
        {
            List<Town> towns = new List<Town>();
            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetTowns",countryID);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                towns.Add(new Town
                {
                    IDGrad = (int)row["IDGrad"],
                    Naziv = row["Naziv"].ToString(),
                    DrzavaID=(int)row["DrzavaID"]
                }); 
            }
            return towns;
        }
        public static void UpdateCustomer(Customer customer)
        {
            SqlHelper.ExecuteNonQuery(cs, "UpdateCustomer", customer.IDKupac, customer.Ime, customer.Prezime, customer.Email, customer.Telefon,customer.GradID);
        }
        public static Bill GetCustomerBill(int customerID)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetCustomerBill", customerID).Tables[0].Rows[0];

            return GetBillFromDataRow(row);
        }
        public static IEnumerable<Bill> GetCustomersBills(int id)
        {
            ds = SqlHelper.ExecuteDataset(cs, "GetCustomersBills",id);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return GetBillFromDataRow(row);
            }

        }

        public static Bill GetBillFromDataRow(DataRow row)
        {
            return new Bill
            {
                IDRacun = (int)row["IdRacun"],
                BrojRacuna = row["BrojRacuna"].ToString(),
                DatumIzdavanja = (DateTime)row["DatumIzdavanja"],
                Komentar = row["Komentar"].ToString()
            };
        }
    }
}