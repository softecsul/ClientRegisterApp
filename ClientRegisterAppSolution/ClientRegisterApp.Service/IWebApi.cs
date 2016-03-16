﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRegisterApp.Service
{
    interface IWebApi<T>
    {
        Task<IEnumerable<T>> GetAll();
        T Get(int id);
        bool Insert(T t);
        bool Update(T t);
        bool Delete(int id);
    }
}
