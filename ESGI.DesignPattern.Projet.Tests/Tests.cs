using System.Collections.Generic;
using Xunit;

namespace ESGI.DesignPattern.Projet.Tests
{
    public class Tests
    {
        [Fact]
        public void ServiceTestNotNull()
        {
            User user = new User();
            UserSessionImproved.GetInstance().Connect(user);

            List<Trip> trips = Service.Instance.GetTripsByUser(user);
            Assert.NotNull(trips);
        }

        [Fact]
        public void ServiceTestNull()
        {
            User user = new User();
            Assert.Throws<UserNotLoggedInException>(() => Service.Instance.GetTripsByUser(user));
        }

        [Fact]
        public void ServiceTestTripsNotEmpty()
        {
            User user = new User();
            UserSessionImproved.GetInstance().Connect(user);

            User friend = new User();
            friend.AddTrip(new Trip());
            friend.AddTrip(new Trip());
            friend.AddFriend(user);

            List<Trip> trips = Service.Instance.GetTripsByUser(friend);

            Assert.Equal(2, trips.Count);
        }
    }
}

