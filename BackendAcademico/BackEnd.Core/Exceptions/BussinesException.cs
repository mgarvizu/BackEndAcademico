using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Core.Exceptions
{
    public class BussinesException : Exception
    {
        public BussinesException()
        {

        }
        public BussinesException(string message) :
            base(message) // se necesita enviar  ya que sino la estrucutra base no sabria que se le mando
        {

        }
        public BussinesException( string message, Exception exception):
            base(message,exception) // se puede colocar para quienes pueden verlos podrian ver los mensajes ue se tiene
        {

        }
    }
}
