﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoiceasy.Interface
{
    public interface IConfigService
    {
        IDatabaseContext DatabaseContext { get; }
    }
}
