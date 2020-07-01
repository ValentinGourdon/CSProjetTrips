using System;
using System.Collections.Generic;
using System.Text;

namespace ESGI.DesignPattern.Projet
{
    public sealed class Service
    {
        private static readonly Lazy<Service> lazy =
            new Lazy<Service>(() => new Service());

        public static Service Instance { get { return lazy.Value; } }

        private Service()
        {
        }

        public List<Trip> GetTripsByUser(User friend)
        {
            List<Trip> tripList = new List<Trip>();
            User userLogged = UserSessionImproved.GetInstance().GetLoggedUser();
            if(userLogged != null)
            {
                bool isFriend = false;
                foreach (User user in friend.GetFriends())
                {
                    if (user.Equals(userLogged))
                    {
                        isFriend = true;
                        break;
                    }
                }
                if (isFriend)
                {
                    tripList = friend.Trips();
                }
                return tripList;
            }
            else
            {
                throw new UserNotLoggedInException();
            }
        }
    }
   
}
