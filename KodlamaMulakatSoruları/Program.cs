using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaMulakatSoruları
{
    class Program
    {
        static void Main(string[] args)
        {
            RemoveDublicate("ugurmutlukalayci");
        }

        public static string RemoveDublicate(string word)
        {
            string result = "";
            //harflerin tek tek kontrol edilmesi için stringi char dizisine dönüştürüyoruz.
            char[] array = word.ToCharArray();
            //tüm harfleri dolaşmak için döngümüzü oluşturuyoruz.
            for (int i = 0; i < word.Length; i++)
            {
                //eğer sıradaki harf result değişkenimize daha önce eklenmemiş ise ekliyoruz. 
                // (IndexOf string içinde arama yapar ve bulamazsa sonucu -1 döner)
                if (result.IndexOf(array[i]) == -1)
                {
                    result += array[i];
                }
            }

            return result;
        }
    }
}
