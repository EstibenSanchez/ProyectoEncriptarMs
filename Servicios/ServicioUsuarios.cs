

using Newtonsoft.Json;
using ProyectoEncriptarMs.Modelo;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ProyectoEncriptarMs.Servicios
{
    public class ServicioUsuarios
    {
        private String key = "basdsadfasgdf.,lkf32sad";
        public List<Usuario> Postt(List<Usuario> usuario)
        {
            try
            {
                TripleDESCryptoServiceProvider des;
                MD5CryptoServiceProvider md5;

                byte[] keyhash, buff, buff1;

                md5 = new MD5CryptoServiceProvider();
                keyhash = md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(key));

                md5 = null;
                des = new TripleDESCryptoServiceProvider();

                des.Key = keyhash;
                des.Mode = CipherMode.ECB;
                foreach (var x in usuario)
                {
                    buff = Convert.FromBase64String(x.correo);
                    buff1 = Convert.FromBase64String(x.password);

                    x.correo = ASCIIEncoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock(buff, 0, buff.Length));
                    x.password = ASCIIEncoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock(buff1, 0, buff1.Length));
                    
                  
                }
              

            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
            }
            return usuario;

        }

        
    }
}
