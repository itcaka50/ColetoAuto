using System;
using DataLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer2
{
    public class ContextHelper
    {
        private static MeowDbContext dbContext;
        private static AircraftContext aircraftContext;
        private static BoatContext boatContext;
        private static BrandContext brandContext;
        private static CarContext carContext;
        private static ModelContext modelContext;
        private static UserContext userContext;


        public static MeowDbContext GetDbContext()
        {
            if (dbContext == null)
            {
                SetDbContext();
            }

            return dbContext;
        }

        public static void SetDbContext()
        {
            dbContext = new MeowDbContext();
        }

        public static AircraftContext GetAircraftContext()
        {
            if (aircraftContext == null)
            {
                SetAircraftContext();
            }

            return aircraftContext;
        }

        public static void SetAircraftContext()
        {
            aircraftContext = new AircraftContext(GetDbContext());
        }

        public static BoatContext GetBoatContext()
        {
            if (boatContext == null)
            {
                SetBoatContext();
            }

            return boatContext;
        }

        public static void SetBoatContext()
        {
            boatContext = new BoatContext(GetDbContext());
        }

        public static BrandContext GetBrandContext()
        {
            if (brandContext == null)
            {
                SetBrandContext();
            }

            return brandContext;
        }

        public static void SetBrandContext()
        {
            brandContext = new BrandContext(GetDbContext());
        }

        public static ModelContext GetModelContext()
        {
            if (modelContext == null)
            {
                SetModelContext();
            }

            return modelContext;
        }

        public static void SetModelContext()
        {
            modelContext = new ModelContext(GetDbContext());
        }

        public static UserContext GetUserContext()
        {
            if (userContext == null)
            {
                SetUserContext();
            }

            return userContext;
        }

        public static void SetUserContext()
        {
            userContext = new UserContext(GetDbContext());
        }

        public static CarContext GetCarContext()
        {
            if (carContext == null)
            {
                SetCarContext();
            }

            return carContext;
        }

        public static void SetCarContext()
        {
            carContext = new CarContext(GetDbContext());
        }
    }
}
