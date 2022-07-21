using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineFinder
{
    public class Manager<T> where T : class, new()
    {
        private static volatile T instance = null;
        private static object lockObject = new object();
        public static T Instance
        {
            get
            {
                if(instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new T();
                        }
                        return instance;
                    }
                }
                return instance;
            }
        }
    }
}
