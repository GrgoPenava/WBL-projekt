﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Repository;
using WebAPI.Repository.Models;

namespace WebAPI.Services
{
    public class ParkingSessionService
    {
        public List<TmpParkingSession> GetParkingSessionsPerParkingSpot(int id)
        {
            using (var context = new PI2201_DBContext())
            {
                var parkingSessions = context.ParkingSessions.Where(x => x.PssParkingSpotId == id).ToList();
                return parkingSessions;
            }
        }

        public List<TmpParkingSession> GetSpecificParkingSession(int id)
        {
            using (var context = new PI2201_DBContext())
            {
                var parkingSessions = context.ParkingSessions.Where(x => x.PssParkingSessionId == id).ToList();
                return (List<TmpParkingSession>)parkingSessions;
            }
        }
        public List<TmpParkingSession> GetAllParkingSessionsForParkingSpace(int id)
        {
            using (var context = new PI2201_DBContext())
            {
                var parkingSpots = context.TmpParkingSpots.ToList();
                List<TmpParkingSpot> parkingSpotsZaParkirniSpace = new List<TmpParkingSpot>();
                List<TmpParkingSession> parkingSessionsZaParkirniSpace = new List<TmpParkingSession>();
                foreach (var item in parkingSpots)
                {
                    if (item.SptParkingSpaceId == id)
                        parkingSpotsZaParkirniSpace.Add(item);
                }
                foreach (var item in parkingSpotsZaParkirniSpace)
                {
                    var parkingSessions = context.ParkingSessions.Where(x => x.PssParkingSpotId == item.SptParkingSpotId).ToList();
                    foreach (var item2 in parkingSessions)
                    {
                        parkingSessionsZaParkirniSpace.Add(item2);
                    }
                }
                return (List<TmpParkingSession>)parkingSessionsZaParkirniSpace;
            }
        }
    }
}
