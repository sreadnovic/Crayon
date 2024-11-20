using Crayon.API.Model;

namespace Crayon.API.DB
{
    public static class DbMock
    {
        public static List<Account> Accounts;
        public static List<AccountSoftwareService> AccountServices;
        public static List<SoftwareService> SoftwareServices;
        public static List<SoftwareServiceLicence> SoftwareServiceInstances;

        public static void Seed()
        {
            var account1 = new Account { Id = 1, Name = "Account_1", BearerId = "3fbcbc20" };
            var account2 = new Account { Id = 2, Name = "Account_2", BearerId = "69a19314" };

            var officeService = new SoftwareService { Id = 1, Name = "Microsoft Office" };
            var oracleService = new SoftwareService { Id = 2, Name = "Oracle Server" };

            var licence1 = new SoftwareServiceLicence { Id = 1, SoftwareService = officeService, ValidTo = new DateTime(2024, 12, 31), Status = true };
            var licence2 = new SoftwareServiceLicence { Id = 2, SoftwareService = officeService, ValidTo = new DateTime(2025, 06, 30), Status = true };
            var licence3 = new SoftwareServiceLicence { Id = 3, SoftwareService = oracleService, ValidTo = new DateTime(2025, 01, 31), Status = true };
            var licence4 = new SoftwareServiceLicence { Id = 4, SoftwareService = oracleService, ValidTo = new DateTime(2025, 02, 15), Status = true };
            var licence5 = new SoftwareServiceLicence { Id = 5, SoftwareService = oracleService, ValidTo = new DateTime(2025, 03, 31), Status = true };

            Accounts = new List<Account>{ account1, account2};

            SoftwareServices = new List<SoftwareService> { officeService, oracleService };

            AccountServices = new List<AccountSoftwareService>
            {
                new AccountSoftwareService { Account = account1, Licences = new List<SoftwareServiceLicence> {licence1, licence3 } },
                new AccountSoftwareService { Account = account2, Licences = new List<SoftwareServiceLicence> {licence2, licence4, licence5 } }
            };

            SoftwareServiceInstances = new List<SoftwareServiceLicence>
            {
                licence1, licence2, licence3, licence4, licence5
            };
        }
    }
}
