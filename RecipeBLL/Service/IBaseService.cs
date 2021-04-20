﻿using RecipeBLL.DTO;
using RecipeCommon.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBLL.Service
{
  public  interface IBaseService<TDTO> where TDTO : BaseDTO
    {
        ActionResponse<IQueryable<TDTO>> GetAll();
        ActionResponse<TDTO> GetById(int id);
        ActionResponse Remove(int id, int userId = 0);
        ActionResponse Save(TDTO obj, int userId = 0);
    }

}
