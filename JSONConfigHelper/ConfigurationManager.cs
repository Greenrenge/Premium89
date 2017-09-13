using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.ExceptionServices;

namespace JSONConfigHelper
{
    public abstract class ConfigLockCheck
    {
        //synchronously read/write all files by this class
        protected static readonly object lockCheck = new object();
    }
    public class ConfigurationManager<T> : ConfigLockCheck where T:new()
    {
        private T _object;
        private JsonSerializerSettings _setting;
        public ConfigurationManager(T obj,JsonSerializerSettings setting=null)
        {
            _object = obj;
            if (setting != null) _setting = setting;
            else setting = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented,
            };
        }
        public void WriteConfig(string absolutePath)
        {
            try
            {
                lock (lockCheck)
                {
                    using (var file = new FileStream(absolutePath, FileMode.OpenOrCreate))
                    {
                        file.SetLength(0);
                        using (var stream = new StreamWriter(file))
                        {
                            var serializer = JsonSerializer.Create(_setting);
                            serializer.Serialize(stream, _object);
                        }

                    }
                }
            }
            catch(Exception ex)
            {
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
            }
        }
        public T ReadConfig(string absolutePath)
        {
            try
            {
                lock (lockCheck)
                {
                    using (var file = new FileStream(absolutePath, FileMode.Open))
                    {
                        using (var stream = new StreamReader(file))
                        {

                            var serializer = JsonSerializer.Create(_setting);
                            var result = serializer.Deserialize(stream,typeof(T));
                            return (T)result;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
            }
            return default(T);
        }

    }
}
