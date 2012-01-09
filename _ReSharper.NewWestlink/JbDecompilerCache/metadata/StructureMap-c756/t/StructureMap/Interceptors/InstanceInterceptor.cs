// Type: StructureMap.Interceptors.InstanceInterceptor
// Assembly: StructureMap, Version=2.6.3.0, Culture=neutral, PublicKeyToken=e60ad81abae3c223
// Assembly location: C:\Code\NewWestlink\packages\structuremap.2.6.3\lib\StructureMap.dll

using StructureMap;

namespace StructureMap.Interceptors
{
    public interface InstanceInterceptor
    {
        object Process(object target, IContext context);
    }
}
