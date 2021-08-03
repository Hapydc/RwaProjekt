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
        private static string sqlSortType;


        public static Customer GetCustomer(int idKupac)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetCustomer", idKupac).Tables[0].Rows[0];

            return GetCustomerFromDataRow(row);
        }


        public static IEnumerable<Customer> GetCustomers(int countryID, int? townID, SortType? sortType, int customersPerPage, int page)
        {        
            switch (sortType)
            {
                case null:
                    sqlSortType = " Kupac.Ime desc";
                    break;
                case SortType.SortByNameAsc:
                    sqlSortType = " Kupac.Ime asc";
                    break;
                case SortType.SortByNameDesc:
                    sqlSortType = " Kupac.Ime desc";
                    break;
                case SortType.SortBySurnameAsc:
                    sqlSortType = " Kupac.Prezime asc";
                    break;
                case SortType.SortBySurnameDesc:
                    sqlSortType = " Kupac.Prezime desc";
                    break;
            }
            string sqlTownSort;

            if (townID==null)
            {
                sqlTownSort = $" where d.IDDrzava = {countryID} ";
            }

            else
            {
                sqlTownSort = $" where Kupac.GradID={townID} ";              
            }

            var sql = ($"select  Kupac.IDKupac, Kupac.Ime,Kupac.Prezime, " +
                                $"Kupac.Telefon,Kupac.Email,Kupac.GradID, g.Naziv as NazivGrada, d.IDDrzava, d.Naziv as NazivDrzave from Kupac  " +
                                $"join Grad as g on kupac.GradID = g.IDGrad join Drzava as d on d.IDDrzava = g.DrzavaID" +
                                $"  { sqlTownSort }" +
                                $"  order by {sqlSortType} offset {customersPerPage * (page-1) } rows" +
                                $" fetch next { customersPerPage } rows only");

            var result = SqlHelper.ExecuteReader(cs, CommandType.Text, sql);
            var customers = new List<Customer>();
            while (result.Read())
            {
                var country = new Country
                {
                    IDDrzava = (int)result["IdDrzava"],
                    Naziv = result["NazivGrada"].ToString(),
                };
                var town = new Town
                {
                    IDGrad = (int)result["GradID"],
                    Naziv = result["NazivDrzave"].ToString(),
                    DrzavaID=(int)result["IDDrzava"],
                    Country=country
                };

                customers.Add(
                    new Customer
                    {
                        IDKupac = (int)result["IdKupac"],
                        Ime = result["ime"].ToString(),
                        Prezime = result["prezime"].ToString(),
                        Email = result["Email"].ToString(),
                        Telefon = result["Telefon"].ToString(),
                        GradID = result["GradID"] != DBNull.Value ? (int)result["GradID"] : 1,
                        Town = town                      
                    }
                    ) ;
            }

            return customers;
        }

        public static Country GetCountry(int countryId)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetCountry", countryId).Tables[0].Rows[0];
            return new Country
            {
                IDDrzava = (int)row["IDDrzava"],
                Naziv = row["Naziv"].ToString(),
            };


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
                GradID = row["GradID"] != DBNull.Value ? (int)row["GradID"] : 1,

            };
        }

 
        public static Town GetTown(int? townID)
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
            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetTowns", countryID);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                towns.Add(new Town
                {
                    IDGrad = (int)row["IDGrad"],
                    Naziv = row["Naziv"].ToString(),
                    DrzavaID = (int)row["DrzavaID"]
                });
            }
            return towns;
        }
        public static void UpdateCustomer(Customer customer)
        {
            SqlHelper.ExecuteNonQuery(cs, "UpdateCustomer", customer.IDKupac, customer.Ime, customer.Prezime, customer.Email, customer.Telefon, customer.GradID);
        }
        public static Bill GetCustomerBill(int customerID)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetCustomerBill", customerID).Tables[0].Rows[0];
            return GetBillFromDataRow(row);
        }
        public static IEnumerable<Bill> GetCustomersBills(int id)
        {
            ds = SqlHelper.ExecuteDataset(cs, "GetCustomersBills", id);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return GetBillFromDataRow(row);
            }

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

        public static List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            var sql = $"Select p.IDProizvod,p.Naziv,p.BrojProizvoda,p.Boja,p.MinimalnaKolicinaNaSkladistu,Cast(p.CijenaBezPdv as decimal (10,2)) as CijenaBezPdv,p.PotkategorijaID " +
                $"from Proizvod as p ";
            var result = SqlHelper.ExecuteReader(cs, CommandType.Text, sql);
            while (result.Read())
            {              
                    products.Add(new Product
                    {
                        IdProizvod = (int)result["IDProizvod"],
                        Naziv = result["Naziv"].ToString(),
                        BrojProizvoda = result["BrojProizvoda"].ToString(),                                             
                        Boja = result["Boja"].ToString()??" ",
                        MinKolicinaNaSkladistu = (short)result["MinimalnaKolicinaNaSkladistu"],
                        CijenaBezPdva =(decimal)result["CijenaBezPdv"],
                        PotKategorijaID = (int)result["PotkategorijaID"]
                    });  
            }
            return products;
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