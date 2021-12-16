using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Authorization.Entity;

namespace Authorization.Abstraction
{
    public interface IUserSynchronization
    {
        Task<User> SyncUser(User user);
        void LaunchMonitoring();
        Task StopMonitoring();
    }
}
