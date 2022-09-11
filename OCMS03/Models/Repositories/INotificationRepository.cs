using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCMS03.Models.Repositories
{
    public interface INotificationRepository
    {
        List<NotificationApplicationUser> GetUserNotifications(string userId);
        void Create(Notification notification, int petId);
        void ReadNotification(int notificationId, string userId);
    }
}
