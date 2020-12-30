using System;
using System.Collections.Generic;

namespace TemplateHttpServer
{

    public class HttpServer
    {
        private IHandler firstHandler;

        public HttpServer(IHandler step)
        {
            firstHandler = step;
        }
        public void AcceptRequest(HttpContext req)
        {
            firstHandler.Handle(req);
        }
    }

    public class HttpContext
    {
        public HttpRequest Request { get; set; }
        public HttpResponse Response { get; set; }
    }

    public class HttpResponse
    {
        public int SratusCode { get; set; }
        //...
    }

    public class HttpRequest
    {
        public string Method { get; set; }
        public string HttpVersion { get; set; }
        public string Route { get; set; }
        public string HostName { get; set; }
        public Dictionary<string,string>  Headers{ get; set; }
        public string  Body { get; set; }

    }       
    public interface IHandler
    {
        void Handle(HttpContext req);
        IHandler Next { get; set; }
    }
    public class AuthorizeHandler : IHandler
    {
        public IHandler Next { get ; set ; }

        public void Handle(HttpContext req)
        {
            Console.WriteLine("Authorizing.. ");
            //...
            if(Next != null)
            {
                Next.Handle(req);
            }
        }
    }
    public class CheckBodyHandler : IHandler
    {
        public IHandler Next { get; set; }

        public void Handle(HttpContext req)
        {
            Console.WriteLine("Validating body... ");
            //...
            if (Next != null)
            {
                Next.Handle(req);
            }
        }
    }
    public class ProcessFinalRequestHandler : IHandler
    {
        public IHandler Next { get; set; }

        public void Handle(HttpContext req)
        {
            Console.WriteLine("Processing request... ");
            //...
            if (Next != null)
            {
                Next.Handle(req);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AuthorizeHandler h1 = new AuthorizeHandler();
            CheckBodyHandler h2 =new  CheckBodyHandler();
            ProcessFinalRequestHandler h3 = new ProcessFinalRequestHandler();
             //chain of responsibility
            h1.Next = h2;
            h2.Next = h3;

            HttpServer server = new HttpServer(h1);
        }
    }
}
