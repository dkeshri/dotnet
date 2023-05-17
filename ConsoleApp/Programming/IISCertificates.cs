using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using DesignPrincipal.Basic.Interface;

namespace ConsoleApp.Programming{
    public class IISCertificates : IExecute
    {
        private void GetInstalledIISCretificates(){
           List<X509Certificate2> certificates = new List<X509Certificate2>();

        X509Store store1 = new X509Store(StoreName.My, StoreLocation.LocalMachine);
          try
          {
              store1.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

              foreach (var certificate in store1.Certificates)
              {
                  foreach (var extension in certificate.Extensions)
                  {
                      if (extension.Oid.FriendlyName == "Enhanced Key Usage" && extension is X509EnhancedKeyUsageExtension enhancedKeyUsageExtension)
                      {
                          foreach (var item in enhancedKeyUsageExtension.EnhancedKeyUsages)
                          {
                              if (item.FriendlyName == "Server Authentication")
                              {
                                  certificates.Add(certificate);
                              }
                          }
                      }
                  }
              }
          }
          finally
          {
              store1.Close();
          }
      }
        
        
        
        public void run()
        {
            //fibonacciSerise(8);
            //SeriseOfArmstrongNumber(1000);
        }
    }
}
