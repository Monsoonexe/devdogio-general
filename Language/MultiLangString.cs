namespace Devdog.General
{
    [System.Serializable]
    public struct MultiLangString
    {
        public string title;
        public string message;

        public MultiLangString(string title, string message)
        {
            this.title = title;
            this.message = message;
        }

        public override string ToString()
        {
            return MessageToString();
        }

        public string TitleToString(params object[] vars)
        {
            return ToString(title, vars);
        }

        public string MessageToString(params object[] vars)
        {
            return ToString(message, vars);
        }

        private string ToString(string msg, object[] vars)
        {
            try
            {
                return string.Format(msg, vars);
            }
            catch
            {
                DevdogLogger.LogWarning("Invalid string.Format :: " + msg);
            }

            return msg;
        }
    }
}