﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MNV.Domain.Models.Authentication
{
    public class RefreshTokenModel
    {
        public long ID { get; set; }
        public long AppUserID { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public bool IsExpired => DateTime.Now >= Expires;
        public DateTime Created { get; set; }
        public string CreatedByIp { get; set; }
        public DateTime? Revoked { get; set; }
        public string RevokedByIp { get; set; }
        public string ReplacedByToken { get; set; }
        public bool IsActive => Revoked == null && !IsExpired;
    }
}
