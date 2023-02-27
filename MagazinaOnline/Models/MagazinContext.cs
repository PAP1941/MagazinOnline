using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMagazin.Models
{
    public class MagazinContext:DbContext
    {
        public DbSet<Produs> Produse { get; set; }
        public DbSet<Comanda> Comenzi { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=magazinDataBase.db");
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produs>().HasKey(p => p.IdProdus);
            modelBuilder.Entity<Comanda>().HasKey(c => c.IdComanda);
        }
        public List<Produs> GetProduse()
        {
            return Produse.ToList();
        }
        public Produs GetProdusById(int idProdus)
        {
            return Produse.FirstOrDefault(p=>p.IdProdus==idProdus);
        }
        public void AdaugaProdus(Produs produs)
        {
            Produse.Add(produs);
            SaveChanges();
        }

        public void ActualizeazaProdus(Produs produs)
        {
            Produse.Update(produs);
            SaveChanges();
        }

        public void StergeProdus(Produs produs)
        {
            Produse.Remove(produs);
            SaveChanges();
        }

        public List<Comanda> GetComenzi()
        {
            return Comenzi.ToList();
        }
        public Comanda GetComandaById(int idComanda)
        {
            return Comenzi.FirstOrDefault(c => c.IdComanda == idComanda);
        }
        public void AdaugaComanda(Comanda comanda)
        {
            Comenzi.Add(comanda);
            SaveChanges();
        }

        public void ActualizeazaComanda(Comanda comanda)
        {
            Comenzi.Update(comanda);
            SaveChanges();
        }

        public void StergeComanda(Comanda comanda)
        {
            Comenzi.Remove(comanda);
            SaveChanges();
        }

       

    }
}
