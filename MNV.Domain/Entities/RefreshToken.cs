using System;
using System.Collections.Generic;
using System.Text;

namespace MNV.Domain.Entities
{
    public class RefreshToken
    {
        public long ID { get; set; }
        public long UserID { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public DateTime Created { get; set; }
        public string CreatedByIp { get; set; }
        public DateTime? Revoked { get; set; }
        public string RevokedByIp { get; set; }
        public string ReplacedByToken { get; set; }
        public bool IsActive => Revoked == null && !IsExpired;

        public User User { get; set; }
    }
}
