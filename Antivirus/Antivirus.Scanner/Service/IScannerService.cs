using System.Collections.Generic;

namespace Antivirus.Scanner.Service
{
    public interface IScannerService
    {
        IDictionary<string, bool> Scan(string path);
    }
}