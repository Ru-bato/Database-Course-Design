using DB_BackendDAL;
using DB_BackendModel;
using System;

namespace DB_BackendBLL
{
    public class PassengerManager
    {
        private readonly PassengerServer _passengerServer;

        public PassengerManager(PassengerServer passengerServer)
        {
            _passengerServer = passengerServer;
        }

        public void CreatePassenger(Passenger passenger)
        {
            if (string.IsNullOrWhiteSpace(passenger.Passenger_name) || string.IsNullOrWhiteSpace(passenger.Id_number))
            {
                throw new ArgumentException("Passenger name and ID number cannot be empty");
            }

            _passengerServer.CreatePassenger(passenger);
        }

        public Passenger? GetPassengerById(string passengerId)
        {
            if (string.IsNullOrWhiteSpace(passengerId))
            {
                throw new ArgumentException("Passenger ID cannot be empty");
            }

            return _passengerServer.GetPassengerById(passengerId);
        }

        public void UpdatePassenger(Passenger passenger)
        {
            if (string.IsNullOrWhiteSpace(passenger.Passenger_name) || string.IsNullOrWhiteSpace(passenger.Id_number))
            {
                throw new ArgumentException("Passenger name and ID number cannot be empty");
            }

            _passengerServer.UpdatePassenger(passenger);
        }

        public void DeletePassenger(string passengerId)
        {
            if (string.IsNullOrWhiteSpace(passengerId))
            {
                throw new ArgumentException("Passenger ID cannot be empty");
            }

            _passengerServer.DeletePassenger(passengerId);
        }
    }
}

