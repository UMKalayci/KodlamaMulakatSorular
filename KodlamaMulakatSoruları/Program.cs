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
            PhoneNumberCombinations("23");
            IntToRoman(1994);
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

        public static List<string> PhoneNumberCombinations(string pressNumbers)
        {
            // telefon üzerindeki sayılara karşılık gelen listemizi oluşturuyoruz.
            List<string> phoneNumber = new List<string>() { "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
            List<String> result = new List<String>();
            //kelimeleri oluşturmak için kuyruk listesi tanımlıyoruz.
            Queue<String> q = new Queue<String>();
            //kuyrugun ilk elemanını boş şekilde setliyoruz.
            q.Enqueue("");
            //kuyrukta eleman kalmayana kadar dönüyoruz.
            while (q.Count != 0)
            {
                //kuyruğun ilk elemanını alıp kuyruktan çıkarıyoruz.
                String s = q.Dequeue();
                //eğer kuyruktan aldığımız kelime basılan tuş uzunluğundaysa  
                //kelime tamamlanmış demektir onu sonucumuza ekliyoruz.
                if (s.Length == pressNumbers.Length)
                    result.Add(s);
                else
                {
                    //kelime tamamlanmamış bir kelime ise kelimenin bir sonraki tuştaki harfleri alıyoruz.
                    String val = phoneNumber[Convert.ToInt32(pressNumbers.ToCharArray()[s.Length].ToString())];
                    //kelimeye bir sonraki basılan tuştaki harfleri sırayla ekleyerek kuyruğa dolduruyoruz.
                    for (int i = 0; i < val.Length; i++)
                        q.Enqueue(s + val[i]);
                }
            }
            return result;
        }

        public static string IntToRoman(int num)
        {
            //roma rakamlarındaki sayıların değelerlerini tanımlıyoruz. Bu değerler birleşerek sayılar oluşturulmaktadır.
            Dictionary<int, string> romanValue = new Dictionary<int, string>();
            romanValue.Add(1, "I"); romanValue.Add(4, "IV"); romanValue.Add(5, "V"); romanValue.Add(9, "IX");
            romanValue.Add(10, "X"); romanValue.Add(40, "XL"); romanValue.Add(50, "L"); romanValue.Add(90, "XC");
            romanValue.Add(100, "C"); romanValue.Add(400, "CD"); romanValue.Add(500, "D"); romanValue.Add(900, "CM");
            romanValue.Add(1000, "M");

            string result = "";
            //her işlem için basamak değerini tutmasını sağlacak bir değişken tanımlıyoruz.
            int placeValue = 1;
            while (num > 0)
            {
                //sayının son basamağını alıyoruz
                int value = num % 10;
                //aldığımız değeri basamak değeri ile çarpıyoruz.
                value *= placeValue;

                if (value > 0)
                {
                    //eğer değerimiz listemizden birine denk geliyorsa direk olarak sonucun başına ekliyoruz.
                    if (romanValue.Any(x => x.Key == value))
                    {
                        result = romanValue[value] + result;
                    }
                    else
                    {
                        string str = "";
                        int temp = value;
                        //eğer sayı listede yok ise iki seçenek vardır ya 5,50,500 ün üstünde ya da altında
                        while (temp > 0)
                        {
                            //üstünde olması durumunda sola eklenerek yazılmaktadır.
                            if (value < 5 * placeValue)
                            {
                                //listede sayıdan küçük olan en büyük eleman alınır ve eklenir.
                                var smallValue = romanValue.Where(x => x.Key <= temp).OrderByDescending(x => x.Key).First();
                                str = smallValue.Value + str;
                                temp = temp - smallValue.Key;
                            }
                            //altında olması durumunda sağa eklenerek yazılmaktadır.
                            else
                            {
                                //listede sayıdan küçük olan en büyük eleman alınır ve eklenir.
                                var smallValue = romanValue.Where(x => x.Key <= temp).OrderByDescending(x => x.Key).First();
                                str = str+ smallValue.Value;
                                temp = temp - smallValue.Key;
                            }
                        }
                        //üsteki döngüden çıkan sonuc yine başa eklenir.
                        result = str + result;

                    }

                }
                //sayının son basamağını siliyoruz
                num = num / 10;
                //basamak değerini arttırıyoruz
                placeValue = placeValue * 10;
            }
            return result;
        }
    }
}
