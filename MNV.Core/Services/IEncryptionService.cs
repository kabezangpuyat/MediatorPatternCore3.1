using System;
using System.Collections.Generic;
using System.Text;

namespace MNV.Core.Services
{
    public interface IEncryptionService
    {
        string Encrypt(string input);
        string Decrypt(string input);
    }
}
