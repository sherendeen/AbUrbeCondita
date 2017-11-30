using System;


namespace AbUrbeCondita
{
    /// <summary>
    /// Written by Seth G.R. Herendeen,
    /// 03/10/2016 10/03/2016 2016 10 03
    /// dd mm yyyy dd mm yyyy yyyy mm dd
    /// </summary>
    class Program
    {
       // 4April, 6June, 9September, and 11November have 30 days.
       // 3March, 5May, 7July, 8August, 10October, and 12December have 31 days. 


        static string inValue = "";
        static void Main(string[] args)
        {
            Console.Title = "Ab Urbe Condita Calculator by Seth G.R. Herendeen";
            Console.WriteLine("Do you want the true Ab Urbe Condita (including days & months)? y/n");
            inValue = Console.ReadLine();
            inValue = inValue.ToUpper();
            if (inValue == "Y")
            {

                Console.WriteLine("Input date in format yyyy mm dd with spaces");
                ConvertToAbUrbeCondita(_considerDaysAndMonths: true, _inValue: Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Input year");
                ConvertToAbUrbeCondita(_considerDaysAndMonths: false, _inValue: Console.ReadLine());
            }
            Console.ReadLine();
        }
        static void ConvertToAbUrbeCondita(string _inValue, bool _considerDaysAndMonths)
        {
            
            
            string[] broken = { };
            broken = _inValue.Split(' ');
            int year = 0, month = 0, day = 0;
            if (int.TryParse(broken[0], out year) == false) { Console.WriteLine("Invalid input for year. Parse failed."); }
            year += 753;
            if (_considerDaysAndMonths == true)
            {
                if (int.TryParse(broken[1], out month) == false) { Console.WriteLine("Invalid input for month. Parse failed."); }
                if (int.TryParse(broken[2], out day) == false) { Console.WriteLine("Invalid input for month. Parse failed."); }
                
                month += 4;
                day += 21;
            }
            if (_considerDaysAndMonths == false)
            {
                Console.WriteLine("Ab Urbe Condita:{0}",year);
                
                return;
            }

            while(month>12)
            {
                month = month - 12;
                year++;
            }
            while((month==1||month==3||month==5||month==7||month==9||month==11)&&(day>31))
            {
                day =- 31;
                month++;
            }
            if (month != 2)
            {
                while ((month == 4 || month == 6 || month == 8 || month == 10 || month == 12) && (day > 30))
                {
                    day = -30;
                    month++;
                }
            }
            else
            {

                if (month == 2 && day > 29 && DateTime.IsLeapYear(year))
                {
                    day = -29;
                    month++;
                }
                else if(month == 2&& day>28)
                {
                    day = -28;
                    month++;
                }
            }
            Console.WriteLine("Ab Urbe Condita: year:{0} month:{1} day:{2} ",year,month,day);
        }
    }
}
