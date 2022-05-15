using System;
using System.Linq;
using System.Collections.Generic;
using Пиши_Стирай.Entities;

namespace Пиши_Стирай.Classes
{
    public static class SessionData
    {
        public static User CurrentUser { get; set; }

        public static Order CurrentOrder { get; set; }

        public static Boolean TryToLoginInAccount(String userName, String userPassword)
        {
            User availableUser = TradeEntities.Instance.Users.FirstOrDefault(x =>
                                 x.UserName == userName &&
                                 x.UserPassword == userPassword);

            if (availableUser != null)
            {
                CurrentUser = availableUser;
                InitializeNewOrder();
                
                return true;
            }

            else
            {
                return false;
            }
        }

        public static void ContinueAsGuest()
        {
            CurrentUser = new User()
            {
                UserName = "Гость",
                UserRole = 1,
                Role = TradeEntities.Instance.Roles.First(r => r.RoleID == 1)
            };
            InitializeNewOrder();
        }

        public static void InitializeNewOrder()
        {
            // Для гостей.
            if (CurrentUser.UserRole == 1)
            {
                CurrentOrder = new Order()
                {
                    OrderBeginDate = DateTime.Now,
                    OrderDeliveryDate = DateTime.Now.AddDays(3),
                    OrderStatu = TradeEntities.Instance.OrderStatus.First(s => s.Id == 1),
                    OrderStatusId = 1,
                    TakeCode = new Random().Next(100, 1000),
                    OrderProducts = new List<OrderProduct>(1)
                };
            }

            // Для обычных пользователей.
            else
            {
                CurrentOrder = new Order()
                {
                    OrderBeginDate = DateTime.Now,
                    OrderDeliveryDate = DateTime.Now.AddDays(3),
                    OrderStatu = TradeEntities.Instance.OrderStatus.First(s => s.Id == 1),
                    OrderStatusId = 1,
                    TakeCode = new Random().Next(100, 1000),
                    User = CurrentUser,
                    UserId = CurrentUser.Id,
                    OrderProducts = new List<OrderProduct>(1)
                };
            }
        }
    }
}
