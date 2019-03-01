namespace Training
{
    class EventClass
    {
        public delegate void MyDelegate(int number, int secondNumber);

        public event MyDelegate MyAction;

        public int ReturnFirstNumber(int number)
        {
            return number * 2;
        }
        public int ReturnSecondNumber(int secondNumber)
        {
            return secondNumber * 2;
        }

        public int ReturnSum()
        {
            MyAction(ReturnFirstNumber(12), ReturnSecondNumber(34));

            return ReturnFirstNumber(12) + ReturnSecondNumber(34);
        }
    }
}
