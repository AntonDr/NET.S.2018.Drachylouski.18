using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    public struct DalAccountHolder:IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
