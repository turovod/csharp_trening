using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    class Circle : Figure
    {
        private int radius;

        public Circle(int circle)
        {
            this.radius = circle;
        }

        public int Radius
        {
            get { return radius; }
            set { radius = value; }
        }
    }
}
