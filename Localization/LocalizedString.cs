using UnityEngine;

namespace Devdog.General.Localization
{
    [System.Serializable]
    public struct LocalizedString
    {
        /// <summary>
        /// Gets the message in the currently selected language.
        /// </summary>
        [IgnoreCustomSerialization]
        public string message
        {
            get
            {
                return LocalizationManager.GetString(_key);
            }
            set
            {
                if (LocalizationManager.currentDatabase != null)
                {
                    LocalizationManager.currentDatabase.SetString(_key, value);
                }
            }
        }

        [SerializeField]
        private string _key;

        public string Key
        {
            get
            {
                return KeyOrDefault(_key);
            }
            set
            {
                _key = KeyOrDefault(value);
            }
        }

        private static string KeyOrDefault(string query)
        {
            return string.IsNullOrEmpty(query) ? LocalizationManager.NoKeyConstant : query;
        }

        public LocalizedString(string key)
        {
            _key = key;
        }

        public override string ToString()
        {
            return message;
        }
    }
}
