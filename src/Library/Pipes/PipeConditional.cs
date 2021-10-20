using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;
using CognitiveCoreUCU;


namespace CompAndDel.Pipes
{
    public class PipeConditional : IPipe
    {
        IPipe   nextPipe;

        IPipe next2Pipe;

        IPipe electivePipe;

        public PipeConditional(IPipe nextPipe, IPipe next2Pipe) 
        {
            this.next2Pipe = next2Pipe;
            this.nextPipe = nextPipe;
        }
        public IPicture Send(IPicture picture)
        {
            return this.electivePipe.Send(picture);
        }
        public void ContainsFace(string path)
        {
            CognitiveFace cog = new CognitiveFace(false);
            cog.Recognize(path);
            if (cog.FaceFound)
            {
                electivePipe = this.nextPipe;
            }
            else
            {
                electivePipe = this.next2Pipe;
            }
        }
    }
}
