
namespace addressbook_web_tests
{
    class Square : Figure
    {
        private int size;

        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        public Square(int size)
        {
            this.size = size;
        }
    }
}
