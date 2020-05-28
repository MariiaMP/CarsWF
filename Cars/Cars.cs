/* 5. Задано текстовий файл з інформацією про автомобілі. 
 * Кожен запис містить марку, тип, рік випуску автомобіля, ціну…*/

namespace Cars
{
    public class Cars
    {
        public string brand { get; set; }
        public string type { get; set; }
        public int year { get; set; }
        public double price { get; set; }
        public Cars() { }

        public Cars(string obj)
        {
            string[] q = obj.Split(' ');
            brand = Validation.if_word(q[0]);
            type = Validation.if_word(q[1]);
            year = Validation.if_year(q[2]);
            price = Validation.if_price(q[3]);
        }

        public Cars(string b, string t, int y, double p)
        {
            brand = Validation.if_word(b);
            type = Validation.if_word(t);
            year = Validation.if_year(y.ToString());
            price = Validation.if_price(p.ToString());
        }
        
        public override string ToString()
        {
            return $"{brand} {type} {year} {price}";
        }
    }
}
