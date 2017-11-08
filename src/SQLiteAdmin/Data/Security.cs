/* Copyright Xeno Innovations, Inc. 2011-2017
 * Author:  Damian Suess
 * Date:    2017-10-20
 * File:    Security.cs
 * Description:
 *  Lite security system so we don't save raw data.
 *
 * Note:
 *  The password and PasswordDerrivedBytes is just random junk
 *
 * Change Log:
 *  2017-1020 * Initial creation
 */

using System;
using System.IO;
using System.Security.Cryptography;

namespace Xeno.SQLiteAdmin.Data
{
  public class Security
  {
    private const string Password = "BBCF22844A9043C8A383A5D50EC759D54C353CF908948A4B77B41C6E87427C2";

    private static readonly byte[] Salt = new byte[] { 0xC4, 0xAE, 0x4F, 0x95, 0x36, 0x74, 0x95, 0xA8, 0xCD, 0xDD, 0xEB, 0xFB, 0x14, 0x57 };

    /// <summary>Decrypt data</summary>
    /// <param name="data">Encrypted Base64 data</param>
    /// <returns>Decrypted string</returns>
    public static string Decrypt(string data)
    {
      byte[] bCrypt = Convert.FromBase64String(data);

      PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, Salt);

      MemoryStream memory = new MemoryStream();
      Rijndael rj = Rijndael.Create();
      rj.Key = pdb.GetBytes(32);
      rj.IV = pdb.GetBytes(16);

      CryptoStream crypto = new CryptoStream(memory, rj.CreateDecryptor(), CryptoStreamMode.Write);
      crypto.Write(bCrypt, 0, bCrypt.Length);
      crypto.Close();

      byte[] decrypted = memory.ToArray();
      return System.Text.Encoding.Unicode.GetString(decrypted);
    }

    /// <summary>Encrypt data</summary>
    /// <param name="data">Data input</param>
    /// <returns>Base64 string</returns>
    public static string Encrypt(string data)
    {
      byte[] bData = System.Text.Encoding.Unicode.GetBytes(data);
      PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, Salt);

      MemoryStream memory = new MemoryStream();
      Rijndael rj = Rijndael.Create();
      rj.Key = pdb.GetBytes(32);
      rj.IV = pdb.GetBytes(16);

      CryptoStream crypto = new CryptoStream(memory, rj.CreateEncryptor(), CryptoStreamMode.Write);
      crypto.Write(bData, 0, bData.Length);
      crypto.Close();

      byte[] encData = memory.ToArray();
      return Convert.ToBase64String(encData);
    }
  }
}
