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
			m_accountKeys[name] = key;
			Save();
		}

		public string Get(string name)
		{
			string key = "";

			if (!m_accountKeys.TryGetValue(name, out key))
				return "!! NOT FOUND !!";

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
