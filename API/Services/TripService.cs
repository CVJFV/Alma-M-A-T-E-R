﻿using API.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public class TripService : ITripService
    {
        private readonly TripRepository repository;

        public TripService(TripRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Trip> Add(Trip item)
        {
            return await repository.Add(item);
        }

        public Trip Update(Trip item)
        {
            return repository.Update(item);
        }

        public IEnumerable<Trip> GetAll()
        {
            return repository.GetAll();
        }
        public Trip GetByID(int id)
        {
            return repository.Get(id);
        }

        public IEnumerable<Employee> GetEmployees(int id)
        {
            return repository.GetEmployees(id);
        }

        public Times GetTimes(int id)
        {
            var trip = repository.Get(id);
            return new Times()
            {
                DepartureDate = trip.DepartureDate,
                ReturnDate = trip.ReturnDate,
            };
        }

        public IEnumerable<Apartment> GetReservedApartments(int id)
        {
            return repository.GetReservedApartments(id);
        }

        public IEnumerable<PlaneTicket> GetPlaneTickets(int id)
        {
            return repository.GetPlaneTickets(id);
        }

        public IEnumerable<CarRental> GetCarRentals(int id)
        {
            return repository.GetCarRentals(id);
        }

        public IEnumerable<GasCompensation> GetGasCompensations(int id)
        {
            return repository.GetGasCompensations(id);
        }
    }
}
