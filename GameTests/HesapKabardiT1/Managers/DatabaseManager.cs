using HesapKabardiT1.Items;
using HesapKabardiT1.Pool;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace HesapKabardiT1.Managers
{
    public class DatabaseManager : DbContext
	{
		public DbSet<User> Users { get; set; }	
		public DbSet<Room> GameRooms { get; set; }
		public DbSet<RoomMessage> RoomMessages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=LAPTOPLENO;Initial Catalog=HesapKabardi;Integrated Security=True;TrustServerCertificate=true;");
		}
	}
}
