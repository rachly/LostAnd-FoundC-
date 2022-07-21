using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvereyDay 
{
    class Program
    {
        static void Main(string[] args)
        {
            BL.EmailService emailService = new BL.EmailService();
            emailService.emailsend();
        }
    }
}
