/*******************************************************************************
 * 作者：星星    
 * 描述：缓存工厂   
 * 修改记录： 
*********************************************************************************/

namespace Galaxy.Code
{
    public class CacheFactory
    {
        public static ICache Cache()
        {
            return new MemoryCache();
        }
    }
}
