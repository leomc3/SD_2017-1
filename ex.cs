using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Threadix
{
    public class ex
    {
        private string mensagem;
        private object locker = new object();
        public string GerarMensagem()
        {
            var chars = "qwertyuiopasdfghjklzxcvbnm";
            var random = new Random();
            mensagem = new string(Enumerable.Repeat(chars, 80).Select(s => s[random.Next(s.Length)]).ToArray());
            return mensagem;
        }

        private int EncontrarIndice()
        {
            for (var i = 0; i < mensagem.Length; i++)
            {
                if (mensagem[i].ToString() != mensagem[i].ToString().ToUpper())
                {
                    return i;
                }
            }
            return -1;
        }

        private bool IsUppe()
        {
            if (mensagem.ToUpper() == mensagem)
            {
                return true;
            }
            return false;            
        }       

        private void PassToUpper()
        {
            while (!this.IsUppe())
            {
                Monitor.Enter(locker);                
                int i = EncontrarIndice();
                if(i != -1)
                {
                    string caracter = mensagem[i].ToString();
                    caracter = caracter.ToUpper();
                    mensagem = mensagem.Remove(i, 1);
                    mensagem = mensagem.Insert(i, caracter);
                    Thread.Sleep(1000);
                }
                Monitor.Exit(locker);
            }
        }

        public bool Desafio()
        {
            Console.WriteLine("Mensagem Inicial: " + this.GerarMensagem());
            List<Thread> threads = new List<Thread>();
            for(var i = 0; i < 30; i++)
            {
                new Thread(PassToUpper).Start();
            }
            if (this.IsUppe())
            {
                Console.WriteLine();
                Console.WriteLine("Resultado: " + mensagem);
                Console.WriteLine();
                Console.WriteLine("FIM!");
            }
            return true;
        }
    }
}
