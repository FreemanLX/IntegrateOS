using MetroFramework;

namespace IntegrateOS
{
    public static class GenerateColors
    {
        public static System.Drawing.Color Generate(int color) => MetroColors.Convert_to_Color((byte)color);
    }
}
