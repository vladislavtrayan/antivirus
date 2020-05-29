using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Antivirus.DataSourceAccess;
using Antivirus.DataSourceAccess.Repository;
using DataSourceAccess;
using Signature = DataSourceAccess.Signature;
using Virus = DataSourceAccess.Virus;

namespace Antivirus.Scanner.Service
{
    public class ScannerService : IScannerService
    {
        private static IEnumerable<Signature> _signatures;
        private ISignatureRepository _signatureRepository;
        private IVirusRepository _virusRepository;

        public ScannerService(ISignatureRepository signatureRepository,
            IVirusRepository virusRepository)
        {
            _signatureRepository = signatureRepository;
            _virusRepository = virusRepository;
        }
            
        public IDictionary<string, bool> Scan(string path)
        {
            _signatures = _signatureRepository.GetAllItems();
            var files = Directory.GetFiles(path,  "*.*", System.IO.SearchOption.AllDirectories);
            return files.ToDictionary(file => file, file => IsVirus(file));
        }

        private bool IsVirus(string file)
        {
            var actualResult = false;
            using (var sr = new StreamReader(file, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var a = _signatures;
                    foreach (var signature in _signatures)
                    {
                        if (line.Contains(signature.ActualSignature))
                        {
                            _virusRepository.Add(new Virus()
                            {
                                SignatureId = signature.SignatureId,
                                Signature = signature,
                                FilePath = file
                            });
                            return true;
                        }   
                    }
                }

                return false;
            }
        }
    }
}