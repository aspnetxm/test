﻿/*******************************************************************************
 * 作者：星星    
 * 描述：缓存操作接口   
 * 修改记录： 
*********************************************************************************/
using System;
using StackExchange.Redis;

namespace Galaxy.Utility
{
    public class RedisCache : ICache
    {
        static ConnectionMultiplexer _redisConnection = null;    //redis ConnectionMultiplexer

        /// <summary>
        /// redis ConnectionMultiplexer
        /// </summary>
        public ConnectionMultiplexer RedisConnection
        {
            get
            {
                if (_redisConnection == null)
                {
                    var options = ConfigurationOptions.Parse(Configs.GetValue("redispath"));
                    options.SyncTimeout = int.MaxValue;
                    options.AllowAdmin = false;
                    if (!string.IsNullOrWhiteSpace(Configs.GetValue("redispwd")))
                        options.Password = Configs.GetValue("redispwd");

                    return _redisConnection = ConnectionMultiplexer.Connect(options);
                }
                else
                    return _redisConnection;
            }
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">key</param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                new NullReferenceException("Get方法的{key}参数值为空。");

            IDatabase db = RedisConnection.GetDatabase();
            if (db.KeyExists(key))
            {
                string result = db.StringGet(key);
                return Json.Deserialize<T>(result);
            }
            return default(T);
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="data">缓存值</param>
        /// <param name="cacheTime">超时时间（按分钟）</param>
        public void Set(string key, dynamic data, int? expireTime)
        {
            if (string.IsNullOrWhiteSpace(key))
                new NullReferenceException("Get方法的{key}参数值为空。");

            if (data == null)
                new NullReferenceException("Get方法的{data}参数值为空。");

            TimeSpan? t = null;
            if (expireTime.HasValue && expireTime > 0)
                t = new TimeSpan(0, expireTime.Value, 0);

            IDatabase db = RedisConnection.GetDatabase();

            db.StringSet(key, Json.Serialize(data), t);
        }

        /// <summary>
        /// 缓存是否已存在
        /// </summary>
        /// <param name="key">key</param>
        /// <returns></returns>
        public bool Exist(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                new NullReferenceException("Exist方法的{key}参数值为空。");

            IDatabase db = RedisConnection.GetDatabase();
            return exist(db, key);
        }

        bool exist(IDatabase db, string key)
        {
            return db.KeyExists(key);
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">key</param>
        public void Remove(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                new NullReferenceException("Remove方法的{key}参数值为空。");

            IDatabase db = RedisConnection.GetDatabase();
            if (exist(db, key))
                db.KeyDelete(key);
        }

        /// <summary>
        /// 合并key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="prefix">前缀</param>
        /// <returns></returns>
        public string MergeKey(string key, string prefix)
        {
            if (string.IsNullOrWhiteSpace(prefix))
                new NullReferenceException("MergeKey方法的{prefix}参数值为空。");

            return string.Format("{0}:{1}", prefix, key);
        }
    }
}