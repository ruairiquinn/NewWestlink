using Core.Interfaces;
using StructureMap;
using StructureMap.Interceptors;

namespace NewWestlink.Infrastructure.StructureMapArtifacts
{
    public class CustomInterceptor : InstanceInterceptor
    {
        public object Process(object target, IContext context)
        {
            if (target is IClientRepository)
            {
                var clientRepo = target as IClientRepository;
                return clientRepo;
            }

            return target;
        }
    }
}