﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelLayer
{
   public interface IMailInfoRepository
    {
       void Update(MailBilgi mailBilgi);
        MailBilgi Get();
    }
}
