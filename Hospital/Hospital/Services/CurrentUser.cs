using Hospital.Services.Entitties;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Services
{
    public static class CurrentUser
    {
        public static User CurUser { get; set;}
        public static void EnterAsUser(User user) => CurUser = user;
        public static void EnterAsGuest()
        {
            CurUser = new User();
            CurUser.Id = -1;
            CurUser.Password = null;
            CurUser.MedCardId = -1;
            CurUser.Login = null;
            CurUser.Mail = null;
            CurUser.Level = -1;
        }
    }
}
