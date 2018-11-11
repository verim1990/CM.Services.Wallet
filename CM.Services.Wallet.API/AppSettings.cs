using CM.Shared.Kernel.Application.Settings;
using CM.Shared.Kernel.Others.Kafka;
using CM.Shared.Kernel.Others.Kong;
using CM.Shared.Kernel.Others.Redis;
using CM.Shared.Kernel.Others.Sql;
using CM.Shared.Kernel.Others.Swagger;

namespace CM.Services.Wallet.API
{
    public class AppSettings
    {
        public GlobalSettings Global { get; set; } = new GlobalSettings();

        public LocalSettings Local { get; set; } = new LocalSettings();

        public object GetPublicSettings()
        {
            return new
            {
                ServiceName = Global.Wallet.Name
            };
        }
    }
    public class GlobalSettings
    {
        public KongSettings Kong { get; set; } = new KongSettings();

        public SqlSettings Sql { get; set; } = new SqlSettings();

        public KafkaSettings Kafka { get; set; } = new KafkaSettings();

        public RedisSettings Redis { get; set; } = new RedisSettings();

        public ServiceSettings Web { get; set; } = new ServiceSettings();

        public ServiceSettings Identity { get; set; } = new ServiceSettings();

        public ServiceSettings Exchange { get; set; } = new ServiceSettings();

        public ServiceSettings Wallet { get; set; } = new ServiceSettings();

        public ServiceSettings WalletViews { get; set; } = new ServiceSettings();
    }

    public class LocalSettings
    {
        public SwaggerSettings Swagger { get; set; } = new SwaggerSettings();

        public SqlContextSettings Sql { get; set; } = new SqlContextSettings();

        public KongServiceSettings Kong { get; set; } = new KongServiceSettings();

        public KafkaServiceSettings Kafka { get; set; } = new KafkaServiceSettings();
    }
}