using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETAPP.Application.Common.Interfaces;

public interface IUserContext
{
    //public string? UserName { get; set; }
    public int? UserId { get; }
    //int? StoreId { get; }
    //int? RoleId { get; }
}
