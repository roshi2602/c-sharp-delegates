using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_shap_delegates
{


    //delegates are type safe functiom pointer
    /*
    The syntax for defining a delegate:
    <Access Modifier> delegate <return type> <delegate name> (arguments list);
    */

    /*
     delegate method syntax-
    public delegate void AddDelegate(int a, int b);
    OR
     public delegate string GreetingsDelegate(string name);
    */

    /*NOTE- when we create delegate , then access modifier, return type, arguments, data types 
     of delegate should be same as  access modifier, return type, arguments, data types of function that
    delegate wants to refer*/

    /*Instantiating the delegate-
     Syntax: Delegate Name Object Name = new Delegate Name (target function name);
    */

    //----------------------------------------------------------------
    public delegate void Rect(int len, int bret);                                   // for multicast delegates
    class Program
    {
        //----------------------------------------------------------------
    //anonymous methods in c# ,  //lamda expression
        //used for lesser code volume
        public delegate string Gendelegate(string nm);             //create a delegate




        //----------------------------------------------------------------

        //multicast delegate
        //delegate that holds references of more than 1 function
        //all the functions made will be called in this

        public void rectangle(int len, int bret)
        {
            Console.WriteLine(len * bret);
        }

        public void circle(int len, int bret)
        {
            Console.WriteLine(len + bret);
        }

        //go to main method now
        //----------------------------------------------------------------


        //delegates
        //create delegate first
        //SYNTAX= <Access Modifier> delegate <return type> <delegate name> (arguments list);

        public delegate void delegate1(int a, int b);
        public delegate string delegate2(string x);

        //non static method
        public void Add(int p, int q)
        {
            Console.WriteLine(@"{0}{1}{2}", p, q, p + q);
        }

        //static method
        public static string Mul(string x)      //same parameter of delegate
        {
            return "hi@" + x;
        }
        

        //---------------------------------------------------------------------
        static void Main(string[] args)
{
            //multicast delegate
            Program p = new Program();
            Rect r = new Rect(p.rectangle);
            //in this r is a multicast 
            //use += to add delegates
            //use -+ to remove delegates

            //to add delegates
            r += p.circle;
            r(5, 6);

            Console.WriteLine();
            r.Invoke(10, 20);


            Console.WriteLine();
         

            //to remove delegates
            r -= p.circle;
            r.Invoke(5, 6);
            Console.ReadLine();

            /*output = 30
                          11
                         200
                          30

                          30
                          */


            //----------------------------------------------------------------
            //delegates
            //create object first
            Program pp = new Program();

            /*Instantiating the delegate-
 Syntax: Delegate Name Object Name = new Delegate Name (target function name);
*/
            delegate1 dd1 = new delegate1 (pp.Add);  //non static method calling by using object
            delegate2 dd2 = new delegate2(Program.Mul); //static method calling by using class name

            //calling the delegates
            dd1(200, 300);

            //for second ,
            string dele = dd2("roshi");

            Console.WriteLine(dd2);
            Console.ReadLine();

            /*output= 200 300 500
c_shap_delegates.Program+delegate2 */


            //-------------------------------------------------------------------
            //anonymous delegate
            Gendelegate gd = delegate (string nm)                               //syntax for anonymous delegate
            {
                return "hi@" + nm;                                                //syntax for anonymous delegate
            };


            string gs = gd.Invoke("vandana");                //calling
            Console.WriteLine(gs);
            Console.ReadLine();

            /*output =hi@vandana */
            //-------------------------------------------------------------------
            //lambda expression
            //denoted by lambda operator =>
            //this is just the alternavtive of anonymous delegate
            //see line 37 to 39 

            Gendelegate ob = (nm) =>                   //syntax for lambda expression
             {
                 return "hi@" + nm;
             };

            string gms = ob.Invoke("dubey");
            Console.WriteLine(gms);
            Console.ReadLine();
        }
    
        public static string Greet(string nm)
        {
            return "hi@" + nm;
        }

        /*   /*output =hi@dubey */
        //-------------------------------------------------------------------
    }
}
