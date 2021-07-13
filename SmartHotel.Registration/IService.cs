using SmartHotel.Registration.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHotel.Registration
{
    public interface IService
    {
       
        IEnumerable<Models.Registration> GetTodayRegistrations();
        RegistrationDaySummary GetTodayRegistrationSummary();       
        Models.Registration GetCheckin(int registrationId);      
        Models.Registration GetCheckout(int registrationId);
    }
}