
namespace AdvWorksDemo_test
{
    internal class Program
    {
       /// <summary>
       /// Main Method
       /// </summary>
       /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Adventure Works Sample! - Enter 1 or another number.");
            try
            {
                int intTemp = Convert.ToInt32(Console.ReadLine());

                //call the class and get the data
                GetData getData = new();
                GetData.GetCustomerData(intTemp);
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Please enter a number... Only a few digits please.");
            }
        }
    }
}