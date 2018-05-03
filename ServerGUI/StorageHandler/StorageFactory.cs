using System;
using System.Collections.Generic;
using System.Text;

namespace StorageHandler
{
    public static class StorageFactory
    {
        public static IStorageService GetService()
        {
            return new StorageService();
        }
    }
}
