using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Fintalks.Common.Models;

namespace Fintalks.DB.DBEntity
{
    public class DBUserInfo
    {
        public int ID { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public required string Nid { get; set; }
        public required string PhoneNumber { get; set; }
        public int DBUserID { get; set; }
        public DBUser User { get; set; } = null!;
    }
}
