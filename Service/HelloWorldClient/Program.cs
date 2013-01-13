using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//CTRL+F5 para hacer correr
/*Les dejo este ejemplo de WCF que es lo más sencillito que existe, vean bien lo que se hace, no es tan complicado, si el proyecto
 * les jala un error que dice : referencia no enconetrada o simplemente no compila, agreguen la referencia al servicio: Service, 
 * bueno muchachos solo nos queda comenzar, esta tarde intentaré cambiar el proyecto a lo que es WCF saludos aca hay otro ejemplo: http://blogs.msdn.com/b/jmeier/archive/2007/10/15/how-to-create-a-hello-world-wcf-service-using-visual-studio.aspx*/
namespace HelloWorldClient
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            HelloWorldClient.MyService.ServiceClient cliente = new MyService.ServiceClient();
            string hola = cliente.GetData(i);
            Console.Write(hola);
        }
    }
}
