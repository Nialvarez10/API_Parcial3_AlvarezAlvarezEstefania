using API_Parcial3_AlvarezAlvarezEstefania.DAL.Entities;
using System.Diagnostics.Metrics;

namespace API_Parcial3_AlvarezAlvarezEstefania.DAL
{
    public class SeederDB
    {
        private readonly DataBaseContext _context;

        public SeederDB(DataBaseContext context)
        {
            _context = context;
        }

        
        public async Task SeederAsync()
        {
            
            await _context.Database.EnsureCreatedAsync();

            
            await PopulateHotelsAsync();

            await _context.SaveChangesAsync(); 
        }

        #region Private Methos
        private async Task PopulateHotelsAsync()
        {
          

            if (!_context.Hotels.Any())
            {
                
                _context.Hotels.Add(new Hotel
                {
                    CreatedDate = DateTime.Now,
                    Name = "Lyon",
                    Address = "Cra. 70 #45e-161, Laureles ",
                    Phone = 4205340,
                    City = "Medellin",
                    Stars = 3,
                    Rooms = new List<Room>()
                    {
                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = "101",
                            MaxGuests = 2,
                            Availability = true,
                        },
                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = "102",
                            MaxGuests = 2,
                            Availability = true,
                        },
                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = "103",
                            MaxGuests = 3,
                            Availability = false,
                        }
                    }
                });

                
                _context.Hotels.Add(new Hotel
                {
                    CreatedDate = DateTime.Now,
                    Name = "Hilton",
                    Address = "Avenida Colombia 1A Oeste - 35, Cali ",
                    Phone = 4040087,
                    City = "Cali",
                    Stars = 5,
                    Rooms = new List<Room>()
                    {
                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = "30B",
                            MaxGuests = 2,
                            Availability = false,
                        },
                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = "25B",
                            MaxGuests = 5,
                            Availability = true,
                        },
                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = "01B",
                            MaxGuests = 2,
                            Availability = true,
                        }
                    }
                });

                _context.Hotels.Add(new Hotel
                {
                    CreatedDate = DateTime.Now,
                    Name = "Saint Simon",
                    Address = "Cra. 14 #81-34, Bogotá ",
                    Phone = 3002134,
                    City = "Bogotá",
                    Stars = 4,
                    Rooms = new List<Room>()
                    {
                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = "200",
                            MaxGuests = 4,
                            Availability = true,
                        },
                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = "204",
                            MaxGuests = 1,
                            Availability = true,
                        },
                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = "201",
                            MaxGuests = 4,
                            Availability = false,
                        }
                    }
                });
            }
        }
    }
    #endregion

}
