using System;
using System.Threading;
using Training.Volvo;

//https://medium.com/@mail2sagarsalunkhe/understanding-delegates-and-events-in-c-7093ad8a22e7  (include good explanation for events)
//https://buraksenyurt.com/post/C-Temelleri-Olaylar%C4%B1(Events)-Kavramak-bsenyurt-com-dan

//Events are responsible for communication between objects.

//Delegate which specifies that that event handler method should be void and should accept two arguments.!!!!!

namespace Training
{    
    class Program
    {
        
        public delegate double OperationDelegate(double numn1, double numb2);

        public static double AddOperation(double n1, double n2)
        {
            Console.WriteLine("In AddOperation Method = " + (n1 + n2).ToString());
            return n1 + n2;
        }

        public static double MultiplyOperation(double n1, double n2)
        {
            Console.WriteLine("In MultiplyOperation Method = " + (n1 * n2).ToString());
            return n1 * n2;
        }

        static void Main(string[] args)
        {
            #region first
            Console.WriteLine("OperationDelegate1");
            OperationDelegate operationDelegate1 = AddOperation;
            Console.WriteLine(operationDelegate1(3, 7));

            Console.WriteLine();

            Console.WriteLine("OperationDelegate2");
            OperationDelegate operationDelegate2 = new OperationDelegate(MultiplyOperation);
            operationDelegate2 += AddOperation;
            Console.WriteLine(operationDelegate2(4, 5));

            Console.WriteLine();

            Console.WriteLine("OperationDelegate3");
            OperationDelegate operationDelegate3 = new OperationDelegate((n1, n2) =>
            {
                Console.WriteLine("Lambda and delegate = " + (n1 - n2).ToString());
                return n1 - n2;
            });
            operationDelegate3 += AddOperation;
            operationDelegate3(29, 7);

            Console.WriteLine("\n*************************Training for events*************************\n");

            VolvoV40 myCar = new VolvoV40(10, 150, 20);
            Mail mail = new Mail();

            myCar.MaxSpeedWarning+= mail.SendMailAboutMaxSpeed;
            myCar.MaxSpeedWarning += ShowChildrenPicture;


            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i + ". step speed = " + myCar.Speed);
                myCar.UpSpeed();
                Thread.Sleep(500);
                if ((myCar.Speed - myCar.MaxSpeed) > myCar.SpeedIncrease * 5)
                {
                    break;
                }
            }

            Console.WriteLine("Last speed = " + myCar.Speed);
            Console.WriteLine("First Mission Completed :)");
            #endregion

            #region second
            Console.WriteLine("\n\n\n");
            EventClass eventdemo = new EventClass();
            eventdemo.MyAction += delegate (int number, int secondNumber)
            {
                Console.WriteLine("We have the result after calling the delegate: \nFirst number: " + number + "\nSecond number: " + secondNumber);
            };

            Console.WriteLine("The result and launch of the event is due to calling the method 'event.ReturnSum()' = " + eventdemo.ReturnSum());
            Console.WriteLine("Second Mission Completed :)");
            #endregion


            Console.ReadKey();
        }

        public static void ShowChildrenPicture(object obj, SpeedEventArgs args)
        {
            Console.WriteLine("Children Picture");
        }
    }

    class Mail
    {
        public void SendMail(string mail)
        {
            Console.WriteLine(mail);
        }

        public void SendMailAboutMaxSpeed(object obj, SpeedEventArgs args)
        {
            this.SendMail("You have exceeded the speed limit. Speed = "+args.Speed);
        }
    }
}
