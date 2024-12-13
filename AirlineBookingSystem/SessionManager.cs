using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem
{
    public static class SessionManager
    {
        private static string _currentUser;
        private static string _currentFullName;

        // Set the logged-in user's session
        public static void SetUserSession(string username, string fullName)
        {
            _currentUser = username;
            _currentFullName = fullName;
        }

        // Get the current user's session details
        public static string GetCurrentUser()
        {
            return _currentUser;
        }

        public static string GetCurrentFullName()
        {
            return _currentFullName;
        }

        // Clear the session (logout)
        public static void ClearSession()
        {
            _currentUser = null;
            _currentFullName = null;
        }

        // Check if a user is logged in
        public static bool IsUserLoggedIn()
        {
            return !string.IsNullOrEmpty(_currentUser);
        }
    }

}
