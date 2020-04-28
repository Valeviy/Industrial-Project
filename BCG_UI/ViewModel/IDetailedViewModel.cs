﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCG_UI.ViewModel
{
    public interface IDetailedViewModel
    {
        Task LoadAsync(int? id);
        bool HasChanges { get; }
    }
}
