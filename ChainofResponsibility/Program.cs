using System;

namespace ChainofResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Chain of Responsibility!");

            var handler = new FirstHandler(new SecondHandler(new ThirdHandler(new FourthHandler(null))));

            Console.WriteLine("First Request");

            handler.HandleRequest(RequestType.FIRSTREQUEST);

            Console.WriteLine("Second Request");

            handler.HandleRequest(RequestType.SECONDREQUEST);

            Console.WriteLine("Third Request");

            handler.HandleRequest(RequestType.THIRDREQUEST);

            Console.WriteLine("Fourth Request");

            handler.HandleRequest(RequestType.FOURTHREQUEST);



            Console.WriteLine("End, inputy antihing.");
            Console.ReadLine();
        }
    }
}
