using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;
using CognitiveCoreUCU;
using System.Drawing;
using TwitterUCU;


namespace CompAndDel.Pipes
{
    public class PipeConditional : IPipe
    {
        public IPipe   nextPipe; //variable que guarda un pipe para el resultado condicional

        public IPipe next2Pipe; //variable que guarda un pipe para el resultado condicional

        private IPipe electivePipe;//En esta variable guardo el pipe resultado, luego de hacer la condicioal con Cognitive

        public CognitiveFace cog;// varaible donde guardo una instacia de la clase cognitive, esto lo hago siguiendo las bases de la composcion y delegacion

        public PipeConditional(IPipe nextPipe, IPipe next2Pipe) 
        {
            this.next2Pipe = next2Pipe;
            this.nextPipe = nextPipe;
            this.cog = new CognitiveFace(false);
        }
        public IPicture Send(IPicture picture)
        {
            return this.electivePipe.Send(picture);//Envio la imagen al pipe elegido
        }
        public void ContainsFace(string path)//Este metdod contiene la logica de la condicionante, le ingreso la direccion de una imagen, y Cognitive face se encaraga de determnar si posee una cara o no
        {
            //aca estoy delegando la responsabilidad de determinar si una imagne tiene una cara, a cognitive face
            this.cog.Recognize(path);
            if (this.cog.FaceFound)//en vase al resultado de faceFound, gudardo en elective pipe, el pipe correcto
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
