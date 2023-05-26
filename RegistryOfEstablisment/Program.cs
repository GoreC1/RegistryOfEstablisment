using NLog;
using RegistryOfEstablisment.Model;
using RegistryOfEstablisment.Model.Entities;
using RegistryOfEstablisment.Unit;
using RegistryOfEstablisment.UnitControl;
using RegistryOfEstablisment.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RegistryOfEstablisment
{
    public static class Program
    {
        private static Logger Logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DataContext dataContext = new();
            UnitOfWork unit = new(dataContext);
            UnitOfControl unitOfControl = new(unit);
            // Строки для удобного добавления изначальных сущностей в бд, организации добавляются непосредственно через программу
            //List<EnterpriseType> types = new List<EnterpriseType>{ new EnterpriseType() { Name = "Организация по отлову" }, new EnterpriseType() { Name = "Приют" }, new EnterpriseType() { Name = "Организация по отлову и приют" },
            //new EnterpriseType() { Name = "Организация по транспортировке" }, new EnterpriseType() { Name = "Ветеринарная клиника: муниципальная" }, new EnterpriseType() { Name = "Ветеринарная клиника: частная" },
            //new EnterpriseType() { Name = "Благотворительный фонд" }, new EnterpriseType() { Name = "Организации по продаже товаров и предоставлению услуг для животных" }, new EnterpriseType() { Name="Ветеринарная клиника: государственная" },
            //new EnterpriseType() { Name = "Исполнительный орган государственной власти" }, new EnterpriseType() { Name = "Орган местного самоуправления" }};
            //dataContext.Set<EnterpriseType>().AddRange(types);
            //List<ManagementTerritory> newTers = new List<ManagementTerritory> { new ManagementTerritory() { Name = "Тюмень" }, new ManagementTerritory() { Name = "Рязань" }, new ManagementTerritory() { Name = "Москва" } };
            //dataContext.Set<ManagementTerritory>().AddRange(newTers);
            //List<Role> roles = new List<Role> { new Role() { Name = "Куратор ВетСлужбы" }, new Role() { Name = "Куратор ОМСУ" }, new Role() { Name = "Куратор по отлову" }, new Role() { Name="Куратор приюта" },
            //new Role() {Name = "Подписант ВетСлужбы" }, new Role() { Name = "Подписант ОМСУ" }, new Role() {Name = "Подписант по отлову" }, new Role() { Name = "Подписант приюта" }, new Role() {Name = "Оператор ВетСлужбы" },
            //new Role() { Name="Оператор ОМСУ" } };
            //dataContext.Set<Role>().AddRange(roles);
            //dataContext.SaveChanges();
            //Role role = dataContext.Set<Role>().FirstOrDefault(c => c.Name == "Гость");
            //ManagementTerritory territory = dataContext.Set<ManagementTerritory>().FirstOrDefault(c => c.Name == "Рязань");
            //User user = new User { Name = "Антонов Сергей Юрьевич", Role = role, ManagementTerritory = territory, Address = "Рязань, ул. Ленина 44, 161", TelephoneNumber = "89221937831", Login = "user3", Password = "user3" };
            //dataContext.Set<User>().Add(user);
            //dataContext.SaveChanges();
            try
            {
                Application.Run(new RegistryForm(unitOfControl));
            }
            catch(Exception ex)
            {
                Logger.Fatal($"Приложение не запущено - {ex.Message}");
            }
        }

    }


}
