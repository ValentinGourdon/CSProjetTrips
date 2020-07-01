using System.Collections.Generic;

namespace ESGI.DesignPattern.Projet
{
    public interface UserSession
    {

        public bool IsUserLoggedIn(User user)
        {
            throw new DependendClassCallDuringUnitTestException(
                "UserSession.IsUserLoggedIn() should not be called in an unit test");
        }

        public User GetLoggedUser()
        {
            throw new DependendClassCallDuringUnitTestException(
                "UserSession.GetLoggedUser() should not be called in an unit test");
        }
    }

    public class UserSessionImproved : UserSession
    {
        User user;

        private static readonly UserSessionImproved userSession = new UserSessionImproved();

        private UserSessionImproved() { }

        public static UserSessionImproved GetInstance()
        {
            return userSession;
        }

        public bool IsUserLoggedIn(User user)
        {
            if (user.Equals(this.user))
                return true;
            return false;
        }

        public User GetLoggedUser()
        {
            return user;
        }

        public void Connect(User user)
        {
            this.user = user;
        }

        public void Diconnect(User user)
        {
            this.user = null;
        }
    }

    public class User
    {
        public List<Trip> trips { get; }
        public List<User> friends { get; }

        public User()
        {
            trips = new List<Trip>();
            friends = new List<User>();
        }

        public List<User> GetFriends()
        {
            return friends;
        }

        public void AddFriend(User user)
        {
            friends.Add(user);
        }

        public void AddTrip(Trip trip)
        {
            trips.Add(trip);
        }

        public List<Trip> Trips()
        {
            return trips;
        }
    }
}
