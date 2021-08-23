using MetroFramework;
using System.Collections.Generic;

namespace IntegrateOS
{
    /// <summary>
    /// Clasa ce contine toate datele programului
    /// </summary>
    class IntegrateOS_Data
    {
        public static bool Dark => Themes.MetroTheme == MetroThemeStyle.Dark;
        public static int verify_windows_boolean = 1;
        public static List<string> list_of_history_codes;
        public static List<string> files;
        public static User user;
    }
}
