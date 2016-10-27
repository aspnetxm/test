/*******************************************************************************
 * 作者：星星    
 * 描述：枚举形扩展
 * 修改记录： 
*********************************************************************************/
using System;
using System.Collections.Generic;

namespace Galaxy.Code
{
    public static class EnumExt
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        public static Dictionary<int, string> ToDictionary(this Enum em)
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            var type = em.GetType();
            foreach (var n in Enum.GetValues(em.GetType()))
            {
                dic.Add((int)n, Enum.GetName(type, n));
            }
            return dic;
        }
    }
}
