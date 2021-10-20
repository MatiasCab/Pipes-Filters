using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using TwitterUCU;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {

            PictureProvider provider = new PictureProvider();
            IPicture picture1 = provider.GetPicture(@".\beer.jpg");//".\" para decir que estoy parado en esta carpeta

            IFilter grey = new FilterGreyscale();
            IFilter negative = new FilterNegative();

            PipeNull pipeNull = new PipeNull();
            PipeSerial pipe2 = new PipeSerial(negative,pipeNull);
            PipeSerial pipe1 = new PipeSerial(grey,pipeNull);
            PipeConditional conditional= new PipeConditional(pipe1,pipe2);
            
            conditional.ContainsFace(@".\beer.jpg");

            conditional.Send(picture1);
        }
    }
}
