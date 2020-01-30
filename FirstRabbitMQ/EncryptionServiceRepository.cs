using EOM.Kernel.Infrastructure.Interfaces;
using ODX.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstRabbitMQ
{
    public class EncryptionServiceRepository : IEncryptionServiceRepository
    {
        private readonly IDbFactory dbFactory;
        private readonly IOdxLogger logger;

        public EncryptionServiceRepository(IDbFactory dbFactory, IOdxLogger logger)
        {
            this.dbFactory = dbFactory;
            this.logger = logger;
        }

        public Guid GetSiteGuid()
        {
            try
            {
                using (var db = dbFactory.GetConnection())
                {
                    return db.ExecuteScalar<Guid>("select siteguid from website w join shopvisible..sites s on s.siteid = w.shopvisible_site_id");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error in {nameof(EncryptionServiceRepository)} in GetSiteGuid");
                throw;
            }
        }
    }
}
