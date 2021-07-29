using Sensores.Radix.Domain.Entity;
using Sensores.Radix.Domain.Events.Repository;
using Sensores.Radix.Infra.Data.DbContexts;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Sensores.Radix.Infra.Data.Repositories
{
    public class SensorEventRepository : Repository<SensorEvent>, ISensorEventRepository
    {
        public SensorEventRepository(SensorEventContext Context) : base(Context) { }
        public async Task<IEnumerable<SensorEvent>> GetAllNumericsEvents()
        {
            var sql = @"SELECT Id
                             , Country
                             , Region
   	                         , SensorName
   	                         , Valor
   	                         , Timestamp
                          FROM tblSensorEvents
                         WHERE ISNUMERIC(Valor) = 1";

            return await FromSql(sql, null);
        }
    }
}
