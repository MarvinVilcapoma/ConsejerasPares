using Common;
using Common.Logging;
using Domain;
using Infraestructure.Context;
using System;
using System.Linq;

namespace Service
{
    public class UserService
    {
        public ICustomLog Logger { get; set; }
        private readonly IConfigurationLib config;
        public ITransaction Transaction { get; set; }

        public UserService(IConfigurationLib _config, ICustomLog _customLog)
        {
            config = _config;
            Logger = _customLog;
        }

        public EResponseBase<User> Get()
        {
            Logger.InitializeLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, Transaction);
            EResponseBase<User> response;
            try
            {
                using (var context = new ClientDbContext())
                {
                    var users = context.Users.ToList();
                    /*IQueryable<User> query = context.Users.Where(x => x.Enabled == true);*/
                    response = new UtilitariesResponse<User>(config).setResponseBaseForList(users);
                }
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<User>(config).setResponseBaseForException(e);
                Logger.Error(e.Message);
            }

            return response;
        }
    }
}
