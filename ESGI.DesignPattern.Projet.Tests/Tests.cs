using System.Collections.Generic;
using Xunit;

namespace ESGI.DesignPattern.Projet.Tests
{
    public class Tests
    {
        User user;
        public Tests()
        {
            user = new User();
        }

        [Fact]
        public void ServiceTestNullWithoutConnection()
        {
            UserSessionConnection.GetInstance().Connect(user);
            UserSessionConnection.GetInstance().Disconnect(user);
            Assert.Throws<UserNotLoggedInException>(() => Service.Instance.GetTripsByUser(user));
        }

        [Fact]
        public void ServiceTestNotNullAfterConnexion()
        {
            UserSessionConnection.GetInstance().Connect(user);

            List<Trip> trips = Service.Instance.GetTripsByUser(user);
            Assert.NotNull(trips);
        }


        [Fact]
        public void ServiceTestTripsNotEmpty()
        {
            UserSessionConnection.GetInstance().Connect(user);

            User friend = new User();
            friend.AddTrip(new Trip());
            friend.AddTrip(new Trip());
            friend.AddFriend(user);

            List<Trip> trips = Service.Instance.GetTripsByUser(friend);

            Assert.Equal(2, trips.Count);
        }

        [Fact]
        public void ServiceTestNullAfterDisconnection()
        {
            UserSessionConnection.GetInstance().Connect(user);

            User friend = new User();
            friend.AddTrip(new Trip());
            friend.AddTrip(new Trip());
            friend.AddFriend(user);

            List<Trip> trips = Service.Instance.GetTripsByUser(friend);

            UserSessionConnection.GetInstance().Disconnect(user);
            Assert.Throws<UserNotLoggedInException>(() => Service.Instance.GetTripsByUser(user));
        }
    }
}

