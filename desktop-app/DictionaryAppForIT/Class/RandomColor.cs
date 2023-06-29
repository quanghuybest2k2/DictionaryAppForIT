using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryAppForIT.Class
{
    public class RandomColor
    {
        string[] _color = { "RosyBrown", "OrangeRed", "Chocolate", "SandyBrown", "DarkOrange", "Orange",
                            "DarkKhaki", "Olive", "YellowGreen", "SeaGreen", "Turquoise", "DodgerBlue", "MediumPurple", 
                            "SlateBlue", "MediumOrchid", "HotPink"};
        string _colorRecent;

        public RandomColor()
        {
            _colorRecent = "";
            
        }

        public string GetColor()
        {
            var rd = new Random();
            var color = "";

            do
            {
                color = _color[rd.Next(0, _color.Length)];
            } while (!CheckColor(color));
            return color;
        }

        public bool CheckColor(string color)
        {
            if (color == _colorRecent) 
                return false;
            else 
            {
                _colorRecent = color;
                return true;
            }  
        }
    }
}
