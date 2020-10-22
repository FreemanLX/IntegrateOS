using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework;
using MetroFramework.Forms;
using MetroFramework.Components;
using System.ComponentModel;

namespace IntegrateOS
{
    public static class Themes
    {
        ///private const MetroColorStyle FormStyle = MetroColorStyle.Green;
        ///
        public static MetroStyleManager generate(MetroColorStyle mcs, MetroThemeStyle mts)
        {
            MetroStyleManager e = new MetroStyleManager();
            e.Theme = mts;
            e.Style = mcs;
            return e;
        }
        public static void SetStyle(this IContainer container, MetroForm ownerForm, MetroColorStyle metrocolor)
        {
            if (container == null)
            {
                container = new System.ComponentModel.Container();
            }
            var manager = new MetroFramework.Components.MetroStyleManager(container);
            manager.Owner = ownerForm;
            container.SetDefaultStyle(ownerForm, metrocolor);


        }
        public static void SetTheme(this IContainer container, MetroForm ownerForm, MetroThemeStyle theme)
        {
            if (container == null)
            {
                container = new System.ComponentModel.Container();
            }
            var manager = new MetroFramework.Components.MetroStyleManager(container);
            manager.Owner = ownerForm;
            container.SetDefaultTheme(ownerForm, theme);


        }
        public static void SetDefaultStyle(this IContainer contr, MetroForm owner, MetroColorStyle style)
        {
            MetroStyleManager manager = FindManager(contr, owner);
            manager.Style = style;
            owner.Style = style;
        }
        public static void SetDefaultTheme(this IContainer contr, MetroForm owner, MetroThemeStyle thme)
        {
            MetroStyleManager manager = FindManager(contr, owner);
            manager.Theme = thme;
        }
        private static MetroStyleManager FindManager(IContainer contr, MetroForm owner)
        {
            MetroStyleManager manager = null;
            foreach (IComponent item in contr.Components)
            {
                if (((MetroStyleManager)item).Owner == owner)
                {
                    manager = (MetroStyleManager)item;
                }
            }
            return manager;
        }

    }
}
