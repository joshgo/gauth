using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

namespace gauth
{
	public class KeyManager
	{
		private Dictionary<string, string> m_accountKeys;
		private string m_filename;

		public KeyManager() : this(".gauth")
		{
		}

		public KeyManager(string filename)
		{
			if (filename == null)
				m_filename = ".gauth";
			else
				m_filename = filename;

			if (!File.Exists(m_filename))
			{
				m_accountKeys = new Dictionary<string, string>();
				Save();
			}
			else
			{
				using (var file = new StreamReader(m_filename))
				{
					m_accountKeys = JsonConvert.DeserializeObject<Dictionary<string, string>>(file.ReadToEnd())
						.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
				}
			}
		}

		public void Set(string name, string key)
		{
			if (name == null || name.Trim().Length == 0)
				throw new ArgumentException("[name] must be specified");
			if (key == null || key.Trim().Length == 0)
				throw new ArgumentException("[key] must be specified");

			string illegalCharacterMessage = "";
			for(int i = 0; i < key.Trim().Length; i++)
			{
				if (key[i] == ' ')
					continue;

				if (!"ABCDEFGHIJKLMNOPQRSTUVWXYZ234567".Contains(char.ToUpper(key[i])))
					illegalCharacterMessage += "Illegal character: " + key[i] + Environment.NewLine;
			}
			if (illegalCharacterMessage.Length > 0)
				throw new ArgumentException("[key] contains illegal characters.\n" + illegalCharacterMessage);

			m_accountKeys[name] = key;
			Save();
		}

		public string Get(string name)
		{
			string key = "";

			if (!m_accountKeys.TryGetValue(name, out key))
				throw new ArgumentException(string.Format("[{0}] not found", name));

			var secret = GoogleAuthenticator.Base32String.Instance.Decode(key);
			GoogleAuthenticator.PasscodeGenerator passgen = new GoogleAuthenticator.PasscodeGenerator(new System.Security.Cryptography.HMACSHA1(secret));
			return passgen.GenerateTimeoutCode();
		}

		public void Del(string name)
		{
			if (!m_accountKeys.ContainsKey(name))
				return;

			m_accountKeys.Remove(name);
			Save();
		}

		private void Save()
		{
			using (var file = new StreamWriter(m_filename))
			{
				file.WriteLine(JsonConvert.SerializeObject(m_accountKeys));
			}
		}
	}
}
