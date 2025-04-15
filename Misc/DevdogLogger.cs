using UnityEngine;

namespace Devdog.General
{
    public static class DevdogLogger
    {
        public enum LogType
        {
            LogVerbose = 0,
            Log = 1,
            Warning = 2,
            Error = 3
        }

        public static LogType minimaLog = LogType.LogVerbose;

        public static bool VerboseEnabled => (int)LogType.LogVerbose >= (int)minimaLog;
        public static bool DebugEnabled => (int)LogType.Log >= (int)minimaLog;
        public static bool WarningEnabled => (int)LogType.Warning >= (int)minimaLog;
        public static bool ErrorEnabled => (int)LogType.Error >= (int)minimaLog;

        public static void LogVerbose(string message)
        {
            if (VerboseEnabled)
            {
                Debug.Log(message);
            }
        }

        public static void LogVerbose(string message, UnityEngine.Object context)
        {
            if (VerboseEnabled)
            {
                Debug.Log(message, context);
            }
        }

        public static void Log(string message)
        {
            Log(message, null);
        }

        public static void Log(string message, UnityEngine.Object context)
        {
            if (DebugEnabled)
            {
                Debug.Log(message, context);
            }
        }

        public static void LogWarning(string message)
        {
            LogWarning(message, null);
        }

        public static void LogWarning(string message, UnityEngine.Object context)
        {
            if (WarningEnabled)
            {
                Debug.LogWarning(message, context);
            }
        }

        public static void LogError(string message)
        {
            LogError(message, null);
        }

        public static void LogError(string message, UnityEngine.Object context)
        {
            if (ErrorEnabled)
            {
                Debug.LogError(message, context);
            }
        }
    }
}
