using System;

namespace CeaserEncoder
{
    class App
    {
        // функция возвращает строку
        static string Encode(char[] Chipher, int key, char[] Alp, char[] AlpLower)
        {
            // создаем переменные
            int k, definition;
            char var = ' ';
            string result = "";
            // Создадим цикл для перебора элементов массива
            foreach (char n in Chipher)
            {
                // если символ не входит в Алфавит
                if (Array.IndexOf(Alp, n) == -1 && Array.IndexOf(AlpLower, n) == -1)
                {
                    var = n;
                }
                // алгоритм для верхнего регистра
                else if(Char.ToUpper(n) == n)
                {
                    definition = Math.Abs(Array.IndexOf(Alp, n) - key + Alp.Length);
                    k = Array.IndexOf(Alp, n) - key < 0 ? definition : Array.IndexOf(Alp, n) - key;
                    var = Alp[k];
                }
                // алгоритм для нижнего регистра
                else if (Char.ToUpper(n) != n)
                {
                    definition = Math.Abs(Array.IndexOf(AlpLower, n) - key + AlpLower.Length);
                    k = Array.IndexOf(AlpLower, n) - key < 0 ? definition : Array.IndexOf(AlpLower, n) - key;
                    var = AlpLower[k];
                }
                // прибавляем расшифрованный символ к результату
                result += var;
            }
            // Возвращаем результат
            return result;
        }

        static void Main()
        {
            while (true)
            {
                // Запрашиваем ввод ключа
                Console.Write("Введите ключ: ");
                int key = Int32.Parse(Console.ReadLine());
                // Проверить ключ для завершения программы, то есть если вы введете в поле ввода ключа 0, то программа закончится
                if(key == 0)
                {
                    break;
                }
                Console.WriteLine();
                Console.Write("Введите предложение: ");
                // создаем переменные, sentence - для предложения которые вы вводите, result - для результата
                string sentence = Console.ReadLine(), result;
                // преобразовываем введеное предлоэжение в массив с Char
                char[] code = sentence.ToCharArray();
                // создаем массив Алфавит русского
                char[] Alphabet = { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я' };
                // создаем новый массив и заполняем его буквами нижнего регистра в for-цикле
                char[] AlphabetLower = new char[Alphabet.Length];
                for (int i = 0; i < Alphabet.Length; i++)
                {
                    AlphabetLower[i] = Char.ToLower(Alphabet[i]);
                }
                // вызываем функцию
                result = Encode(code, key, Alphabet, AlphabetLower);
                // пишем результат
                Console.WriteLine(result);
                Console.ReadLine();
            }
        }
    }
}