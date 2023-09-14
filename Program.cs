using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions//Hata yönetimi
{
    class Program
    {
        static void Main(string[] args)
        {
            //IntroExecptionHanding();
            try//Kullanıcının görmesini istediğimiz kısımı yazdık (FrontEnd)
            {
                FindWCustomExecption();
            }
            catch (RecordNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
            }
            //Kısa metot hali aşağıda
            //Action Delegation
            HandleException(() =>
            {
                FindWCustomExecption();
            });
            Console.ReadLine();
        }

        private static void HandleException(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public static void IntroExecptionHanding()
        {
            try
            {
                string[] names = new string[3] { "Cem", "Berk", "Batu" };
                names[3] = "Batuhan";
            }
            catch (IndexOutOfRangeException exception)//Catch kısmı alınacak hatanın türünü istersek sorgulayabiliriz
            {
                Console.WriteLine(exception.Message);
            }
            catch (Exception exception)//Exception nesnesine aktarıyor hatayı.
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine(exception.InnerException);//Daha detaylı bir hata yazımı gösterir.
            }
            Console.ReadLine();
        }
        public static void FindWCustomExecption()//Genelde backend kısımlarında oluşturulan bir Logic'dir.
        {
            List<string> students = new List<string> { "Fatma", "Nuriye", "Hayriye" };
            if (!students.Contains("Firdevs"))
            {
                throw new RecordNotFoundException("Record Not Found!");
            }
            else
            {
                Console.WriteLine("Record Founded");
            }
            Console.ReadLine();
        }
    }
}
