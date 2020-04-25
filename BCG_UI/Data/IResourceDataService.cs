﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCG_UI.Data
{
    public interface IResourceDataService
    {
        Task<Resources> GetByIdAsync(int resourceId);
        Task SaveAsync(Resources resource);
    }
}
