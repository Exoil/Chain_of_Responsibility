using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ChainofResponsibility
{
    public enum RequestType
    {
        FIRSTREQUEST =1000,
        SECONDREQUEST = 2000,
        THIRDREQUEST = 3000,
        FOURTHREQUEST = 4000
        
    }

    public abstract class Handler
    {
        protected Handler nextHandler;

        public Handler(Handler concreteHandler)
        {
            this.nextHandler = concreteHandler;
        }

        abstract public void HandleRequest(RequestType request);
     
    }


    public class FirstHandler : Handler
    {
        public FirstHandler(SecondHandler concreteHandler): base(concreteHandler)
        {

        }

        public override void HandleRequest(RequestType request)
        {
            if (request == RequestType.FIRSTREQUEST)
            {
                Console.WriteLine("I will handle this: {0}", request);
            }

            else
            {
                Console.WriteLine("Oh no, somebody else will handle it!");
                nextHandler.HandleRequest(request);
            }
        }
    }

    public class SecondHandler : Handler
    {
        public SecondHandler(ThirdHandler concreteHandler) : base(concreteHandler)
        {
        }

        public override void HandleRequest(RequestType request)
        {
            if (request == RequestType.SECONDREQUEST)
            {
                Console.WriteLine("I will handle this: {0}", request);
            }

            else
            {
                Console.WriteLine("Oh no, somebody else will handle it!");
                nextHandler.HandleRequest(request);
            }
        }
    }

    public class ThirdHandler : Handler
    {
        public ThirdHandler(FourthHandler concreteHandler) : base(concreteHandler)
        {

        }

        public override void HandleRequest(RequestType request)
        {
            if (request == RequestType.THIRDREQUEST)
            {
                Console.WriteLine("I will handle this: {0}", request);
            }

            else
            {
                Console.WriteLine("Oh no, somebody else will handle it!");
                nextHandler.HandleRequest(request);
            }
        }
    }

    public class FourthHandler : Handler
    {
        public FourthHandler(Handler concreteHandler) : base(concreteHandler)
        {

        }

        public override void HandleRequest(RequestType request)
        {
            Console.WriteLine("I will handle every request");
        }
    }
}
