﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.BL.Controller
{
    public  class ControllerBase
    {
        /// <summary>
        /// Сохранение в файл
        /// </summary>
        protected void Save(string fileName , object item )

       
        {

          
            var formator = new BinaryFormatter();
            using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formator.Serialize(fileStream, item);
            }

        }
        protected T Load<T>(string fileName)
        {
            var formator = new BinaryFormatter();
            using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fileStream.Length >0 && formator.Deserialize(fileStream) is T items)
                {
                    
                    return items;
                }
                else
                {
                    return default(T);
                }
            }
        }
    }
}
