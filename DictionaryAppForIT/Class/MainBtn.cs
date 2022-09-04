using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryAppForIT
{
    static class MainBtn
    {
        static bool isMax = false;
        static Point old_location, default_location;
        static Size old_size, defailt_size;

        public static void SetInitial(Form form)
        {
            old_location = form.Location;
            old_size = form.Size;
            default_location = form.Location;
            defailt_size = form.Size;
        }

        static void Maximize(Form form)
        {
            int x = SystemInformation.WorkingArea.Width;
            int y = SystemInformation.WorkingArea.Height;
            form.WindowState = FormWindowState.Normal;
            form.Location = new Point(0, 0);
            form.Size = new Size(x, y);
        }

        public static void DoMaximize(Form form, Button btn)
        {
            if (isMax == false)
            {
                old_location = new Point(form.Location.X, form.Location.Y);
                old_size = new Size(form.Size.Width, form.Size.Height);
                Maximize(form);
                isMax = true;
            }
            else
            {
                form.Location = old_location;
                form.Size = old_size;
                isMax = false;
            }
        }

        public static void Minnimize(Form form)
        {
            if (form.WindowState == FormWindowState.Minimized)
                form.WindowState = FormWindowState.Normal;
            else if (form.WindowState == FormWindowState.Normal)
                form.WindowState = FormWindowState.Minimized;
        }

        public static void Exit()
        {
            Application.Exit();
        }

        public static void Close(Form form)
        {
            form.Close();
        }

    }
}
