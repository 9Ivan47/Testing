using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Lab3_Burulev
{   /**
     * @brief Класс FoodAdditive, вспомогательный класс, для класса Dish
     */
    class FoodAdditive
    {
        //! Стоимость 1 гр.
        private float costPerGram;
        //! Количество грамм, добавляемое на 1 кг продукта
        private int gramsPerKg;

        /**
         * @brief Метод иницилизации параметров класса FoodAdditive
         * @param[in] costPG Стоимость 1 гр.
         * @param[in] gramsPK Количество грамм, добавляемое на 1 кг продукта
         */
        public void Init(int costPG, int gramsPK)
        {
            costPerGram = costPG;
            gramsPerKg = gramsPK;
        }
        /**
         * @brief Метод для ввода параметров класса FoodAdditive через консоль
         */
        public void Read()
        {
            string s = "";
            Console.WriteLine("Введите стоимость 1 гр и количество грамм специи, добавляемое на 1 кг продукта: ");
            s = Console.ReadLine();
            string[] s1;
            s1 = s.Split(new char[] { ' ', '\t' });
            costPerGram = Convert.ToInt32(s1[0]);
            gramsPerKg = Convert.ToInt32(s1[1]);
        }
        /**
         * @brief Метод вывода информации о пищевой добавке на экран
         */
        public void Display()
        {
            Console.WriteLine("\nСтоимость 1 гр пищевой добавки: " + costPerGram);
            Console.WriteLine("Количество грамм специи, добавляемое на 1 кг продукта:  " + gramsPerKg);
        }
        /**
         * @brief Метод вычисления стоимости добавки
         * @return возвращает стоимость пищевой добавки
         */
        public double calculateCost()
        {
            return costPerGram * gramsPerKg;
        }
    }
    /**
     * @brief Класс Блюдо,является основным классом по отношению к FoodAdditive
     */
    class Dish
    {
        private string name;
        /**
         * @brief Переменная с функцией получения имени из приватной переменной name
         */
        public string Name
        {
            get
            {
                return name;
            }
        }
        private int Nk;
        private FoodAdditive[] Kolvo;
        /**
         * @brief Метод иницилизации параметров класса Dish, вызывающий метод Init класса FoodAdditive, для иницилизации его элементов 
         * @param[in] v1 Название блюда
         * @param[in] add1cost Массив стоимостей 1 гр. пищевых добавок
         * @param[in] add1grams Массив колличества грамм специй, добавляемых на 1 кг продукта
         * @param[in] n Колличество пищевых добавок
         */
        public void Init(string v1, int[] add1cost, int[] add1grams, int n)
        {
            Kolvo = new FoodAdditive[n];
            Nk = n;
            int i;
            for (i = 0; i < n; i++)
            {
                Kolvo[i] = new FoodAdditive();
            }
            name = v1;
            for (i = 0; i < n; i++)
            {
                Kolvo[i].Init(add1cost[i], add1grams[i]);
            }

        }
        /**
         * @brief Метод вывода информации о блюде, вызывающий метод вывода информации для каждой пищевой добавки этого блюда
         */
        public void Display()
        {
            Console.WriteLine("\nНазвание блюда:" + name);
            for (int i = 0; i < Nk; i++)
            {
                Kolvo[i].Display();
            }
        }
        /**
         * @brief Метод вычисления общей стоимости блюда
         * @param[in] dishWeight Вес блюда
         * @param[in] baseCost Стоимость единицы основных компонент блюда
         * @return возвращает общую стоимость блюда
         * 
         * Данный метод вычисляет значение общей стоимости блюда по формуле: \f$baseCost+\frac{minm[0]*dishWeight}{100}+\frac{minm[1]*dishWeight}{100}+\frac{minm[2]*dishWeight}{100}\f$.
         * 
         * Код функции выглядит следубщим образом:
         * \code
         * public double calculateTotalCost(double dishWeight, double baseCost)
         * {
         *    double[] minm = new double[3];
         *    for (int i = 0; i < Nk; i++)
         *    {
         *      minm[i] = Kolvo[i].calculateCost();
         *    }
         *    Console.WriteLine("\nВес блюда: " + dishWeight);
         *    Console.WriteLine("\nСтоимость единицы основных компонент блюда: " + baseCost);
         *    double sum = (baseCost + (minm[0] * dishWeight / 100) + (minm[1] * dishWeight / 100) + (minm[2] * dishWeight / 100));  
         *    return sum;
         * }
         * \endcode
         *
         * Результат: \image html C:\Projects\Repositories\Testing\QA_Lab3_Burulev\img\test.png
         */
        public double calculateTotalCost(double dishWeight, double baseCost)
        {
            double[] minm = new double[3];
            for (int i = 0; i < Nk; i++)
            {
                minm[i] = Kolvo[i].calculateCost();
            }
            Console.WriteLine("\nВес блюда: " + dishWeight);
            Console.WriteLine("\nСтоимость единицы основных компонент блюда: " + baseCost);
            double sum = (baseCost + (minm[0] * dishWeight / 100) + (minm[1] * dishWeight / 100) + (minm[2] * dishWeight / 100));
            return sum;
        }
        /**
         * @brief Метод, определяющий самую дешевую добавку
         * @return возвращает информацию о пищевой добавке с наименьшей стоимостью
         */
        public FoodAdditive findCheapestAdditive()
        {
            int N = 3; int i;
            double[] minm = new double[3];
            for (i = 0; i < N; i++)
            {
                minm[i] = Kolvo[i].calculateCost();
            }
            double min = minm[0];
            int r;
            for (r = 1; r < N; r++)
            {
                if (min > minm[r]) min = minm[r];
            }

            for (i = 0; i < N; i++)
            {
                if (min == minm[i]) return Kolvo[i];
            }
            return Kolvo[i];
        }
    }
    /**
     * @brief Класс Program, является основным классом программы
     */
    class Program
    {
        /**
         * @brief Основной метод программы
         * @param[in] args 
         */
        static void Main(string[] args)
        {
            int N = 3; //количество пищевых добавок в блюде
            FoodAdditive first = new FoodAdditive();
            FoodAdditive pb = new FoodAdditive();
            first.Read();
            first.Display();
            Console.WriteLine("Ожидаемая сумма продаж: " + first.calculateCost());
            Dish food = new Dish();
            int[] c = new int[3] { 3, 8, 6 }; //инициализируем массив стоимостей 1 гр. каждой пищевой добавки
            int[] gr = new int[3] { 5, 3, 2 }; //инициализируем массив колличества грамм специй, добавляемых на 1 кг продукта
            string name = " Паста болоньезе";
            food.Init(name, c, gr, N);
            food.Display();
            Console.WriteLine("\nОбщая стоимость блюда: " + food.calculateTotalCost(500, 5.5));
            pb = food.findCheapestAdditive();
            Console.WriteLine("\nСамая дешёвая добавка: ");
            pb.Display();
        }
    }
}
