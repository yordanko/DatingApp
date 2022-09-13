using API.Interfaces;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace API.Helpers
{
    interface IHealthCheckProvider
    {
        public HealthCheckResult DatabaseHealthCheck();
    }
    public class HealthCheckProvider : IHealthCheckProvider
    {
        private readonly IUserRepository _userRepository;

        public HealthCheckProvider(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public HealthCheckResult DatabaseHealthCheck()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var users = _userRepository.GetUsersAsync();           
            bool health = users.Wait(3000);
            watch.Stop();
            var timeWaited = watch.Elapsed;

            if (timeWaited.TotalMilliseconds < 300)
                return HealthCheckResult.Healthy("Database is healthy");
            if (timeWaited.TotalMilliseconds < 3000)
                return HealthCheckResult.Degraded("Database degraded");
            

            return HealthCheckResult.Unhealthy("Database is unhealthy");
        }

    }
}
