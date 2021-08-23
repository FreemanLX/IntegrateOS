using MetroFramework;
using MetroFramework.Components;

namespace IntegrateOS
{

    public static class Themes
    {
        public static MetroColorStyle MetroColor;
        public static MetroThemeStyle MetroTheme;
        public static MetroStyleManager Generate => new MetroStyleManager { Theme = MetroTheme, Style = MetroColor };
        public static System.Drawing.Image Icon_Style => (MetroTheme == MetroThemeStyle.Default || MetroTheme == MetroThemeStyle.Light) ? Resources.white_left_arrow : Resources.black_left_arrow;
        public static System.Drawing.Color GenerateTheme(MetroThemeStyle metroThemeStyle) => 
            (metroThemeStyle == MetroThemeStyle.Default || metroThemeStyle == MetroThemeStyle.Light) ? System.Drawing.Color.White : System.Drawing.Color.Black;
    }
}
